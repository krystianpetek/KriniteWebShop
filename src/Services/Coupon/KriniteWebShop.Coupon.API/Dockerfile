#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Coupon/KriniteWebShop.Coupon.API/KriniteWebShop.Coupon.API.csproj", "Services/Coupon/KriniteWebShop.Coupon.API/"]
RUN dotnet restore "Services/Coupon/KriniteWebShop.Coupon.API/KriniteWebShop.Coupon.API.csproj"
COPY . .
WORKDIR "/src/Services/Coupon/KriniteWebShop.Coupon.API"
RUN dotnet build "KriniteWebShop.Coupon.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KriniteWebShop.Coupon.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KriniteWebShop.Coupon.API.dll"]