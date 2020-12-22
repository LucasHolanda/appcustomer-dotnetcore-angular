# Customer Management Application

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
**Administrator user with role <i>Administrator</i>**
 - Login: Administrator
 - Password: admin123
 
**Seller 1 user with role <i>Seller</i>**
 - Login: Seller1
 - Password: seller1123
 
**Seller 2 user with role <i>Seller</i>**
 - Login: Seller2
 - Password: seller2123


## Technologies implemented:

- .NET Core 3.1
 - .NET WebApi Core with JWT Bearer Authentication
 - .NET Identity Core
- Entity Framework Core 3.1
- .NET Core Native DI
- AutoMapper
- FluentValidator
- Angular 11

## Architecture:

- Full architecture with responsibility separation concerns, SOLID and Clean Code
- Domain Driven Design (Layers and Domain Model Pattern)
- Event Sourcing
- IoC
- Repository

