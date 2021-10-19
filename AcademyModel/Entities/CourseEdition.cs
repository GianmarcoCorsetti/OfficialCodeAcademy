using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyModel.Entities
{
	public class CourseEdition
	{
		public long Id { get; set; }
		public string Code { get; set; }
		public string Description { get; set; }
		public LocalDate StartDate { get; set; }
		public LocalDate FinalizationDate { get; set; }
		public decimal RealPrice { get; set; }
		public long CourseId { get; set; }
		public Course Course { get; set; }
		public long InstructorId { get; set; }
		public Instructor Instructor { get; set; }
		public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
	}
}
