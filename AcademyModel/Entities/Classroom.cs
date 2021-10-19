using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyModel.Entities
{
	public class Classroom
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public int Capacity { get; set; }
		public bool IsVirtual { get; set; }
		public bool? IsComputerized { get; set; }
		public bool? HasProjector { get; set; }
	}
}
