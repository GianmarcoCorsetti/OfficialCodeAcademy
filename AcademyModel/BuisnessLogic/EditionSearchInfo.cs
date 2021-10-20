using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyModel.BuisnessLogic
{
	public class EditionSearchInfo
	{
		public long? InstructorId { get; set; }
		public LocalDate? Start { get; set; }
		public LocalDate? End { get; set; }
		public bool? InTheFuture { get; set; }
		public bool? InThePast { get; set; }
		public string TitleLike { get; set; }

		public EditionSearchInfo(){ }
		public EditionSearchInfo(long? instructorId, LocalDate? start, LocalDate? end, bool? inTheFuture, bool? inThePast, string titleLike) 
		{
			End = end;
			InTheFuture = inTheFuture;
			InThePast = inThePast;
			TitleLike = titleLike;
		}
	}
}
