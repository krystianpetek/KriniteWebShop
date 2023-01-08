using KriniteWebShop.ProductOrder.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KriniteWebShop.ProductOrder.Infrastructure.Persistance;
public static class OrderContextSeed
{
    public static async Task InitialMigrateAsync(this OrderContext orderContext, ILogger<OrderContext> logger)
    {
        orderContext.Database.Migrate();
        if (!orderContext.Orders.Any())
        {
            await orderContext.AddRangeAsync(SeedOrders());
            await orderContext.SaveChangesAsync();
            logger.LogInformation("Seeding database {0} ended successfully.", typeof(OrderContext).Name);
        }
    }

    private static IEnumerable<Order> SeedOrders()
    {
        return new List<Order>
        {
            new Order
            {
                UserName = "krystianpetek2",
                FirstName= "Krystian",
                LastName = "Petek",
                EmailAddress = "krystianpetek2@gmail.com",
                AddressLine = "Kraków",
                Country = "Poland",
                TotalPrice = 1331 ,
            }
        };
    }
}
