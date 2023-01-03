KriniteWebShop.ProductCatalog.API

docker pull mcr.microsoft.com/mssql/server

docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=NotAll0wedForPublic" -p 8720:1433 -d --name webshop-catalog-sql mcr.microsoft.com/mssql/server:latest

dotnet ef migrations add Initial



KriniteWebShop.ProductCatalog.Mongo.API

docker pull mongo
docker run -d -p 27001:27017 --name webshop-catalog-mongo mongo
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