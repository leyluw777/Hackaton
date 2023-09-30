using HackatonCode8.Domain.Common;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackatonCode8.Domain.Entities
{
	public class Interest : BaseEntity
	{
		public string EnjoyedSubjects { get; set; }
		public string Hobbies { get; set; }
		public string CareerEnvisionBusiness { get; set; }
		public string UserId { get; set; }
		public User User { get; set; }	
	}
}
