using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyModel.Entities
{
	public class Student : Person
	{
		public bool IsEmployee { get; set; }
		public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
	}
}
