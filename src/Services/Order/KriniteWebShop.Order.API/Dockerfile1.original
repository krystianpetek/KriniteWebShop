#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["KriniteWebShop.ProductOrder.API/KriniteWebShop.ProductOrder.API.csproj", "KriniteWebShop.ProductOrder.API/"]
COPY ["KriniteWebShop.EventBus/KriniteWebShop.EventBus.csproj", "KriniteWebShop.EventBus/"]
COPY ["KriniteWebShop.ProductOrder.Application/KriniteWebShop.ProductOrder.Application.csproj", "KriniteWebShop.ProductOrder.Application/"]
COPY ["KriniteWebShop.ProductOrder.Domain/KriniteWebShop.ProductOrder.Domain.csproj", "KriniteWebShop.ProductOrder.Domain/"]
COPY ["KriniteWebShop.ProductOrder.Infrastructure/KriniteWebShop.ProductOrder.Infrastructure.csproj", "KriniteWebShop.ProductOrder.Infrastructure/"]
RUN dotnet restore "KriniteWebShop.ProductOrder.API/KriniteWebShop.ProductOrder.API.csproj"
COPY . .
WORKDIR "/src/KriniteWebShop.ProductOrder.API"
RUN dotnet build "KriniteWebShop.ProductOrder.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KriniteWebShop.ProductOrder.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KriniteWebShop.ProductOrder.API.dll"]