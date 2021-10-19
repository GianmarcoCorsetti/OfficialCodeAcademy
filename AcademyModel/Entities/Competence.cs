using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyModel.Entities
{
	public class Competence
	{
		public long Id { get; set; }
		public long PersonId { get; set; }
		public Person Person { get; set; }
		public long SkillId { get; set; }
		public Skill Skill { get; set; }
		public Level Level { get; set; }
	}
}
