using AcademyEFPersistance.EFContext;
using AcademyModel.BuisnessLogic;
using AcademyModel.BusinessLogic;
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
		public IEnumerable<CourseEdition> FindEditions( EditionSearchInfo info )
		{
			IntegrityCheck(info);
			return editionRepo.Search(info).ToList();
		}

		public IEnumerable<CourseEdition> FindEditionsDetailed (EditionSearchInfoDetails infoDetails)
        {
			IntegrityCheckDetailed(infoDetails);
			return editionRepo.SearchDetailed(infoDetails).ToList();
        }
		public IEnumerable<CourseEdition> GetEditionsByCourseId(long id)
        {
			return editionRepo.GetEditionsByCourseId(id);
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
		private void IntegrityCheck(EditionSearchInfo info)
		{
			if (info.Start != null || info.End != null)
			{
				if (info.InTheFuture != null || info.InThePast != null)
				{
					throw new BuinsnessLogicException("I criteri di ricerca non possono comprendere allo stesso tempo date e richiesta su futuro e passato");
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
		}

		private void IntegrityCheckDetailed(EditionSearchInfoDetails infoDetailed)
        {
			// controllo che la StartDate sia prima della EndDate
			if (infoDetailed.StartDate != null && infoDetailed.EndDate != null)
			{
				if (infoDetailed.StartDate > infoDetailed.EndDate)
				{
					throw new BuinsnessLogicException("La data di inizio non può essere successiva a quella di fine");
				}
			}
			// controllo che il minPrice e il maxPrice siano coerenti
			if( infoDetailed.MinPrice != null && infoDetailed.MinPrice != null)
            {
				if(infoDetailed.MinPrice > infoDetailed.MinPrice)
                {
					throw new BuinsnessLogicException("Il costo massimo non può essere più grande del costo minimo");
                }
            }
			// controllo sul fullName
			if( infoDetailed.InstructorFullName != null)
            {
				if (infoDetailed.InstructorFullName.Split(" ").Length > 2)
				{
					throw new BuinsnessLogicException("Il nome completo non può avere più di due parole");

				}
			}
		}

		public IEnumerable<CourseEdition> GetEditionsByInstructorId(long id) // Funziona
		{
            var info = new EditionSearchInfo
            {
                InstructorId = id
            };
            return editionRepo.Search(info).ToList();
        }

		public IEnumerable<CourseEdition> GetEditionsByIntervall(LocalDate start, LocalDate end)
		{
            var info = new EditionSearchInfo
            {
                Start = start,
                End = end
            };
            return editionRepo.Search(info).ToList();
		}

		public IEnumerable<CourseEdition> GetEditionsByFutureOrPast(bool isFuture)
		{
			// se isFuture è vero	: cerco edizioni future
			// se isFuture è falso	: cerco edizioni passate
			var info = new EditionSearchInfo();
			if (isFuture)
			{
				info.InTheFuture = true;

			}
			else
			{
				info.InThePast = true;
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

        public IEnumerable<CourseEdition> GetAllEditions()
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
