
using AcademyEFPersistance.EFContext;
using AcademyModel.Entities;
using AcademyModel.Repositories;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEFPersistance.Repository
{
	public class EFLessonRepository : EFCrudRepository<Lesson, long>, ILessonRepository
	{
		public EFLessonRepository(AcademyContext ctx) : base(ctx)
		{
		}

		public IEnumerable<Lesson> FindLessonForEditionId(long id)
		{
			return ctx.Lessons.Where(l => l.CourseEditionId == id);
		}

		public IEnumerable<Lesson> FindLessonInRange(LocalDate start, LocalDate end)
		{
			return ctx.Lessons.Where(l => l.Start.Date >= start && l.End.Date <= end);
		}
	}
}
