
using Microsoft.EntityFrameworkCore;
using AcademyModel.Entities;
using AcademyModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademyModel;
using AcademyEFPersistance.EFContext;

namespace AcademyEFPersistance.Repository {
	public class EFStudentRepository : EFCrudRepository<Student, long>, IStudentRepository
	{
		public EFStudentRepository(AcademyContext ctx) : base(ctx)
		{

		}
		public IEnumerable<Student> FindByLastnameLike(string lastnameLike)
		{
			return ctx.Students.Where(a => a.Lastname.Contains(lastnameLike));
		}

		public IEnumerable<Student> FindStudentByCompetence(long idSkill, Level? level)
		{
			IEnumerable<Student> students = new List<Student>();
			if (level == null)
			{
				students = ctx.Students.Where(i => i.Competences.Any(c => c.SkillId == idSkill));
			}
			else
			{
				students = ctx.Students.Where(i => i.Competences.Any(c => c.Level >= level && c.SkillId == idSkill));
			}
			return students;
		}

		public Student FindStudentWithCoursesById(long id)
		{
			return null;
		}
	}
}
