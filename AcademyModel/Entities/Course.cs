using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyModel.Entities
{
	public class Course
	{
		public long Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int Duration { get; set; }
		public decimal BasePrice { get; set; }
		public string Syllabus { get; set; }
		public Level Level{ get; set; }
		public long AreaId { get; set; }
		public Area Area { get; set; }
		public bool GrantsCertification { get; set; }
		public LocalDate CreationDate { get; set; }
		public ICollection<CourseEdition> Editions { get; set; } = new List<CourseEdition>();
	}
}
