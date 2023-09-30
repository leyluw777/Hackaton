using System.Reflection;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;


namespace HackatonCode8.Application
{
	public static class ConfigureServices
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
		{

			services.AddMediatR(Assembly.GetExecutingAssembly());

			services.AddAutoMapper(Assembly.GetExecutingAssembly());

			//services.AddFluentValidationAutoValidation();

			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());




			return services;
		}
	}
}
