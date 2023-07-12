using FluentValidation;
using KriniteWebShop.Order.Application.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace KriniteWebShop.Order.Application;
public static class ApplicationDependencyInjection
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		services.AddAutoMapper(Assembly.GetExecutingAssembly());
		services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
		services.AddMediatR(Assembly.GetExecutingAssembly());
		services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));
		services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

		return services;
	}
}
