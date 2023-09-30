using HackatonCode8.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HackatonCode8.Application.Common.Interfaces
{
	public interface IApplicationDbContext
	{
		
		public DbSet<User> Users { get; set; }
		public DbSet<Applicant> Applicants { get; set; }
		public DbSet<Interest> Interests { get; set; }
		public DbSet<Education> Education { get; set; }




		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}
