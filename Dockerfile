# Use a imagem base do .NET SDK 9.0 para compilar o projeto
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Defina o diretório de trabalho dentro do container
WORKDIR /app

# Copie o arquivo .csproj da pasta API e restaure as dependências
COPY Api/*.csproj ./Api/
RUN dotnet restore ./Api/Api.csproj

# Copie o restante do código para dentro do container
COPY . .

# Publique a aplicação para a pasta /out
RUN dotnet publish Api/Api.csproj -c Release -o /out

# Imagem base para executar a aplicação (usamos a imagem do .NET com ASP.NET Core)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base

# Defina o diretório de trabalho dentro do container
WORKDIR /app

# Copie os arquivos publicados do estágio anterior para o container
COPY --from=build /out .

# Exponha a porta que o servidor web vai escutar
EXPOSE 80

# Comando para rodar a aplicação
ENTRYPOINT ["dotnet", "API.dll"]
