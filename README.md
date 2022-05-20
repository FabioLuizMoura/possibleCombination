# PossibleCombination
Sistema para geração de combinações

## Tecnologias Utilizadas
* Linguagem: C#
* Versão do projeto: .NET Core 5.0, 
* Camada de apresentação: Web API, 
* Framework de notificação: Flunt (2.0.5), 
* Framework para acesso a dados: Dapper (20.0.123), 
* Acesso a dado: SqlClient (4.8.3), 
* Recuperar a connection string: Configuration.Abstractions (6.0.0), 

## Configurações para execução
Geração do banco de dados execute o script no banco Sql Server:

> create table CombinationHistoric (
>    Id int identity primary key,
>    Combination varchar(255) not null,
>    SearchDate datetime not null
> );

Defina o projeto __PossibleCombination.API__ como projeto de inicialização.

Insira sua connection string no arquivo __"appsettings.json"__, nessa linha do json "possible.combination.sql": "__Aqui__".
Sinta-se a vontade para executar no IIS Express ou Kestrel.

Para facilitar e documentar as chamadas da api no sistema, foi criado um swagger na aplicação e se encontra ao executar o projeto.