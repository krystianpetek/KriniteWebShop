#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["KriniteWebShop.PurchaseAggregator/KriniteWebShop.PurchaseAggregator.csproj", "KriniteWebShop.PurchaseAggregator/"]
RUN dotnet restore "KriniteWebShop.PurchaseAggregator/KriniteWebShop.PurchaseAggregator.csproj"
COPY . .
WORKDIR "/src/KriniteWebShop.PurchaseAggregator"
RUN dotnet build "KriniteWebShop.PurchaseAggregator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KriniteWebShop.PurchaseAggregator.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KriniteWebShop.PurchaseAggregator.dll"]