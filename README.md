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
# Escolha uma pasta em seu computador e 
# Clone este repositório
git clone https://github.com/MPomper/Biblioteca.git
cd Biblioteca

# Restaure os pacotes NuGet
dotnet restore

# Certifique-se de que o LocalDB está instalado. Caso não esteja, instale o (https://learn.microsoft.com/pt-br/sql/database-engine/configure-windows/sql-server-express-localdb) ou edite a connection string para apontar para um SQL Server real.
# Edite o appsettings.Development.json na API
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=LibraryDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}

# Acesse a pasta do projeto API
cd SiemensEnergy.Library.API

# Rode a API
dotnet run --project SiemensEnergy.Library.API

# Abra outro terminal bash e acesse a pasta do projeto Web
cd SiemensEnergy.Library.Web

# Instale as dependências
npm install

# Rode o Web
npm start
