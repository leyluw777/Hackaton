using HackatonCode8.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackatonCode8.Infrastructure.Persistence
{
	public class AppDbContextInitializer
	{
		private readonly AppDbContext _dbContext;
		private readonly UserManager<AppUser> _userManager;
		private readonly ILogger<AppDbContextInitializer> _logger;

		public AppDbContextInitializer(AppDbContext dbContext, UserManager<AppUser> userManager, ILogger<AppDbContextInitializer> logger)
		{
			_dbContext = dbContext;
			_userManager = userManager;
			_logger = logger;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="AppDbContextInitialiser"/> class.
		/// </summary>
		/// <param name="dbContext">The application's database context.</param>
		/// <param name="logger">The logger for logging initialization errors.</param>


		/// <summary>
		/// Initializes the application's database asynchronously.
		/// </summary>
		/// <returns>A task representing the asynchronous initialization operation.</returns>
		public async Task InitializeAsync()
		{
			try
			{
				if (_dbContext.Database.IsSqlServer())

				{
					await _dbContext.Database.MigrateAsync();
					await SeedAsync();

				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while initializing the database.");
				throw ex;
			}
		}



		public async Task SeedAsync()
		{
			try
			{
				await TrySeedAsync();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occured while seeding the database");
				throw;
			}
		}

		public async Task TrySeedAsync()
		{

			AppUser admin = new AppUser { UserName = "admin", Email = "admin123@gmail.com"  };



			// Default User

			if (_userManager.Users.FirstOrDefault(u => u.UserName == admin.UserName) == null)
			{

				var a = await _userManager.CreateAsync(admin, "Admin123!");


				await _userManager.AddToRoleAsync(admin, "Admin");


			}
		}
	}
}
