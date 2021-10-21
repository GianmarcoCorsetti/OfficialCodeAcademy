using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyModel.BusinessLogic {
	public class EditionSearchInfoDetails {
		public long? Id { get; set; }
		public string Code { get; set; }
		public string Description { get; set; }
		public LocalDate? StartDate { get; set; }
		public LocalDate? EndDate { get; set; }
		public decimal? MinPrice{ get; set; }
        public decimal? MaxPrice{ get; set; }
        public long? CourseId { get; set; }
		public string CourseTitle { get; set; }
		public long? InstructorId { get; set; }
		public string InstructorFullName { get; set; }
		public string InstructorFirstname { get; set; }
		public string InstructorLastname { get; set; }
		public EditionSearchInfoDetails() { }
        public EditionSearchInfoDetails(long? id, string code, string description, LocalDate? startDate, LocalDate? endDate,
                                        decimal? minPrice, decimal? maxPrice, long? courseId, string courseTitle, long? instructorId, 
                                        string instructorFullName, string instructorFirstname, string instructorLastname)
        {
            Id = id;
            Code = code;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            MinPrice = minPrice;
            MaxPrice = maxPrice;
            CourseId = courseId;
            CourseTitle = courseTitle;
            InstructorId = instructorId;
            InstructorFullName = instructorFullName;
            InstructorFirstname = instructorFirstname;
            InstructorLastname = instructorLastname;
        }
    }
}
