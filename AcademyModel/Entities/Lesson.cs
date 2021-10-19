using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyModel.Entities
{
	public	class Lesson
	{
		public long Id { get; set; }
		public string Subject { get; set; }
		public long CourseEditionId { get; set; }
		public CourseEdition CourseEdition { get; set; }
		public long ClassroomId { get; set; }
		public Classroom Classroom { get; set; }
		public LocalDateTime Start { get; set; }
		public LocalDateTime End { get; set; }
	}
}
