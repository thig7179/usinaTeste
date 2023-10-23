# UsinaTeste

## Descrição
UsinaTeste é um aplicativo CRUD (Create, Read, Update, Delete) baseado em um modelo MVC (Model-View-Controller). Ele consiste em duas camadas distintas - uma interface web e uma API - construídas usando .NET Core 6, Entity Framework e MySQL como o banco de dados.

## Requisitos
Para executar o projeto, você precisará das seguintes ferramentas instaladas em sua máquina:
- [.NET Core 6](https://dotnet.microsoft.com/download/dotnet/6.0)
- [MySQL](https://dev.mysql.com/downloads/mysql/)

## Configuração

### Banco de Dados
1. Crie um banco de dados MySQL para o projeto com nome usina.

### Solução Web
1. Abra a solução "UsinaTeste.Web" no Visual Studio ou em sua IDE preferida.
2. Configure a conexão com o banco de dados no arquivo `appsettings.json`:
   ```json

     "MySqlConnection": "sua_string_de_conexão_mysql"
   
### Utilização
. A camada Web pode ser acessada em http://localhost:porta-web.
. A documentação da API pode ser acessada via Swagger em http://localhost:porta-api/swagger.

### Contribuindo
Se desejar contribuir para o projeto, sinta-se à vontade para criar pull requests ou abrir problemas (issues) no repositório.
