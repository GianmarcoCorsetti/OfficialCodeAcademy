using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyModel.Entities
{
	public class Person
	{
		public long Id { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public LocalDate DateOfBirth { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public ICollection<Competence> Competences { get; set; }
	}
}
