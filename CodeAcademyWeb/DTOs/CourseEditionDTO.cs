using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAcademyWeb.DTOs
{
	public class CourseEditionDTO
	{
		public long Id { get; set; }
		public string Code { get; set; }
		public string Description { get; set; }
		public decimal RealPrice { get; set; }
	}
}
