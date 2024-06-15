# Scraping API

Scraping API é uma aplicação .NET Core para realizar web scraping de informações nutricionais e expor esses dados através de uma API.

### Estrutura do Projeto

```sh
src/
|-- Scraping.API/             # Projeto principal da API
|   |-- Controllers/          # Controladores da API
|   |-- Program.cs            # Ponto de entrada da aplicação
|
|-- Scraping.Application/     # Camada de aplicação
|   |-- DTOs/                 # Objetos de Transferência de Dados (DTOs)
|   |-- Interfaces/           # Interfaces dos serviços de aplicação
|   |-- Mappings/             # Configurações do AutoMapper
|   |-- Services/             # Implementações dos serviços de aplicação
|
|-- Scraping.Domain/          # Camada de domínio
|   |-- Entities/             # Entidades de domínio
|   |-- Interfaces/           # Interfaces dos repositórios de domínio
|
|-- Scraping.Infrastructure/  # Camada de infraestrutura
|   |-- Data/                 # Configurações de acesso a dados
|   |-- Migrations/           # Migrations do banco de dados
|   |-- Repositories/         # Implementações dos repositórios
|   |-- Services/             # Serviços de scraping
```

## Instalação

### Pré-requisitos

- [.NET Core SDK 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Passos para instalação

1. Clone o repositório:

    ```sh
    git clone https://github.com/jvbrigido2/Desafio-Backend-Csharp.git
    cd Desafio-Backend-Csharp
    ```

2. Restaure as dependências do projeto:

    ```sh
    dotnet restore
    ```

3. Configure a conexão com o banco de dados no arquivo `appsettings.json`:

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=.;Database=ScrapingDB;Trusted_Connection=True; TrustServerCertificate=True;"
      },
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "AllowedHosts": "*"
    }
    ```

4. Dentro da pasta src, execute as migrações para criar o banco de dados:

    ```sh
    dotnet ef database update --project Scraping.Infrastructure --startup-project Scraping.API
    ```

5. Execute a aplicação:

    ```sh
   dotnet run --project Scraping.API
    ```


## Uso

Após iniciar a aplicação, a API estará disponível em `https://localhost:7252/swagger` ou `http://localhost:5184/swagger`.

Logo em seguida, rode o endpoint:
```sh
POST /api/food/scrape
```
Que é responsável pelo Web Scraping e então os seguintes endpoints ficarão disponíveis para o uso:

### Endpoints

Para obter a lista de todos os itens de alimentos:

```sh
GET /api/food
```
Para obter um alimento pelo nome:

```sh
GET /api/food/search
```
Para obter um alimento pelo código:
```sh
GET /api/food/code
```

## Tecnologias Utilizadas
- .NET Core 6.0: Framework para desenvolvimento da aplicação.
- Entity Framework Core: ORM para acesso ao banco de dados.
- AutoMapper: Biblioteca para mapeamento de objetos.
- Swashbuckle: Biblioteca para geração de documentação Swagger.
- SQL Server: Banco de dados relacional.
- HtmlAgilityPack: Biblioteca para WebScraping

