<h1 align="center">TSP</h1>
<h3 align="center">Tech Start Pro - Olist :bookmark_tabs:</h3>


# O que é este projeto?
- O TSP tem como objetivo permitir ao usuário o armazenamento e manipulação de cadastros de produtos. 
Nele é possível armazenar dados como nome, descrição, preço e a categoria a qual o produto pertence, o usuário também pode editar ou deletar os produtos a qualquer momento.
As categorias são cadastradas através da importação de um CSV, onde o usuário previamente insere todas as categorias desejadas e importa todas elas no sistema de uma forma rápida e simples :wink:

# E como este projeto esta sendo desenvolvido?
- Ele foi construído como uma aplicação Web Asp.Net, abaixo deixo as configurações utilizadas:
    - A IDE escolhida foi o Visual Studio 2019;
    - É baseado no .NET Framework 4.7.3;
    - Nossa base de dados é MySQL e utilizamos a lib MySQL.Data na versão 8.0.22 _(Está disponível no gerenciador de pacotes NuGet do Visual Studio)_
    - Para deixar tudo mais bonitinho, Bootstrap na versão 4.5.3 e Jquery na versão 3.0.0;

- O projeto foi dividio em três camadas, são elas:
    - __Site (vulgo User Interface)__ :arrow_right: Camada de apresentação e interação com o usuário;
    - __BLL (Business Logic Layer)__ :arrow_right: Camada de negócio onde são realizadas todas as validações e tratamentos de dados de acordo com o escopo do projeto;
    - __DAL (Data Access Layer)__ :arrow_right: Camada de acesso ao banco de dados onde é invocada as Stored Procedure responsáveis por realizar todas as ações dentro do nosso banco de dados;

Ahhh foi utilizado o Windows 10 😊 </br>
Nosso status hoje é: __Em desenvolvimento__ :warning:

# Gostei, como eu posso colaborar para o projeto?
- Bom, após clonar este repositório e montar o seu ambiente de acordo com as especificações citadas acima você pode começar rodando o script __v1_structure.sql__, nele são criadas todas as estruturas da base de dados:
    - Usuários
    - Tabelas
    - Stored Procedures
- __Este arquivo está disponível na camada DAL em Resources :arrow_right: Data.__

Lembre-se, caso você altere o nome da base, usuário ou senha do banco de dados, no arquivo __web.config__ é necessário atualizar as informações Database, Id e Password:
```
<connectionStrings>
    <add name="TSP" connectionString="Database=NOMEDABASEDADOS;Data Source=localhost;User Id=USUARIO;Password=SENHA;" providerName="MySqlProviders" />
  </connectionStrings>
``` 
:loudspeaker: Dúvidas ou sugestões é só chamar!!
