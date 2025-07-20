# MyBooks - Aplicação Full-Stack de Gerenciamento de Livros

![Badge de Licença](https://img.shields.io/badge/license-MIT-blue.svg)

Este é um projeto full-stack desenvolvido para servir de protifólio, consistindo em uma API RESTful em .NET 
e uma Single Page Application (SPA) em Angular para gerenciar uma biblioteca pessoal de livros, autores e gêneros.

## ✨ Features

* **Backend**: API construída com .NET 9 seguindo princípios de Arquitetura Limpa.
* **Frontend**: SPA reativa construída com Angular 20 (Standalone Components, RxJS).
* **Funcionalidades**: CRUD completo para Gêneros, Autores e Livros.
* **API**: Versionamento de rotas (v1).
* **Testes**: Projetos de testes unitários para o backend e frontend.
* **Banco de Dados**: Persistência de dados com PostgreSQL e Entity Framework Core.

## 🛠️ Tecnologias Utilizadas

| Backend (.NET)          | Frontend (Angular)          |
| :---------------------- | :-------------------------- |
| .NET 9                  | Angular 20                  |
| ASP.NET Core            | TypeScript                  |
| Entity Framework Core   | RxJS (para reatividade)     |
| PostgreSQL              | SCSS                        |
| xUnit (Testes)          | Angular CLI                 |
| Moq (Mocks)             | Karma & Jasmine (Testes)    |

## ⚙️ Pré-requisitos

Antes de começar, garanta que você tenha as seguintes ferramentas instaladas:
* [**.NET SDK 8 (ou superior)**](https://dotnet.microsoft.com/en-us/download)
* [**Node.js (versão LTS)**](https://nodejs.org/en)
* [**Angular CLI**](https://angular.io/cli) (`npm install -g @angular/cli`)
* [**Git**](https://git-scm.com/)
* Um servidor **PostgreSQL** rodando localmente ou em um container Docker.

## 🚀 Configuração e Execução

Siga os passos abaixo para configurar e executar o projeto em seu ambiente local.

### 1. Clonar o Repositório

```bash
git clone https://github.com/allanse/MyBooks-FullStack.git
cd MyBooks-FullStack
```

### 2. Configurar e Rodar o Backend (.NET API)

1.  **Configurar a Conexão com o Banco de Dados**:
    * Abra o arquivo `MyBooks.Api/appsettings.Development.json`.
    * Altere a `DefaultConnection` para apontar para o seu banco de dados PostgreSQL.

    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=5432;Database=MyBooksDb;User Id=postgres;Password=sua_senha_secreta;"
    }
    ```

2.  **Aplicar as Migrations**:
    * Navegue para a pasta da API e execute o comando do Entity Framework para criar as tabelas no banco de dados.
    ```bash
    cd MyBooks.Api
    dotnet ef database update
    ```

3.  **Executar a API**:
    * Ainda na pasta `MyBooks.Api`, inicie o servidor.
    ```bash
    dotnet run
    ```
    * A API estará rodando (ex: `https://localhost:7005`). Deixe este terminal aberto.

### 3. Configurar e Rodar o Frontend (Angular SPA)

1.  **Abra um NOVO terminal**.  

2.  **Navegue para a pasta do Frontend**:
    ```bash
    cd mybooks-spa
    ```

3.  **Instalar as Dependências**:
    ```bash
    npm install
    ```

4.  **Verificar a URL da API**:
    * Abra o arquivo `src/environments/environment.ts`.
    * Garanta que a `apiUrl` corresponde à URL em que sua API está rodando.

    ```typescript
    export const environment = {
      production: false,
      apiUrl: 'https://localhost:7005/api/v1' // Verifique a porta!
    };
    ```

5.  **Executar a Aplicação Angular**:
    ```bash
    ng serve
    ```
    * A aplicação estará disponível em `http://localhost:4200`. Abra este endereço no seu navegador.

## 📁 Estrutura do Projeto (Monorepo)

Este repositório é um monorepo que contém ambos os projetos:

* **`MyBooks.sln`, `MyBooks.Api/`, etc.**: Todo o código-fonte da solução backend em .NET.
* **`mybooks-spa/`**: Todo o código-fonte da aplicação frontend em Angular.

## 📜 Licença

Este projeto está licenciado sob a Licença MIT. Veja o arquivo `LICENSE` para mais detalhes.
