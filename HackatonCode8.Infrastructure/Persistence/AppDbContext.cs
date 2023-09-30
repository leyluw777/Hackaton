using HackatonCode8.Application.Common.Interfaces;
using HackatonCode8.Domain.Entities;
using HackatonCode8.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HackatonCode8.Infrastructure.Persistence
{
	public class AppDbContext : IdentityDbContext<AppUser>, IApplicationDbContext
	{
		
		private readonly UserManager<AppUser> _userManager;


		public AppDbContext(DbContextOptions options) : base(options)
		{
			
		}


		public DbSet<User> Users { get; set; }
		public DbSet<Applicant> Applicants { get; set; }
		public DbSet<Interest> Interests { get; set; }
		public DbSet<Education> Education { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{

			//builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			builder.Entity<User>().HasOne(x => x.Interest)
								  .WithOne(x => x.User)
								  .HasForeignKey<Interest>(y => y.UserId)
								  .OnDelete(DeleteBehavior.Restrict)
							  .IsRequired(false);

			builder.Entity<User>().HasOne(x => x.Education)
			  .WithOne(x => x.User)
			  .HasForeignKey<Education>(y => y.UserId)
			  .OnDelete(DeleteBehavior.Restrict)
							  .IsRequired(false);

			builder.Entity<Applicant>().HasOne(x => x.User)
					   .WithMany(x => x.Applicants)
					   .HasForeignKey(y => y.UserId)
					   .OnDelete(DeleteBehavior.Restrict)
							  .IsRequired(false);



			base.OnModelCreating(builder);
		}

		/// <summary>
		/// Configures the options for the database context.
		/// </summary>
		/// <param name="optionsBuilder">The options builder used to configure the options.</param>

		/// <summary>
		/// Saves all changes made in this context to the database asynchronously.
		/// </summary>
		/// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
		/// <returns>A task representing the asynchronous save operation. The task result contains the number of state entries written to the database.</returns>
		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			return await base.SaveChangesAsync(cancellationToken);
		}

	}
}
