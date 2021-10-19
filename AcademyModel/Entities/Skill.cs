using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyModel.Entities
{
	public class Skill
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public long AreaId { get; set; }
		public Area Area { get; set; }
	}
}
