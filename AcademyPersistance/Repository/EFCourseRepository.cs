
using NodaTime;
using AcademyModel.Entities;
using AcademyModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademyEFPersistance.EFContext;
using Microsoft.EntityFrameworkCore;

namespace AcademyEFPersistance.Repository
{
	public class EFCourseRepository : EFCrudRepository<Course, long>, ICourseRepository
	{
	public EFCourseRepository(AcademyContext ctx) : base(ctx){ }

		public override Course FindById(long id)
		{
			return ctx.Courses.Include( c => c.Area).SingleOrDefault( c => c.Id == id);
		}
		public IEnumerable<Course> FindCourseByArea(long idArea)
		{
			return ctx.Courses.Where(c => c.AreaId == idArea);
		}

		public IEnumerable<Course> FindCourseByCourseDescriptionLike(string description)
		{
			return ctx.Courses.Where(c => c.Description.Contains(description));
		}

		public IEnumerable<Course> FindCourseByTitleLike(string title)
		{
			return ctx.Courses.Where(c => c.Title.Contains(title));
		}

        public IEnumerable<Course> GetLastCourses(int n)
        {
			return ctx.Courses.OrderBy(c => c.CreationDate).Take(n);
        }
    }
}
