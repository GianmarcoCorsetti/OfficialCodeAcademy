using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAcademyWeb.DTOs
{
	public class CourseDTO
	{
		public long Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int Duration { get; set; }
		public decimal BasePrice { get; set; }
		public string Syllabus { get; set; }
		public int Level { get; set; }
		public long AreaId { get; set; }
		public string AreaName { get; set; }
		public bool GrantsCertification { get; set; }
		public string CreationDate { get; set; }
	}
}
