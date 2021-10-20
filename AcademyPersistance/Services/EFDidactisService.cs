using AcademyEFPersistance.EFContext;
using AcademyModel.BuisnessLogic;
using AcademyModel.Entities;
using AcademyModel.Exceptions;
using AcademyModel.Repositories;
using AcademyModel.Services;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEFPersistence.Services
{
	public class EFDidactisService : IDidactisService
	{
		private IInstructorRepository instructorRepo;
		private ICourseRepository courseRepo;
		private IEditionRepository editionRepo;
		private ILessonRepository lessonRepo;
		private IAreaRepository areaRepo;

		private AcademyContext ctx;
		public EFDidactisService(ICourseRepository courseRepo,IEditionRepository editionRepo, IInstructorRepository instructorRepo,  IAreaRepository areaRepo, AcademyContext ctx)
		{
			this.courseRepo = courseRepo;
			this.editionRepo = editionRepo;
			this.instructorRepo = instructorRepo;
			this.areaRepo = areaRepo;
			this.ctx = ctx;
		}

		#region Course
		public IEnumerable<Course> FindCourseByTitleLike(string title)
		{
			return courseRepo.FindCourseByTitleLike(title);
		}
		public IEnumerable<Course> FindCourseByCourseDescriptionLike(string description)
		{
			return courseRepo.FindCourseByCourseDescriptionLike(description);
		}
		public IEnumerable<Course> FindCourseByArea(long idArea)
		{
			return courseRepo.FindCourseByArea(idArea);
		}
		public IEnumerable<Course> GetAllCourses()
		{
			return courseRepo.GetAll();
		}
		public Course GetCourseById(long id)
		{
			return courseRepo.FindById(id);
		}
		public Course CreateCourse(Course c)
		{
			var res = courseRepo.Create(c);
			ctx.SaveChanges();
			return res;
		}
		public void DeleteCourse(Course c)
		{
			courseRepo.Delete(c);
			ctx.SaveChanges();
		}
		public void DeleteCourse(long id)
		{
			courseRepo.Delete(id);
			ctx.SaveChanges();
		}
		public IEnumerable<CourseEdition> GetEditionsByCourseId(long id)
		{
			return editionRepo.GetEditionsByCourseId(id);
		}

		public Course UpdateCourse(Course c)
		{
			var res = courseRepo.Update(c);
			ctx.SaveChanges();
			return res;
		}

		public IEnumerable<Course> GetLastCourses(int n)
		{
			return courseRepo.GetLastCourses(n);
		}
		#endregion

		#region CourseEditions
		public IEnumerable<CourseEdition> GetAllEditions()
		{
			return editionRepo.GetAll();
		}
		public CourseEdition GetEditionById(long id)
		{
			return editionRepo.FindById(id);
		}
		public CourseEdition CreateCourseEdition(CourseEdition e)
		{
			CheckCourse(e.CourseId);
			CheckInstructor(e.InstructorId);
			editionRepo.Create(e);
			ctx.SaveChanges();
			return e;
		}
		public CourseEdition EditCourseEdition(CourseEdition e)
		{
			CheckCourse(e.CourseId);
			CheckInstructor(e.InstructorId);
			CheckCourseEdition(e.Id);
			editionRepo.Update(e);
			ctx.SaveChanges();
			return e;
		}
		public void DeleteCourseEdition(long id)
		{
			var edition = CheckCourseEdition(id);
			editionRepo.Delete(edition);
			ctx.SaveChanges();
		}
		public IEnumerable<CourseEdition> Search(EditionSearchInfo info)
		{
			if (info.Start != null || info.End != null)
			{
				if (info.InTheFuture != null || info.InThePast != null)
				{
					throw new BuinsnessLogicException("I criteri di ricerca non possono comprende  allo stesso tempo date e richiesta su futuro e passato");
				}
			}

			if (info.Start != null && info.End != null)
			{
				if (info.Start > info.End)
				{
					throw new BuinsnessLogicException("La data di inizio non può essere successiva a quella di fine");
				}
			}

			if (info.InTheFuture == true && info.InThePast == true)
			{
				throw new BuinsnessLogicException("Non è possibile richiedere edizioni sia nel passatro che nel futuro");
			}
			return editionRepo.Search(info).ToList();
		}
		#endregion

		#region Lesson
		public IEnumerable<Lesson> FindLessonForEditionId(long id)
		{
			return lessonRepo.FindLessonForEditionId(id);
		}

		public IEnumerable<Lesson> FindLessonInRange(LocalDate start, LocalDate end)
		{
			return lessonRepo.FindLessonInRange(start, end);
		}
		#endregion
		
		public IEnumerable<Area> GetAllAreas()
		{
			return areaRepo.GetAll().ToList();
		}

		#region Helpers
		private Course CheckCourse(long id)
		{
			var course = courseRepo.FindById(id);
			if (course == null)
			{
				throw new EntityNotFoundException("L'id del corso non corrisponde ad un corso esistente", nameof(Course));
			}
			return course;
		}
		private Instructor CheckInstructor(long id)
		{
			var instructor = instructorRepo.FindById(id);
			if (instructor == null)
			{
				throw new EntityNotFoundException("L'id dell'istruttore non corrisponde ad un istruttore esistente", nameof(Instructor));
			}
			return instructor;
		}
		private CourseEdition CheckCourseEdition(long id)
		{
			var courseEdition = editionRepo.FindById(id);
			if (courseEdition == null)
			{
				throw new EntityNotFoundException("L'id dell'edizione non corrisponde ad un edizione esistente", nameof(CourseEdition));
			}
			return courseEdition;
		}

		


		#endregion

	}
}
