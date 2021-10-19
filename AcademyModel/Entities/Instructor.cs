using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyModel.Entities
{
	public class Instructor : Person
	{
		public bool IsContractor { get; set; }
		public decimal PayRate { get; set; } // => soldi all'ora

	}
}
