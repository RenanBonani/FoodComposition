<h1 align="center"> Projeto de WebScrapping de composição de alimentos</h1>

<p align="center">
  <a href="#-tecnologias">Tecnologias</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#-projeto">Desafio</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#-layout">Instruções de Instalação e Uso</a>
</p>

<br/>

## 🚀 Tecnologias

Esse projeto foi desenvolvido com as seguintes tecnologias:

- C#
- .NET Core
- AngleSharp
- PostgreSQL
- Git e Github

## 💻 Sobre o desafio

Este projeto consiste na criação de uma ferramenta de monitoramento de preços utilizando web scraping para obter informações sobre a composição de alimentos. A interface de usuário permitirá aos usuários visualizar os alimentos, suas composições e realizar buscas por nome de alimento.

Utilizando como base de dados

- Link: https://www.tbca.net.br/base-dados/composicao_estatistica.php?pagina=1&atuald=1#

## 🔖 Instruções de Instalação e Uso

Para instalar e utilizar o projeto, siga estas etapas:
<br/>

<h2>Pré-requisitos</h2>
- Certifique-se de ter o ambiente de desenvolvimento C#/.NET configurado em sua máquina. Você pode baixar o .NET em dotnet.microsoft.com.
- Tenha acesso à URL da API do banco de dados ou à URL da base de dados local.

<h2>Configuração das URLs do Cors</h2>
Se necessário, configure a API para aceitar requisições do front-end. Isso pode envolver a configuração do CORS (Cross-Origin Resource Sharing) para permitir requisições vindas do domínio do front-end.<br>

Seguindo os passos:

- Acesse o FoodComposition.API\Program.cs
- Corrija para a sua url das requisições do front-end em: builder.WithOrigins("http://localhost:5173")

<h2>Integração com o Banco de Dados</h2>
Certifique-se de que a API esteja se conectando corretamente ao banco de dados configurado.

- Acesse FoodComposition.API/appsettings.json
- Em "WebApiDatabase": "Host=localhost; Port=SUA_PORTA; Database=SEU_BANCO; Pooling=true; Username=postgres; Password=SUA_SENHA;"

<h2>Criação da Tabela FoodComposition no Banco de Dados</h2>
Neste projeto, foi utilizado o PostgreSQL (Postgres), e o script SQL abaixo é específico para esse banco de dados. No entanto, pode haver diferenças na sintaxe de criação de tabelas entre bancos de dados diferentes.
<br/>

```sql
CREATE TABLE FoodComposition (
id SERIAL PRIMARY KEY,
code VARCHAR(50) NOT NULL,
nameFood VARCHAR(500) NOT NULL,
scientificName VARCHAR(255),
groupFood VARCHAR(255),
componentes VARCHAR(255)[]
);
```
