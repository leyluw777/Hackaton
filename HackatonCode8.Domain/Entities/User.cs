using HackatonCode8.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackatonCode8.Domain.Entities
{
	public class User : AppUser
	{
		public string Name { get; set; }
		public DateTime BirthDate { get; set; }
		public bool Gender { get; set; }
		public string Email { get; set; }	
		public string Password { get; set; }
		public DateTime AppointmentDate { get; set; }
		public string DeviceId { get; set; }

		public Education Education { get; set; }
		public int EducationId { get; set; }

		public List<Applicant> Applicants { get; set; }
		public int InterestId { get; set; }
		public Interest Interest { get; set; }
	}
}
