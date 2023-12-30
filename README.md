Web api feita em .net 3.1, que será criada em outras versões também posteriormente.

A api tem por objetivo fornecer dados para o [https://github.com/Havnaraak/angular-blog](AngularBlog).

Bibliotecas Utilizadas na API:
<ul>
  <li>Entity Framework</li>
  <li>AutoMapper</li>
  <li>MediatR</li>
  <li>FluentValidations</li>
</ul>

A aplicação terá como SGBD o Postgres em sua versão 16.1.
<br/>```docker run -p 5432:5432 --name postgres -e POSTGRES_PASSWORD=1234 -d postgres:16.1```\

Será adotado os princípios SOLID, DDD, CQRS e UnitOfWork
