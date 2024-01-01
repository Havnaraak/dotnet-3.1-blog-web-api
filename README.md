Web api feita em .net 3.1, que será criada em outras versões também posteriormente.

A api tem por objetivo fornecer dados para o [https://github.com/Havnaraak/angular-blog](AngularBlog).

Bibliotecas Utilizadas na API:
<ul>
  <li>Entity Framework</li>
  <li>AutoMapper</li>
  <li>MediatR</li>
  <li>FluentValidations</li>
</ul>


Será adotado os princípios SOLID, DDD, CQRS e UnitOfWork

A aplicação terá como SGBD o Postgres em sua versão 16.1.

Requisitos para execução do projeto:


>SGBD PostgreSQL

Caso queria utilizar via docker:<br/>
```docker run -p 5432:5432 --name postgres -e POSTGRES_PASSWORD=1234 -d postgres:16.1```


>Configurar Sercrets.Json

Adicionar a string de conexão no Secrets do projeto.
</br>```"connectionString": "Host=localhost; Database=BlogWebApi; Port=5432; Username=postgres; Password=1234"```

>Executar Migrations

Antes de buildar o projeto, executar o seguinte comando para criar o banco de dados e popular a base com alguns dados básicos:

dotnet CLI:
<br/>```dotnet ef database update -s BlogWebApi.Api --project BlogWebApi.Infrastructure.Data```


Como não será publicado pra produção, não configurei Environment para execução do projeto.
