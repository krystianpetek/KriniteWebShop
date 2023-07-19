using KriniteWebShop.Order.Infrastructure.Email;
using KriniteWebShop.Order.Infrastructure.Persistance;
using KriniteWebShop.Order.Infrastructure.Repositories;
using KriniteWebShop.Order.Application.Models;
using KriniteWebShop.Order.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using KriniteWebShop.Order.Domain.Repository;
using KriniteWebShop.Order.Application.Contracts.Infrastructure;

namespace KriniteWebShop.Order.Infrastructure;

public static class InfrastructureServiceCollection
{
	public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<OrderContext>(options =>
		{
			string connectionString = configuration.GetConnectionString("OrderDb");
			//options.UseMySql(connectionString, new MySqlServerVersion(new Version("8,0,29")));
			options.UseSqlServer(connectionString);
		});

		services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));
		services.AddScoped<IOrderRepository, OrderRepository>();

		services.Configure<EmailSettings>(email => configuration.GetRequiredSection("EmailSettings"));
		services.AddTransient<IEmailService, EmailService>();

		return services;
	}
}