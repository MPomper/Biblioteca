# 📌 Biblioteca
> *Projeto desenvolvido em React.js e API RESTful ASP.NET Core com arquitetura em camadas (Clean Architecture), utilizando MediatR, Entity Framework Core, Swagger e boas práticas de desenvolvimento. A aplicação permite a gestão de livros, autores e gêneros.*

## 🚀 Funcionalidades  
- ✅ Criação/Alteração/Exclusão/Busca de Livros, Gêneros e Autores.
- ✅ CRUD de Livros
- ✅ CRUD de Autores
- ✅ CRUD de Gêneros
- ✅ Busca de livros com filtros (título, autor, gênero)
- ✅ Versionamento de API (v1.0)
- ✅ Injeção de dependência

## 🛠 Tecnologias Utilizadas  
- 🔹 React.js 
- 🔹 ASP.NET Core 7
- 🔹 Sql Server
- 🔹 Entity Framework Core
- 🔹 MediatR
- 🔹 Clean Architecture (Camadas: API, Application, Domain, Infrastructure)
- 🔹 Swagger (Swashbuckle)
- 🔹 AutoMapper

## 📦 Instalação e Uso  

```bash
# Antes de executar os passos a seguir, certifique-se que você tenha instalado o Git, .NET SDK 7 (ou superior) e o Node.js em seu computador, caso não tenha, favor seguir os passos disponibilizados logo abaixo.
# Escolha uma pasta em seu computador no qual o projeto será clonado
# Abra um terminal (cmd, bash, etc..) dentro desta pasta e cole o comando abaixo:
git clone https://github.com/MPomper/Biblioteca.git
cd Biblioteca

# Restaure os pacotes NuGet do projeto
dotnet restore

# Certifique-se de que o LocalDB esteja instalado.
# Caso não esteja, instale-o seguindo o tópico (Passo a Passo instalações necessárias) logo abaixo.
# Edite o appsettings.Development.json que está dentro do projeto SiemensEnergy.Library.API, seguindo o passo 5 do tópico SQL Server Express LocalDB em (Passo a Passo instalações necessárias)

# Acesse a pasta do projeto API
cd src/SiemensEnergy.Library.API

# Rode a API
dotnet run

# Abra outro terminal bash e acesse a pasta do projeto SiemensEnergy.Library.Web
cd src/SiemensEnergy.Library.Web

# Instale as dependências
npm install

# Rode o SiemensEnergy.Library.Web
npm start
```
#### Acesse o seu navegador e abra o sistema [Biblioteca](http://localhost:3000) e a api [Swagger](http://localhost:5150/swagger)

## 🛠 Passo a Passo instalações necessárias
*  ### Git
    Link de instalação: [Git](https://git-scm.com/downloads)
    * Passo 1.
      Instale o git
    * Passo 2.
      Após instalado execute o arquivo .exe e siga os passos de instalação padrão do git.

*  ### .NET SDK 7.0
    Link de instalação: [.NET SDK 7.0.](https://dotnet.microsoft.com/pt-br/download/dotnet/7.0)
    * Passo 1.
      Instale o SDK 7.0.0 (ou superior).
      <img width="817" height="356" alt="Passo1" src="https://github.com/user-attachments/assets/4310e9ce-e94a-45fe-bb14-5a9b93e8564c" />
    * Passo 2.
      Após instalado execute o arquivo .exe e siga os passos de instalação padrão do Windows.

* ### Node.js
  Link de instalação: [Node.js](https://nodejs.org/en/download)
  * Passo 1.
      Instale o git
    * Passo 2.
      Após instalado execute o arquivo .exe e siga os passos de instalação padrão do node.

*  ### SQL Server Express LocalDB
    Link de instalação: [Sql Server Express LocalDB](https://learn.microsoft.com/pt-br/sql/database-engine/configure-windows/sql-server-express-localdb)
    * Passo 1.
      Selecione uma das opções abaixo.
      <img width="904" height="325" alt="passo1" src="https://github.com/user-attachments/assets/d4d7a8b1-1a49-47ca-bb4e-b42938f3778a" />
    * Passo 2.
      Escolha o tipo de instalação **Básico**.
      <img width="986" height="576" alt="passo2" src="https://github.com/user-attachments/assets/d4baa1be-8d19-40b6-a355-64928c4f9cf9" />
    * Passo 3.
      Aceite os termos de licença e escolha um local de instalação.
    * Passo 4.
      Copiei a instância de conexão gerada, conforme a imagem abaixo.
      <img width="974" height="775" alt="passo4" src="https://github.com/user-attachments/assets/402da190-d26e-4195-8e29-c5c2c2cfa78b" />
    * Passo 5.
      * Abra o appsettings.Development.json que está dentro do projeto SiemensEnergy.Library.API com um editor de texto e edite seguindo a imagem abaixo.
      * Altere o parâmetro "Server" colando a conexão do passo anterior.
      * Se sua conexão houver uma **"\\"**, adicione mais uma **"\\"** ao lado dela, como no exemplo: localhost\suaconexao ->  localhost\\suaconexao
      <img width="1672" height="251" alt="Passo6" src="https://github.com/user-attachments/assets/5c20d64b-2ece-488d-966e-aba6d0b0fb5b" />
