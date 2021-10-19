using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademyModel.BuisnessLogic;
using AcademyModel.Entities;
using AutoMapper;
using CodeAcademyWeb.DTOs;
using NodaTime;
using NodaTime.Text;

namespace CodeAcademyWeb.Profiles
{
	public class StudentProfile : Profile
	{
		public StudentProfile()
		{
			CreateMap<Student, StudentDTO>()
				.ForMember(dto => dto.DateOfBirth, opt => opt.MapFrom(student => student.DateOfBirth.ToString("yyyy/MM/dd", null)))
				.ForMember(dto => dto.Surname, opt => opt.MapFrom(student => student.Lastname));

			CreateMap<StudentDTO, Student>()
				.ForMember(student => student.DateOfBirth, opt => opt.MapFrom(dto => Parse(dto.DateOfBirth)))
				.ForMember(student => student.Lastname, opt =>opt.MapFrom(dto => dto.Surname));
			CreateMap<EnrollData, EnrollDataDTO>();
			CreateMap<EnrollDataDTO, EnrollData>();
			CreateMap<Enrollment, EnrollmentDTO>();
			CreateMap<EnrollmentDTO, Enrollment>();
		}
		private LocalDate Parse(string dateString)
		{
			LocalDatePattern pattern = LocalDatePattern.CreateWithCurrentCulture("yyyy/MM/dd");
			var result = pattern.Parse(dateString);
			return result.Value;
		}		
	}
}
