using HackatonCode8.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackatonCode8.Domain.Entities
{
	public class Education : BaseEntity
	{
		public string UniversityName { get; set; }
		public string Specialty { get;set; }
		public string CurrentGraduateLevel { get; set; }
		public double GPA { get; set; }

		public string UserId { get; set; }
		public User User { get; set; }

	}
}
