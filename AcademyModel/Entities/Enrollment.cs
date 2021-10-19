using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyModel.Entities
{
	public class Enrollment
	{
		public long Id { get; set; }
		public long StudentId { get; set; }
		public Student Student { get; set; }
		public long CourseEditionId { get; set; }
		public CourseEdition CourseEdition { get; set; }
		public LocalDate EnrollmentDate { get; set; }
		public string StudentEvaluation { get; set; }
		public string StudentFeedback { get; set; }
	}
}
