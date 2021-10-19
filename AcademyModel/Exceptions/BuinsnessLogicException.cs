using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyModel.Exceptions
{
	public class BuinsnessLogicException : Exception
	{
		public BuinsnessLogicException(string message) : base(message)
		{
		}
	}
}
