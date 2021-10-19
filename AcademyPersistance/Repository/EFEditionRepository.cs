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
			LocalDate today = LocalDate.FromDateTime(new DateTime());
			IEnumerable<CourseEdition> editions = new List<CourseEdition>();

			if (info.Start != null || info.End != null)
			{
				if (info.Start != null)
				{
					editions = ctx.CourseEditions.Where(e => e.StartDate >= info.Start);
				}
				if (info.End != null)
				{
					editions = ctx.CourseEditions.Where(e => e.FinalizationDate <= info.End);
				}
			}			
			else
			{
				if (info.InTheFuture == true)
				{
					editions = ctx.CourseEditions.Where(e => e.StartDate > today);
				}
				else if (info.InThePast == true)
				{
					editions = ctx.CourseEditions.Where(e => e.StartDate < today);
				}
			}

			if (info.InstructorId != null)
			{
				editions = editions.Where(e => e.Id == info.InstructorId );
			}

			if (!String.IsNullOrEmpty(info.TitleLike))
			{
				editions = editions.Where(e => e.Course.Title.Contains(info.TitleLike));
			}
			return editions;
		}
	}
}
