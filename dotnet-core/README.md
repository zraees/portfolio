# .Net Core Projects

## Project 1.1: Clean Architecture with CQRS Design Pattern Implementation using Mediator

**Technologies Used:**
- ASP.NET Core Web API 8.0
- CQRS Pattern with Mediator Pattern
- Many other design patterns such as Repository Pattern and Result Pattern
- Entity Framework Core
- SQLite

This project demonstrates the implementation of the Clean Architecture pattern along with the CQRS (Command Query Responsibility Segregation) design pattern using the Mediator pattern. The application is built using ASP.NET Core Web API 8.0 and follows the principles of separation of concerns, testability, and maintainability.

The key features of this project include:

- Separation of concerns between commands, queries, and handlers
- Use of the Mediator pattern to decouple the application logic from the infrastructure
- Integration with Entity Framework Core for data access
- SQLite as the underlying database

## Project 1.2: OrderProcessUsingRabbitMq

This project creates a simple web API endpoint to create an order, which publishes a message to a RabbitMQ queue. The console application consumes the messages from the queue and processes the orders.

## Project 1.3: OrderProcessUsingMassTransitRabbitMq

This project creates a simple web API endpoint to create an order, which publishes a message using a MassTransit RabbitMQ queue. The console application consumes the messages from the queue and processes the orders.

## Project 1.4: ASP.NET Identity Implementation

**Technologies Used:**
- ASP.NET Core Web API 8.0
- ASP.NET Identity
- JSON Web Tokens (JWT)
- Entity Framework Core
- SQLite

This project demonstrates the implementation of user authentication and authorization using the ASP.NET Identity framework. It includes features such as user registration, login, and role-based access control.

The key features of this project include:

- Integration with ASP.NET Identity for user management
- Use of JSON Web Tokens (JWT) for secure authentication
- Entity Framework Core for data access
- SQLite as the underlying database

This project showcases the integration of ASP.NET Identity with a Web API application, providing a secure and scalable authentication and authorization mechanism.
