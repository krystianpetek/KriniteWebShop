using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KriniteWebShop.Order.API;

public static class WebApplicationExtensions
{
	static int attempt = 0;
	public static async Task<IApplicationBuilder> MigrateDatabaseAsync<TContext>(this IApplicationBuilder app, Action<TContext, IServiceProvider> seeder) where TContext : DbContext
	{
		var serviceProvider = app.ApplicationServices.CreateScope().ServiceProvider;
		var context = serviceProvider.GetRequiredService<TContext>();
		var logger = serviceProvider.GetRequiredService<ILogger<TContext>>();

		try
		{
			logger.LogInformation("Seed database {DbContextName} are started.", typeof(TContext).Name);

			seeder(context, serviceProvider);

			logger.LogInformation("Seed database {DbContextName} are finished.", typeof(TContext).Name);
		}
		catch (SqlException ex)
		{
			logger.LogError(ex, "Error occured while seeding database.");
			if (attempt < 1)
			{
				await Task.Delay(10000);
				attempt++;
				await MigrateDatabaseAsync<TContext>(app, seeder);
			}
		}

		return app;
	}
}
