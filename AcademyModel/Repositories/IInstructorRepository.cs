using AcademyModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyModel.Repositories
{
	public interface IInstructorRepository : ICrudRepository<Instructor, long>
	{
		IEnumerable<Instructor> FindInstructorByCompetence(long idSkill, Level? level);
	}
}
