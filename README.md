# Customer Management App

## How to use:

### Database
- Enable `sa` user in the database and set password according to <b>appsettings.json</b> file located in the project folder at <b>CustomerApp-BackEnd/1 - Services/ProjectCoreDDD.API</b>

### API
- Find the project folder at <b>CustomerApp-BackEnd/1 - Services/ProjectCoreDDD.API/</b>
- Run `dotnet restore`
- Run `dotnet run` to run the API at `http://localhost:5000/`

### Web Application 
- Find the project folder at <b>CustomerApp-FrontEnd</b>
- Run `npm install -g @angular/cli`
- Run `npm install` to install all project packages
- Run `ng serve` to run the web application at `http://localhost:4200/`

### Application Users for testing
**User <b>Administrator</b> with user role <i>Administrator</i>**
 - Login: Administrator
 - Password: admin123
 
**User <b>Seller 1</b> with user role <i>Seller</i>**
 - Login: Seller1
 - Password: seller1123
 
**User <b>Seller 2</b> with user role <i>Seller</i>**
 - Login: Seller2
 - Password: seller2123


## Technologies implemented:

- ASP.NET Core 3.1 (with .NET Core 3.1)
 - ASP.NET WebApi Core with JWT Bearer Authentication
 - ASP.NET Identity Core
- Angular 11
- Entity Framework Core 3.1
- .NET Core Native DI
- AutoMapper
- FluentValidator

## Architecture:

- Full architecture with responsibility separation concerns, SOLID and Clean Code
- Domain Driven Design (Layers and Domain Model Pattern)
- Event Sourcing
- IoC
- Repository

