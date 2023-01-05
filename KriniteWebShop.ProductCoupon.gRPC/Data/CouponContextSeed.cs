using Npgsql;

namespace KriniteWebShop.ProductCoupon.gRPC.Data;

public static class CouponDatabaseSeed
{
    public static void SeedData(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        IConfiguration configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
        ILoggerFactory loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();
        var logger = loggerFactory.CreateLogger("CouponDbSeeder");

        try
        {
            logger.LogInformation("Seed database are started.");

            string connectionString = configuration?.GetRequiredSection("ConnectionStrings")?.GetValue<string>("CouponDb")
            ?? throw new ArgumentNullException(nameof(configuration));

            using NpgsqlConnection npgsqlConnection = new NpgsqlConnection(connectionString);
            npgsqlConnection.Open();

            using NpgsqlCommand npgsqlCommand = npgsqlConnection.CreateCommand();

            npgsqlCommand.CommandText = "DROP TABLE IF EXISTS Coupon";
            npgsqlCommand.ExecuteNonQuery();
            npgsqlCommand.CommandText = "CREATE TABLE Coupon (" +
                "Id SERIAL PRIMARY KEY, " +
                "ProductName varchar(24) NOT NULL, " +
                "Description varchar(255), " +
                "Amount int);";
            npgsqlCommand.ExecuteNonQuery();
            npgsqlCommand.CommandText = "INSERT INTO Coupon (ProductName, Description, Amount) VALUES ('Stadium', 'Stadium Discount', 2000)";
            npgsqlCommand.ExecuteNonQuery();
            npgsqlCommand.CommandText = "INSERT INTO Coupon(ProductName, Description, Amount) VALUES('Bling-Bling King', 'Bling-Bling King Discount', 150)";
            npgsqlCommand.ExecuteNonQuery();

            logger.LogInformation("Seed database are finished.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, "Error occurred while seeding database.");
        }
    }
}
