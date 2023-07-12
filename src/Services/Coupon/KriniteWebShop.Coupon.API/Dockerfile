#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["KriniteWebShop.ProductCoupon.API/KriniteWebShop.ProductCoupon.API.csproj", "KriniteWebShop.ProductCoupon.API/"]
RUN dotnet restore "KriniteWebShop.ProductCoupon.API/KriniteWebShop.ProductCoupon.API.csproj"
COPY . .
WORKDIR "/src/KriniteWebShop.ProductCoupon.API"
RUN dotnet build "KriniteWebShop.ProductCoupon.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KriniteWebShop.ProductCoupon.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KriniteWebShop.ProductCoupon.API.dll"]