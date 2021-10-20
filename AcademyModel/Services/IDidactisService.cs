//using SchoolModel.BuisnessLogic;
using AcademyModel.BuisnessLogic;
using AcademyModel.Entities;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyModel.Services
{
	public interface IDidactisService
	{
		


		CourseEdition CreateCourseEdition(CourseEdition e);
		IEnumerable<Course> FindCourseByTitleLike(string title);
		IEnumerable<Course> FindCourseByCourseDescriptionLike(string description);
		IEnumerable<Course> FindCourseByArea(long idArea);
		IEnumerable<Course> GetAllCourses();
		IEnumerable<Course> GetLastCourses(int n);
		Course GetCourseById(long id);
		Course CreateCourse(Course c);
		Course UpdateCourse(Course c);
		void DeleteCourse(Course c);
		void DeleteCourse(long id);

		IEnumerable<CourseEdition> GetAllEditions();
		CourseEdition GetEditionById(long id);
		CourseEdition EditCourseEdition(CourseEdition e);
		void DeleteCourseEdition(long id);
		public IEnumerable<CourseEdition> GetEditionsByCourseId(long id);
		IEnumerable<CourseEdition> Search(EditionSearchInfo info);


		

		IEnumerable<Lesson> FindLessonForEditionId(long id);
		IEnumerable<Lesson> FindLessonInRange(LocalDate start, LocalDate end);

		IEnumerable<Area> GetAllAreas();


		
	}

}
