# Clean Architecture with CQRS Pattern
The Onion Diagram of Clean Architecture<br/>
    <img src="https://github.com/zraees/portfolio/assets/27266323/caffdf70-e442-4058-9c23-c28f041f5b19"
        width="250" alt="Clean Architecture">

## Clean Architecture Project Structure
1. **Domain**: This layer contains the core business entities, domain logic, and business rules. It should be completely independent of any other layers or external dependencies.<br/>
2. **Application**: This layer contains the application-specific logic, such as use cases, queries, commands, and services. It acts as a bridge between the Domain layer and the Infrastructure/WebAPI layers.<br/>
3. **Infrastructure**: This layer contains the implementation details, such as data access, external API integrations, and other infrastructure-related code. It should be dependent on the Application layer, but not the other way around.<br/>
4. **WebApi**: This layer is the entry point for the application, handling HTTP requests and responses. It should be dependent on the Application layer, but not the other way around.<br/>

### Some common 3rd party packages used to achieve best practices
* **AutoMapper**: Used for mapping between domain entities and view models/DTOs.<br/>
* **FluentValidation**: Used for implementing robust validation rules for the application's inputs.<br/>
* **MediatR**: Used for implementing the Mediator pattern, which helps decouple the different layers and components of the application.<br/>
* **Serilog**: Used for logging and monitoring the application's behavior, including errors and important events.<br/>

## Some Commands to quick recall
### Sample .NET CLI commands to setup solution 
dotnet new sln --name=CleanArchWithCQRSPattern to add empty solution<br/>
dotnet new webapi --name=CleanArchWithCQRSPattern.WebApi to add new webapi project<br/>
dotnet sln add ./CleanArchWithCQRSPattern.WebApi/CleanArchWithCQRSPattern.WebApi.csproj to add webApi project to solution<br/>
dotnet add app/app.csproj reference lib/lib.csproj to add project reference<br/>
