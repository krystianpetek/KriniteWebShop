#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Order/KriniteWebShop.Order.API/KriniteWebShop.Order.API.csproj", "Services/Order/KriniteWebShop.Order.API/"]
COPY ["Shared/KriniteWebShop.EventBus/KriniteWebShop.EventBus.csproj", "Shared/KriniteWebShop.EventBus/"]
COPY ["Services/Order/KriniteWebShop.Order.Infrastructure/KriniteWebShop.Order.Infrastructure.csproj", "Services/Order/KriniteWebShop.Order.Infrastructure/"]
COPY ["Services/Order/KriniteWebShop.Order.Application/KriniteWebShop.Order.Application.csproj", "Services/Order/KriniteWebShop.Order.Application/"]
COPY ["Services/Order/KriniteWebShop.Order.Domain/KriniteWebShop.Order.Domain.csproj", "Services/Order/KriniteWebShop.Order.Domain/"]
RUN dotnet restore "Services/Order/KriniteWebShop.Order.API/KriniteWebShop.Order.API.csproj"
COPY . .
WORKDIR "/src/Services/Order/KriniteWebShop.Order.API"
RUN dotnet build "KriniteWebShop.Order.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KriniteWebShop.Order.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KriniteWebShop.Order.API.dll"]