#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Cart/KriniteWebShop.Cart.API/KriniteWebShop.Cart.API.csproj", "Services/Cart/KriniteWebShop.Cart.API/"]
COPY ["Shared/KriniteWebShop.EventBus/KriniteWebShop.EventBus.csproj", "Shared/KriniteWebShop.EventBus/"]
RUN dotnet restore "Services/Cart/KriniteWebShop.Cart.API/KriniteWebShop.Cart.API.csproj"
COPY . .
WORKDIR "/src/Services/Cart/KriniteWebShop.Cart.API"
RUN dotnet build "KriniteWebShop.Cart.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KriniteWebShop.Cart.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KriniteWebShop.Cart.API.dll"]