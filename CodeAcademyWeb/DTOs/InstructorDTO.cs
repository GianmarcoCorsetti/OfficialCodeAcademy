using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAcademyWeb.DTOs
{
	public class InstructorDTO
	{
		public long Id { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public string DateOfBirth { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public bool IsContractor { get; set; }
		public decimal PayRate { get; set; }
	}
}
