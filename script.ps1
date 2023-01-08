KriniteWebShop.ProductCatalog.API

docker pull mcr.microsoft.com/mssql/server

docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=NotAll0wedForPublic" -p 8720:1433 -d --name webshop-productcatalog-sql mcr.microsoft.com/mssql/server:latest

dotnet ef migrations add Initial



KriniteWebShop.ProductCatalog.NoSQL.API

docker pull mongo
docker run -d -p 27001:27017 --name webshop-productcatalog-mongo mongo
docker exec -it webshop-catalog-mongo /bin/bash

	mongosh
	show dbs
	use ProductDb
	db.Products.insertMany(
		[
                {
                    'Name' :'Kayak',
                    'Description' : 'A boat for one person',
                    'Category' : 'Watersports',
                    'Price' : 275
                },

                {
                    'Name' : 'Lifejacket',
                    'Description' : 'Protective and fashionable',
                    'Category' : 'Watersports',
                    'Price' : 48.95
                },
                {
                    'Name' : 'Soccer Ball',
                    'Description' : 'FIFA-approved size and weight',
                    'Category' : 'Soccer',
                    'Price' : 19.50
                },
                {
                    'Name' : 'Corner Flags',
                    'Description' : 'Give your playing field a professional touch',
                    'Category' : 'Soccer',
                    'Price' : 34.95
                },
                {
                    'Name' : 'Stadium',
                    'Description' : 'Flat-packed 35,000-seat stadium',
                    'Category' : 'Soccer',
                    'Price' : 79500
                },
                {
                    'Name' : 'Thinking Cap',
                    'Description' : 'Improve brain efficiency by 75%',
                    'Category' : 'Chess',
                    'Price' : 16
                },
                {
                    'Name' : 'Unsteady Chair',
                    'Description' : 'Secretly give your opponent a disadvantage',
                    'Category' : 'Chess',
                    'Price' : 29.95
                },
                {
                    'Name' : 'Human Chess Board',
                    'Description' : 'A fun game for the family',
                    'Category' : 'Chess',
                    'Price' : 75
                },
                {
                    'Name' : 'Bling-Bling King',
                    'Description' : 'Gold-plated, diamond-studded King',
                    'Category' : 'Chess',
                    'Price' : 1200
                }
		]
	)
    db.Products.find({}).pretty() # show all data in table
    show databases
    show collections
    db.Products.remove({}) # remove all records

docker pull mongoclient/mongoclient
docker run -d -p 3001:3000 --name webshop-mongoclient mongoclient/mongoclient



KriniteWebShop.ProductCart.API

docker pull redis
docker run -d -p 6301:6379 --name webshop-productcart-redis redis
docker exec -it webshop-productcart-redis /bin/bash

    redis-cli
    set name Krystian
    get name



KriniteWebShop.ProductCoupon.API

docker pull postgres
docker run -d -p 5401:5432 --name webshop-productcoupon-postgres -e POSTGRES_PASSWORD=NotAll0wedForPublic postgres

docker pull dpage/pgadmin4
docker run -d -p 5402:80 -e PGADMIN_DEFAULT_EMAIL=admin@admin.com -e PGADMIN_DEFAULT_PASSWORD=NotAll0wedForPublic --name webshop-pgadmin4 dpage/pgadmin4
    CREATE TABLE Coupon(
        ID SERIAL PRIMARY KEY NOT NULL,
		ProductName VARCHAR(24) NOT NULL,
		Description Text,
		Amount INT
    );
    INSERT INTO Coupon (ProductName, Description, Amount) VALUES ('Stadium','Stadium Discount', 2000);
    INSERT INTO Coupon (ProductName, Description, Amount) VALUES ('Bling-Bling King','Bling-Bling King Discount', 150);
    


KriniteWebShop.ProductOrder.API

docker pull mysql
docker run -d -p 3301:3306 --name webshop-productorder-mysql -e MYSQL_ROOT_PASSWORD=NotAll0wedForPublic mysql
docker exec -it mk-mysql /bin/bash
mysql -u root -p NotAll0wedForPublic

# finally run another MsSQL
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=NotAll0wedForPublic" -p 8725:1433 -d --name webshop-productorder-sql mcr.microsoft.com/mssql/server:latest