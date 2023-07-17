<br/>
<h1 align="center">
  <img src="./assets/logo/small-logo.png" width="450"/>
</h1>

<h3 align="center">
 KriniteWebShop is a modern platform for online shopping in microservice architecture.
</h3>

**KriniteWebShop** its a mobile application for search and discover interesting places in various categories such as culture, nature, entertainment and many more. The application was created in the [Dart](https://dart.dev/) language using the [Flutter](https://flutter.dev/) framework, which allows you to create beautiful and responsive user interfaces on various platforms. Interesting places are shared by very simple API, created in ASP.NET Core which is currently hosted in [Azure Web App Service](https://azure.microsoft.com/en-us/products/app-service/web). The application is designed for people who like to travel and discover new places, as well as for those who are looking for inspiration for their next trips. The application is designed to make it easier for users to find interesting places and share them with others. The application allows users to browse available places by category, location or name. Users can also add their own places, rate and comment on existing ones, and create lists of favorite places. The application also offers a map function that shows the location of selected places and how to navigate to them.

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

#### Catalog microservice which includes

- ASP.NET Core Web API application

- REST API principles, CRUD operations
- **MongoDB database** connection and containerization
- Repository Pattern Implementation
- Swagger Open API implementation

#### Basket microservice which includes

- ASP.NET Web API application

- REST API principles, CRUD operations
- **Redis database** connection and containerization
- Consume Discount **Grpc Service** for inter-service sync communication to calculate product final price
- Publish BasketCheckout Queue with using **MassTransit and RabbitMQ**
  
#### Discount microservice which includes

- ASP.NET **Grpc Server** application

- Build a Highly Performant **inter-service gRPC Communication** with Basket Microservice
- Exposing Grpc Services with creating **Protobuf messages**
- Using **Dapper for micro-orm implementation** to simplify data access and ensure high performance
- **PostgreSQL database** connection and containerization

#### Microservices Communication

- Sync inter-service **gRPC Communication**

- Async Microservices Communication with **RabbitMQ Message-Broker Service**
- Using **RabbitMQ Publish/Subscribe Topic** Exchange Model
- Using **MassTransit** for abstraction over RabbitMQ Message-Broker system
- Publishing BasketCheckout event queue from Basket microservices and Subscribing this event from Ordering microservices
- Create **RabbitMQ EventBus.Messages library** and add references Microservices

#### Ordering Microservice

- Implementing **DDD, CQRS, and Clean Architecture** with using Best Practices

- Developing **CQRS with using MediatR, FluentValidation and AutoMapper packages**
- Consuming **RabbitMQ** BasketCheckout event queue with using **MassTransit-RabbitMQ** Configuration
- **SqlServer database** connection and containerization
- Using **Entity Framework Core ORM** and auto migrate to SqlServer when application startup

#### API Gateway Ocelot Microservice

- Implement **API Gateways with Ocelot**

- Sample microservices/containers to reroute through the API Gateways
- Run multiple different **API Gateway/BFF** container types
- The Gateway aggregation pattern in Shopping.Aggregator

#### WebUI ShoppingApp Microservice

- ASP.NET Core Web Application with Bootstrap 4 and Razor template

- Call **Ocelot APIs with HttpClientFactory** and **Polly**

#### Microservices Cross-Cutting Implementations

- Implementing **Centralized Distributed Logging with Elastic Stack (ELK); Elasticsearch, Logstash, Kibana and SeriLog** for Microservices

- Use the **HealthChecks** feature in back-end ASP.NET microservices
- Using **Watchdog** in separate service that can watch health and load across services, and report health about the microservices by querying with the HealthChecks

#### Microservices Resilience Implementations

- Making Microservices more **resilient Use IHttpClientFactory** to implement resilient HTTP requests

- Implement **Retry and Circuit Breaker patterns** with exponential backoff with IHttpClientFactory and **Polly policies**

#### Ancillary Containers

- Use **Portainer** for Container lightweight management UI which allows you to easily manage your different Docker environments

- **pgAdmin PostgreSQL Tools** feature rich Open Source administration and development platform for PostgreSQL

#### Docker Compose establishment with all microservices on docker

- Containerization of microservices

- Containerization of databases
- Override Environment variables

## Run The Project

You will need the following tools:

- [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/)
- [.Net Core 5 or later](https://dotnet.microsoft.com/download/dotnet-core/5)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)

### Installing

Follow these steps to get your development environment set up: (Before Run Start the Docker Desktop)

1. Clone the repository
2. Once Docker for Windows is installed, go to the **Settings > Advanced option**, from the Docker icon in the system tray, to configure the minimum amount of memory and CPU like so:

- **Memory: 4 GB**

- CPU: 2

3. At the root directory which include **docker-compose.yml** files, run below command:

```csharp
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
```

>Note: If you get connection timeout error Docker for Mac please [Turn Off Docker's "Experimental Features".](https://github.com/aspnetrun/run-aspnetcore-microservices/issues/33)

4. Wait for docker compose all microservices. That’s it! (some microservices need extra time to work so please wait if not worked in first shut)

5. You can **launch microservices** as below urls:

- **Catalog API -> <http://host.docker.internal:8000/swagger/index.html>**
- **Basket API -> <http://host.docker.internal:8001/swagger/index.html>**
- **Discount API -> <http://host.docker.internal:8002/swagger/index.html>**
- **Ordering API -> <http://host.docker.internal:8004/swagger/index.html>**
- **Shopping.Aggregator -> <http://host.docker.internal:8005/swagger/index.html>**
- **API Gateway -> <http://host.docker.internal:8010/Catalog>**
- **Rabbit Management Dashboard -> <http://host.docker.internal:15672>**   -- guest/guest
- **Portainer -> <http://host.docker.internal:9000>**   -- admin/admin1234
- **pgAdmin PostgreSQL -> <http://host.docker.internal:5050>**   -- <admin@aspnetrun.com>/admin1234
- **Elasticsearch -> <http://host.docker.internal:9200>**
- **Kibana -> <http://host.docker.internal:5601>**

- **Web Status -> <http://host.docker.internal:8007>**
- **Web UI -> <http://host.docker.internal:8006>**

5. Launch <http://host.docker.internal:8007> in your browser to view the Web Status. Make sure that every microservices are healthy.
6. Launch <http://host.docker.internal:8006> in your browser to view the Web UI. You can use Web project in order to **call microservices over API Gateway**. When you **checkout the basket** you can follow **queue record on RabbitMQ dashboard**.

# colors

- background - #004b61
- foreground - #0094b3
- background2 - #01708b
- text - #ffffff

# sections

- logo
- title
- description
- TOC - table of contents
- features
- requirements
- usage
- technologies (Build with)
- architektura
- folder structure ??
- app screenshots
- API (table of api endpoints - swagger)
