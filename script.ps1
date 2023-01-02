docker pull mcr.microsoft.com/mssql/server

docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=NotAll0wedForPublic" -p 8720:1433 -d --name webshop-catalog-sql mcr.microsoft.com/mssql/server:latest

dotnet ef migrations add Initial