using HackatonCode8.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackatonCode8.Domain.Entities
{
	public class Applicant : BaseEntity
	{
		public string Name { get; set; }
		public bool Status { get; set; }

		public User User { get; set; }	
		public string UserId { get; set; }

	}
}
