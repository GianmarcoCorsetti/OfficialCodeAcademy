using AcademyModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyModel.Repositories
{
	public interface ICourseRepository : ICrudRepository<Course, long>
	{
		IEnumerable<Course> FindCourseByTitleLike(string title);
		IEnumerable<Course> FindCourseByCourseDescriptionLike(string description);
		IEnumerable<Course> FindCourseByArea(long idArea);
		IEnumerable<Course> GetLastCourses(int n);
	}
}
