using AcademyModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyModel.Repositories
{
	public interface IStudentRepository : ICrudRepository<Student, long>
	{
		IEnumerable<Student> FindByLastnameLike(string lastnameLike);
		Student FindStudentWithCoursesById(long id);
		IEnumerable<Student> FindStudentByCompetence(long idSkill, Level? level);
	}


}
