# Projeto Desafio Blip de Repositórios do GitHub

Este é um projeto de API minimalista desenvolvida com **.NET 9.0** que integrado a um **Chatbot Blip** lista os repositórios mais antigos de um usuário do **GitHub**.

## Funcionalidades

- Recupera os repositórios públicos de um usuário do GitHub através da API pública do GitHub.
- Permite acessar os repositórios mais antigos, atraves de um chatbot **Chatbot Blip**.

## Tecnologias Utilizadas

- **.NET 9.0**: Framework utilizado para construir a API.
- **Docker**: Contêinerização da aplicação para facilitar o deploy.
- **Fly.io**: Plataforma de deploy para rodar a aplicação na nuvem.
- **GitHub API**: Para consultar os dados dos repositórios públicos de um usuário.

## Requisitos

- **Docker**: Para rodar a aplicação localmente em contêiner.
- **Fly CLI**: Para deploy no Fly.io.
- **.NET 9**: Para rodar o código localmente ou em servidores.

## Como Rodar Localmente
1. **Clonar o repositório:***
```bash
git clone https://github.com/RicardoIA/blip-challenge.git
cd blip-challenge
```

2. **Restaurar dependências (se necessário):**
```bash
dotnet restore
```

3. **Executar a aplicação localmente:**
```bash
dotnet run
```
A API estará disponível em **http://localhost:5000** (ou a porta configurada).

### Executar via Docker
1. **Construir a imagem Docker:**
```bash
docker build -t blipchallenge .
```

2. **Rodar o contêiner Docker:**

```bash
docker run -d -p 8080:80 minha-aplicacao-api
```

Agora, a API estará disponível em **http://localhost:8080**.

## Endpoints da API
1. GET api/blip/getCarouselRepos?user={username}
Este endpoint retorna os 5 repositórios mais recentes de um usuário do GitHub, ordenados pela data de criação
