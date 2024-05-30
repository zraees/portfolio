# Clean Architecture with CQRS Pattern
The Onion Diagram of Clean Architecture<br/>
    <img src="https://github.com/zraees/portfolio/assets/27266323/caffdf70-e442-4058-9c23-c28f041f5b19"
        width="250" alt="Clean Architecture">

## Clean Architecture Project Structure
Domain: <br/>
Application: <br/>
Infrastructure: <br/>
WebApi: <br/>

## Sample .NET CLI commands to setup solution 
dotnet new sln --name=CleanArchWithCQRSPattern to add empty solution<br/>
dotnet new webapi --name=CleanArchWithCQRSPattern.WebApi to add new webapi project<br/>
dotnet sln add ./CleanArchWithCQRSPattern.WebApi/CleanArchWithCQRSPattern.WebApi.csproj to add webApi project to solution<br/>
dotnet add app/app.csproj reference lib/lib.csproj to add project reference<br/>
