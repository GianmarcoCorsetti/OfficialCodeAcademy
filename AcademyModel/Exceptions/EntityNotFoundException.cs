using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyModel.Exceptions
{
	public class EntityNotFoundException : Exception
	{
		public string EntityName { get; set; }
		public EntityNotFoundException(string msg, string entityName) : base(msg)
		{
			EntityName = entityName;
		}
	}
}
