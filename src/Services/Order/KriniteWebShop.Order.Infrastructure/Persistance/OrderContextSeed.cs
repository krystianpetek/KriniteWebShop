﻿using KriniteWebShop.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KriniteWebShop.Order.Infrastructure.Persistance;
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

	private static IEnumerable<OrderEntity> SeedOrders()
	{
		return new List<OrderEntity>
		{
			new OrderEntity(Guid.Parse("d4482b07-9c4c-443a-b5ab-08daf19928d7"))
			{
				UserName = "krystianpetek2",
				FirstName= "Krystian",
				LastName = "Petek",
				EmailAddress = "krystianpetek2@gmail.com",
				AddressLine = "Kraków",
				Country = "Polska",
				TotalPrice = 2199,
				ZipCode = "31-599",
				State = "Małopolska",
				PaymentMethod = PaymentMethod.MobilePayments
			}
		};
	}
}
