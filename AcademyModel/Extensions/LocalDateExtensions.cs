using NodaTime;
using NodaTime.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyModel.Extensions
{
	public static class LocalDateExtensions
	{
		public static LocalDate Parse(this string dateString)
		{
			LocalDatePattern pattern = LocalDatePattern.CreateWithCurrentCulture("yyyy-MM-dd");
			var result = pattern.Parse(dateString);
			return result.Value;
		}
		public static string ToLocalDateString(this LocalDate date)
		{
			return date.ToString("yyyy-MM-dd", null);
		}
	}
}
