using AcademyModel.Entities;

using AcademyModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using AcademyModel.BuisnessLogic;
using NodaTime;
using AcademyEFPersistance.EFContext;
using AcademyModel.BusinessLogic;

namespace AcademyEFPersistance.Repository
{
	public class EFEditionRepository : EFCrudRepository<CourseEdition, long>, IEditionRepository
	{
		public EFEditionRepository(AcademyContext ctx) : base(ctx)
		{
			
		}
		// corsi futuri | corisi passati | corsi in range tra a e b | --checked
		// corsi futuri su id instructor | corisi passati su id instructor | corsi in range tra a e b su id instructor |
		// ricerca like su titolo e in range tra a e b --checked
		public override CourseEdition FindById(long id)
		{
			return ctx.CourseEditions.Include( e => e.Course ).Include( e => e.Instructor ).SingleOrDefault ( e => e.Id == id );
		}

		public IEnumerable<CourseEdition> Search(EditionSearchInfo info)
		{
			LocalDate today = LocalDate.FromDateTime(DateTime.Now);
			IQueryable<CourseEdition> editions = ctx.CourseEditions;

			if (info.Start != null || info.End != null)
			{
				if (info.Start != null)
				{
					editions = editions.Where(e => e.StartDate >= info.Start);
				}
				if (info.End != null)
				{
					editions = editions.Where(e => e.FinalizationDate <= info.End);
				}
			}			
			else
			{
				if (info.InTheFuture == true)
				{
					editions = editions.Where(e => e.StartDate > today);
				}
				else if (info.InThePast == true)
				{
					editions = editions.Where(e => e.StartDate < today);
				}
			}

			if (info.InstructorId != null)
			{
				editions = editions.Where(e => e.InstructorId == info.InstructorId );
			}

			if (!String.IsNullOrEmpty(info.TitleLike))
			{
				editions = editions.Where(e => e.Course.Title.Contains(info.TitleLike));
			}
			return editions;
		}

		public IEnumerable<CourseEdition> GetEditionsByCourseId(long id)
		{
			return ctx.CourseEditions.Where(e => e.CourseId == id);
		}

        public IEnumerable<CourseEdition> SearchDetailed(EditionSearchInfoDetails infoDetailed)
        {
			LocalDate today = LocalDate.FromDateTime(DateTime.Now);
			IQueryable<CourseEdition> editions = ctx.CourseEditions;
			// controllo sull'intervallo di date
			if (infoDetailed.StartDate != null || infoDetailed.EndDate != null)
			{
				if (infoDetailed.StartDate != null)
				{
					editions = editions.Where(e => e.StartDate >= infoDetailed.StartDate);
				}
				if (infoDetailed.EndDate != null)
				{
					editions = editions.Where(e => e.FinalizationDate <= infoDetailed.EndDate);
				}
			}
			// controllo sul codice
			if (infoDetailed.Code != null)
            {
				editions = editions.Where(e => e.Code == infoDetailed.Code);
            }
			// controllo sul prezzo 
			if( infoDetailed.MaxPrice != null || infoDetailed.MinPrice != null)
            {
				if(infoDetailed.MinPrice != null)
                {
					editions = editions.Where(e => e.RealPrice >= infoDetailed.MinPrice);
                }
				if(infoDetailed.MinPrice != null)
                {
					editions = editions.Where(e => e.RealPrice <= infoDetailed.MaxPrice);
				}
            }
			// controllo sul titolo del corso di cui possono fare parte le edizioni
			if( infoDetailed.CourseTitle != null)
            {
				editions = editions.Where(e => e.Course.Title.Contains(infoDetailed.CourseTitle));
            }
			// controllo sul Nome dell'istruttore
			if( infoDetailed.InstructorFirstname != null)
            {
				editions = editions.Where(e => e.Instructor.Firstname == infoDetailed.InstructorFirstname || e.Instructor.Firstname.Contains(infoDetailed.InstructorFirstname));
            }
			// controllo sul cognome dell'istruttore
			if( infoDetailed.InstructorLastname != null)
            {
				editions = editions.Where(e => e.Instructor.Lastname == infoDetailed.InstructorLastname || e.Instructor.Lastname.Contains(infoDetailed.InstructorLastname));
			}
			// controllo più gnerale riguardante il nome completo per avere più possibilità di trovare il nome dell'insegnante
			if(infoDetailed.InstructorFullName != null){
				string[] nomeScomposto = infoDetailed.InstructorFullName.Split(" ");
				editions = editions.Where(e => 
				(e.Instructor.Firstname == nomeScomposto[0] || e.Instructor.Lastname.Contains(nomeScomposto[0]))
				||(e.Instructor.Lastname == nomeScomposto[1] || e.Instructor.Lastname.Contains(nomeScomposto[1])));
			}
			return editions;
		}
    }
}
