using KriniteWebShop.ProductOrder.Application.Contracts.Infrastructure;
using KriniteWebShop.ProductOrder.Application.Contracts.Persistance;
using KriniteWebShop.ProductOrder.Application.Models;
using KriniteWebShop.ProductOrder.Domain.Common;
using KriniteWebShop.ProductOrder.Infrastructure.Email;
using KriniteWebShop.ProductOrder.Infrastructure.Persistance;
using KriniteWebShop.ProductOrder.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KriniteWebShop.ProductOrder.Infrastructure;

public static class InfrastructureDependencyInjection
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