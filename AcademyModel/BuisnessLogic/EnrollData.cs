using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyModel.BuisnessLogic
{
	public class EnrollData
	{
		public long IdStudent { get; set; }
		public long IdEdition { get; set; }
		public EnrollData(){ }
		public EnrollData(long idStudent, long idEdition) 
		{
			IdStudent = idStudent;
			IdEdition = idEdition;
		}
	}
}
