#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Catalog/KriniteWebShop.Catalog.NoSQL.API/KriniteWebShop.Catalog.NoSQL.API.csproj", "Services/Catalog/KriniteWebShop.Catalog.NoSQL.API/"]
RUN dotnet restore "Services/Catalog/KriniteWebShop.Catalog.NoSQL.API/KriniteWebShop.Catalog.NoSQL.API.csproj"
COPY . .
WORKDIR "/src/Services/Catalog/KriniteWebShop.Catalog.NoSQL.API"
RUN dotnet build "KriniteWebShop.Catalog.NoSQL.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KriniteWebShop.Catalog.NoSQL.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KriniteWebShop.Catalog.NoSQL.API.dll"]