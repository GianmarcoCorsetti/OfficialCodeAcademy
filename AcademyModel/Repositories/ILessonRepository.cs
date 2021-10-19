using AcademyModel.Entities;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyModel.Repositories
{
	public interface ILessonRepository : ICrudRepository<Lesson, long>
	{
		IEnumerable<Lesson> FindLessonForEditionId(long id);
		IEnumerable<Lesson> FindLessonInRange(LocalDate start, LocalDate end);
	}
}
