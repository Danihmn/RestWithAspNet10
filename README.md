# Rest com ASP.NET 10

## 🚀 Tecnologias Utilizadas

- ASP.NET 10
- Visual Studio 2026
- Postman
- SQL Server
- SQL Server Management Studio (SSMS) 
- Docker
  
## 🛠️ Principais Implementações
- Entity Framework Core
- xUnit
- Serilog
- Versionamento de API
- Padrão DTO (Data Transfer Object)
- Tratamento de erros e validações
- Swagger/OpenAPI — Documentação

## 🗂️ Organização da Solução
### A solução contém dois projetos:
1. RestWithAspNet10 (Projeto principal da API)
Este projeto contém toda a lógica da aplicação, dividido em pastas que facilitam a manutenção e escalabilidade:
  - Configurations: Classes de configuração.
  - Controllers: Endpoints da API.
  - Data: Contexto do Entity Framework e DTOs e Converters.
  - JsonConverters: Conversores personalizados para serialização/deserialização JSON.
  - Migrations: Histórico de migrações do banco de dados via EF Core.
  - Models: Classes que representam os dados.
  - Repositories: Implementações de acesso a dados, seguindo o padrão Repository.
  - Services: Regras de negócio e lógica da aplicação.
  - appsettings.json: Arquivo de configuração da aplicação (conexões, logging, etc.).
  - Program.cs: Ponto de entrada da aplicação.

2. RestWithAspNet10.Tests (Projeto de testes)
  - ProductConverterTests.cs: Testes unitários para conversores de produto, usando xUnit.
