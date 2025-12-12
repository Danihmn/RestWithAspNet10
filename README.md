# Rest com ASP.NET 10

## 🚀 Tecnologias Utilizadas

- ASP.NET 10 — Framework principal para construção da API
- Visual Studio 2026 — Ambiente de desenvolvimento
- Postman — Ferramenta para testes de requisições HTTP
- SQL Server — Banco de dados relacional
- SQL Server Management Studio (SSMS) — Gerenciamento do banco de dados
- Docker — Containerização da aplicação e banco de dados
  
## 🛠️ Principais Implementações
- Entity Framework Core — ORM para mapeamento objeto-relacional
- xUnit — Framework de testes unitários
- Serilog — Logging estruturado e configurável
- Versionamento de API — Suporte a múltiplas versões da API
- Padrão DTO (Data Transfer Object) — Separação entre modelos de domínio e dados expostos
- Tratamento de erros e validações — Middleware para respostas padronizadas
- Swagger/OpenAPI — Documentação interativa da API

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
