using HackatonCode8.Application.Common.Interfaces;
using HackatonCode8.Application.Common.JWT;
using HackatonCode8.Domain.Identity;
using HackatonCode8.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Microsoft.AspNetCore.Identity;
using HackatonCode8.Infrastructure.Persistence.Services;

namespace HackatonCode8.Infrastructure
{
	public static class ConfigureServices
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			
			// Registers the AppDbContext as a service with the specified connection string
			services.AddDbContext<IApplicationDbContext, AppDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("defaultConnectionString")));


			services.AddMediatR(typeof(IApplicationDbContext));

			// Registers IApplicationDbContext as a scoped service, using the AppDbContext implementation
			//services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<AppDbContext>());

			// Configures identity services using AppUser and AppRole, with AppDbContext as the store
			services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();

			services.AddScoped<ITokenHandler, TokenHandler>();

			// Adds the AppDbContextInitialiser as a scoped service
			services.AddScoped<AppDbContextInitializer>();


			// Adds DateTimeService as a transient service for providing current date and time
			services.AddTransient<IDateTime, DateTimeService>();

			//// Register EmailService and TelegramService as scoped services
			//services.AddScoped<IEmailService, EmailService>();
			//services.AddScoped<ITelegramService, TelegramService>();
			services.AddScoped<ICurrentUser, CurrentUserService>();
			//services.AddIdentity<AppUser, AppRole>();





			

			return services;
		}
	}
}