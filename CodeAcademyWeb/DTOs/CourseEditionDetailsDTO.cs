using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAcademyWeb.DTOs
{
	public class CourseEditionDetailsDTO
	{
		public long Id { get; set; }
		public string Code { get; set; }
		public string Description { get; set; }
		public string StartDate { get; set; } 
		public string FinalizationDate { get; set; } 
		public decimal RealPrice { get; set; }
		public long CourseId { get; set; }
		public string CourseTitle { get; set; }
		public long InstructorId { get; set; }
		public string InstructorFullName { get; set; }
		public string InstructorFirstname { get; set; }
		public string InstructorLastname { get; set; }
	}
}
