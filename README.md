# Igreja de Cristo — REST API

🇧🇷 Português | 🇺🇸 English

## 🇧🇷 Português

### Sobre o projeto

A **Igreja de Cristo REST API** é uma API desenvolvida em **C# e ASP.NET Core 8** para fornecer uma camada de backend para uma aplicação web da Igreja de Cristo.

O projeto nasceu a partir da necessidade de separar o frontend Angular da camada de acesso aos dados, criando uma arquitetura em que o frontend consome uma API própria e o backend é responsável pela comunicação com o Supabase.

### Arquitetura atual

```text
Angular
   │
   │ HTTP
   ▼
ASP.NET Core Web API
   │
   │ HttpClient
   ▼
Supabase REST API
   │
   ▼
PostgreSQL
```

O Angular não acessa diretamente as credenciais do Supabase. A comunicação com o serviço externo acontece exclusivamente através do backend.

### Tecnologias

- C#
- .NET 8
- ASP.NET Core Web API
- REST
- HttpClient
- Supabase REST API
- PostgreSQL
- Swagger / OpenAPI
- JSON
- Git / GitHub

### Estrutura atual

```text
igreja-cristo-net-api/
│
├── Controllers/
│   └── IgrejasController.cs
│
├── Models/
│   └── Igreja.cs
│
├── Properties/
│   └── launchSettings.json
│
├── Program.cs
├── appsettings.json
├── appsettings.Development.json
├── igreja-cristo-net-api.csproj
├── igreja-cristo-net-api.http
└── .gitignore
```

Os diretórios e arquivos de build (`bin`, `obj`) não fazem parte do código versionado.

### API

Atualmente a API disponibiliza:

```http
GET /api/igrejas
```

Esse endpoint consulta as congregações armazenadas no Supabase e retorna os dados através da API ASP.NET Core.

### Modelagem

Os dados retornados pelo Supabase são desserializados para objetos C# através do modelo:

```csharp
Igreja
```

O modelo representa os dados de uma congregação, incluindo informações como:

- país;
- estado;
- UF;
- região;
- cidade;
- nome da congregação;
- endereço;
- CEP;
- quantidade de membros;
- observações.

### Integração com Supabase

A integração é realizada diretamente através da **REST API do Supabase**, utilizando `HttpClient`.

O fluxo atual é:

```text
GET /api/igrejas
       │
       ▼
IgrejasController
       │
       ▼
HttpClient
       │
       ▼
Supabase REST API
       │
       ▼
JSON
       │
       ▼
List<Igreja>
       │
       ▼
HTTP Response
```

### Segurança

As credenciais do Supabase não são armazenadas no código-fonte.

Durante o desenvolvimento, a chave é armazenada através do mecanismo **.NET User Secrets** e acessada pela aplicação utilizando `IConfiguration`.

```text
.NET User Secrets
       │
       ▼
IConfiguration
       │
       ▼
IgrejasController
       │
       ▼
Supabase
```

O arquivo `.gitignore` também impede que arquivos sensíveis ou artefatos de ambiente sejam versionados.

### Banco de dados

O backend consome a tabela `congregacoes` do PostgreSQL através da REST API do Supabase.

A tabela contém informações de localização e cadastro das congregações.

O acesso público de leitura é controlado através das políticas de **Row Level Security (RLS)** do Supabase.

### Swagger

Durante o desenvolvimento, a API pode ser explorada e testada através do Swagger/OpenAPI.

Endpoint local:

```text
http://localhost:5237/swagger/index.html
```

### Objetivos de aprendizado

Além de construir uma API funcional, este projeto está sendo utilizado para aprofundar conceitos de desenvolvimento backend com C# e .NET, incluindo:

- classes e objetos;
- propriedades;
- métodos;
- construtores;
- interfaces;
- injeção de dependência;
- controllers;
- HTTP;
- REST;
- serialização e desserialização JSON;
- `HttpClient`;
- configuração de aplicações;
- gerenciamento seguro de credenciais;
- integração entre sistemas.

### Próximos passos

A evolução planejada do projeto inclui:

- integração com o frontend Angular;
- criação de filtros e consultas de congregações;
- tratamento estruturado de erros;
- criação de uma camada de Services;
- criação de DTOs;
- organização progressiva da arquitetura;
- novos endpoints;
- publicação da API;
- integração do frontend e backend em produção.

O objetivo é evoluir a aplicação gradualmente, adicionando complexidade somente quando houver necessidade real.

---

## 🇺🇸 English

### About the project

The **Igreja de Cristo REST API** is a backend application developed with **C# and ASP.NET Core 8** to provide a dedicated API layer for an existing Igreja de Cristo web application.

The project was created to separate the Angular frontend from data access, allowing the frontend to consume a dedicated backend while the API handles communication with Supabase.

### Current architecture

```text
Angular
   │
   │ HTTP
   ▼
ASP.NET Core Web API
   │
   │ HttpClient
   ▼
Supabase REST API
   │
   ▼
PostgreSQL
```

The Angular application does not directly access Supabase credentials. Communication with the external service is handled by the backend.

### Technologies

- C#
- .NET 8
- ASP.NET Core Web API
- REST
- HttpClient
- Supabase REST API
- PostgreSQL
- Swagger / OpenAPI
- JSON
- Git / GitHub

### Current structure

```text
igreja-cristo-net-api/
│
├── Controllers/
│   └── IgrejasController.cs
│
├── Models/
│   └── Igreja.cs
│
├── Properties/
│   └── launchSettings.json
│
├── Program.cs
├── appsettings.json
├── appsettings.Development.json
├── igreja-cristo-net-api.csproj
├── igreja-cristo-net-api.http
└── .gitignore
```

Build directories such as `bin` and `obj` are excluded from version control.

### API

The API currently provides:

```http
GET /api/igrejas
```

This endpoint retrieves congregation data from Supabase and exposes it through the ASP.NET Core API.

### Data modeling

Supabase JSON responses are deserialized into C# objects using the:

```csharp
Igreja
```

model.

The model represents congregation information such as location, address, congregation name, membership count and additional observations.

### Supabase integration

The backend communicates directly with the **Supabase REST API** using `HttpClient`.

The current flow is:

```text
GET /api/igrejas
       │
       ▼
IgrejasController
       │
       ▼
HttpClient
       │
       ▼
Supabase REST API
       │
       ▼
JSON
       │
       ▼
List<Igreja>
       │
       ▼
HTTP Response
```

### Security

Supabase credentials are not stored in the source code.

During development, the API key is managed through **.NET User Secrets** and accessed through `IConfiguration`.

```text
.NET User Secrets
       │
       ▼
IConfiguration
       │
       ▼
IgrejasController
       │
       ▼
Supabase
```

The `.gitignore` configuration also prevents sensitive files and environment-specific artifacts from being committed.

### Database

The backend consumes the `congregacoes` PostgreSQL table through the Supabase REST API.

The table stores congregation location and registration information.

Public read access is controlled through **Supabase Row Level Security (RLS)** policies.

### Swagger

During development, the API can be explored and tested using Swagger/OpenAPI.

Local endpoint:

```text
http://localhost:5237/swagger/index.html
```

### Learning objectives

Beyond building a functional API, this project is being used to develop a deeper understanding of C# and .NET backend development, including:

- classes and objects;
- properties;
- methods;
- constructors;
- interfaces;
- dependency injection;
- controllers;
- HTTP;
- REST;
- JSON serialization and deserialization;
- `HttpClient`;
- application configuration;
- secure credential management;
- system integration.

### Roadmap

Planned improvements include:

- Angular frontend integration;
- congregation filtering and querying;
- structured error handling;
- introduction of a Service layer;
- DTOs;
- progressive architectural organization;
- additional endpoints;
- API deployment;
- production frontend/backend integration.

The goal is to evolve the application incrementally, introducing complexity only when there is a real need for it.

---

## 👨‍💻 Author

**Gesiel Souza Oliveira**

Frontend Developer · Angular · C#/.NET · Digital Analytics

GitHub: https://github.com/gesielbr

Portfolio: https://gesieloliveira.com.br
