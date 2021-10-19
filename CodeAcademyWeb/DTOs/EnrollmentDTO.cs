using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAcademyWeb.DTOs
{
	public class EnrollmentDTO
	{
		public long Id { get; set; }
		public long StudentId { get; set; }
		public string StudentFirstname { get; set; }
		public string StudentLastname { get; set; }
		public long CourseEditionId { get; set; }
		public string CourseEditionCode { get; set; }
		public string CourseEditionCourseTitle { get; set; }
		public string EnrollmentDate { get; set; }
		public string StudentEvaluation { get; set; }
		public string StudentFeedback { get; set; }
	}
}
