# projeto-mvc-dotnet

Um projeto simples, que segue a ideia de fazer alguns cruds básicos e renderizar eles no view correspondente.

## Estrutura do projeto:

Existem três rotas e três cruds, eles são Movies, Clientes e Fornecedores. </br>
Movies: Feito a partir do tutorial da Microsoft, segue a estrutura MVC padrão. </br>
Clientes e Fornecedores: Segue uma ideia de Controller->Service->Repositorio->Context (Seria a lógica do banco) </br>
-> Conforme os dados são pegos do repositório, o controller redenriza isso utilizando o View()

## Rotas:

localhost:$PORT/Movies </br>
localhost:$PORT/Clientes </br>
localhost:$PORT/Fornecedor </br>

## Como conectar no banco de dados:

Tem duas opções, sqlite e SqlServer. No arquivo Startup.cs é possível mudar, somente comentando e descomentando as linhas que estão comentadas, sendo possível escolher qual usar. Ambas strings de conexões estão no arquivo appsettings.json

## Como rodar:

dotnet ef migrations add InitialCreate </br>
dotnet ef database update </br>
dotnet run </br>

## Observação

O Sql Server foi utilizando dentro de um container, para replicar, basta seguir o tutorial da microsoft: <a href="https://learn.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker?view=sql-server-ver16&pivots=cs1-bash">Tutorial</a>
