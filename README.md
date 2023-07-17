<br/>
<div align="center">
  <img src="./assets/logo/small-logo.png" width="500"/>
</div>
<br/>

## KriniteWebShop - a platform for online shopping

**AwesomePlaces** its a mobile application for search and discover interesting places in various categories such as culture, nature, entertainment and many more. The application was created in the [Dart](https://dart.dev/) language using the [Flutter](https://flutter.dev/) framework, which allows you to create beautiful and responsive user interfaces on various platforms. Interesting places are shared by very simple API, created in ASP.NET Core which is currently hosted in [Azure Web App Service](https://azure.microsoft.com/en-us/products/app-service/web). The application is designed for people who like to travel and discover new places, as well as for those who are looking for inspiration for their next trips. The application is designed to make it easier for users to find interesting places and share them with others. The application allows users to browse available places by category, location or name. Users can also add their own places, rate and comment on existing ones, and create lists of favorite places. The application also offers a map function that shows the location of selected places and how to navigate to them.

- KriniteWebShop is a platform for online shopping that provides a convenient and secure way for customers to buy products from various sellers.
- The platform is developed using microservice architecture, which allows for scalability, reliability and easy maintenance of the system.
- The platform uses ASP.NET Core as the main technology for each microservices, which are hosted in Docker as containers and also in local environment.
- The platform offers a variety of features for both customers and sellers, such as product catalog, shopping cart, payment processing, order management, reviews and ratings, etc.
- The platform aims to create a positive and satisfying shopping experience for customers, as well as to help sellers grow their businesses and reach more customers.

<br/>
<div align="center">
    <img src="./assets/screens/show-2.png" height="700" />
    <img src="./assets/screens/show-1.png" height="700" />
</div>

## Run the application

### WebAPI

## Project architecture

The project was created using the following technologies:

### Back-end

- `ASP.NET Core 7` - framework for creating web applications, APIs and services
- `Entity Framework Core` - ORM (Object Relational Mapper) to map objects to relational databases, in this case the `InMemory` database
- `Dapper` - ORM for mapping objects to relational databases, in this case it is the `Sqlite` database (relational database in the form of a file)
- `FluentValidation` - library for model validation, checking the correctness of input data to the API with `IEndpointFilter` in middleware of ASP.NET Core
`Swagger` - a tool for documenting and querying the API

### Front-end

<div align="center">
  <img src="./assets/screens/clean-architecture.png" />
</div>
<br/>

- `.Core` - domain layer, containing domain entities, specifically: ``,`` and `` and identity entities `User` and `Role`, as well as public contracts to repositories of these entities, contracts to services domain names and exceptions. This layer does not depend on any other layer, it has no external dependencies, it is the most inner layer.

- `AwesomePlaces.Application` - the application layer containing the business logic of the application, in this case these are application services that use domain service contracts from the `AwesomePlaces.Core` layer, which are then used in controllers to separate database repositories from models passed in controllers, it's another level of abstraction, that was created. In this layer, there are also DTO (Data transfer object) models with them validators, that pass data via the public interface in `.Api`, and later in the next stage, before performing operations on the database, they are mapped to domain entities. This layer depends on the domain layer, but no longer depends on any external layers.

- `.Infrastructure` - the infrastructure layer, contains implementations of interfaces from the `.Core` layer, in this case these are repository implementations that use the `InMemory` database with `Entity Framework Core` and `Sqlite` with the support of `Dapper`, as well as implementations of application services that use repositories. In this system, this layer contains implementations of repositories that are used in application services. This layer depends on the `.Application`, it inherits from the domain layer because there is inheritance from the application layer. It is a layer that combines external dependencies with the domain layer, but using abstractions in the domain and application layer, the dependence of external entities from the project's business rules has been separated. The infrastructure layer is mainly used to communicate external dependencies not directly related to the project's business theme, such as a database, file system or external API.

- `.Api` - API layer, contains controllers that are responsible for handling HTTP requests that are sent to the API. This layer also contains the Swagger configuration, which is used to document the API and to test endpoints, with the implementation of authentication using the JWT token (Json Web Token). This layer depends on the application layer by inheriting from the infrastructure layer, because it uses application services that are used in controllers. This layer is the outermost layer, because it is the layer that is visible to the end users of the system, because it is here that endpoints are issued that are used by client applications to communicate with the API. This layer is directly dependent only on the infrastructure layer. A global error handling system has also been implemented here, which is used in controllers to return appropriate HTTP error codes, depending on what error occurred in the system, and to ensure that the application is not stopped by an unhandled exception.

## Features

## Screenshots

| | | |
| :-------------------------:|:-------------------------:|:-------------------------: |
| ![](./assets/screens/1.png)  |  ![](./assets/screens/2.png) | ![](./assets/screens/3.png) |

![Architecture diagram](./assets/architecture-diagram/project.png)
