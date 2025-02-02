using System;

namespace Api.Middlewares;

public class TokenAuthenticationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;

    public TokenAuthenticationMiddleware(RequestDelegate next, IConfiguration configuration){
        _next = next;
        _configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context){
        var fixedToken = _configuration["TokenApi"];

        if (!context.Request.Headers.ContainsKey("Authorization")){
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Not found token.");
            return;
        }

        var authHeader = context.Request.Headers["Authorization"].ToString();
        var token = authHeader.StartsWith("Bearer ") ? authHeader.Substring(7).Trim() : string.Empty;

        if (!string.Equals(token, fixedToken)){
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Invalid token.");
            return;
        }

        await _next(context);
    }
}
