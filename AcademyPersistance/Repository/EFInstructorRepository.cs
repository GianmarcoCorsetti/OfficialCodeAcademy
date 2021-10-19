
using AcademyEFPersistance.EFContext;
using AcademyModel;
using AcademyModel.Entities;
using AcademyModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEFPersistance.Repository
{
	public class EFInstructorRepository : EFCrudRepository<Instructor, long>, IInstructorRepository
	{
		public EFInstructorRepository(AcademyContext ctx) : base(ctx)
		{
			// CTRL + . per crearlo in auto
		}

		public IEnumerable<Instructor> FindInstructorByCompetence(long idSkill, Level? level)
		{
			IEnumerable<Instructor> instructors = new List<Instructor>();
			if (level == null)
			{
				instructors = ctx.Instructors.Where(i => i.Competences.Any(c => c.SkillId == idSkill));
			}
			else
			{
				instructors =ctx.Instructors.Where(i => i.Competences.Any(c => c.Level >= level && c.SkillId == idSkill));
			}
			return instructors;
		}
	}
}
