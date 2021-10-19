using AcademyModel.Entities;
using AutoMapper;
using CodeAcademyWeb.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademyModel.Extensions;

namespace CodeAcademyWeb.Profiles
{
	public class CourseProfile : Profile
	{
		public CourseProfile()
		{
			CreateMap<Course, CourseDTO>()
				.ForMember(dto => dto.CreationDate, opt => opt.MapFrom(course => course.CreationDate.ToLocalDateString()));
			CreateMap<CourseDTO, Course>()
				.ForMember(course => course.CreationDate, opt => opt.MapFrom(dto => dto.CreationDate.Parse()));			
		}
	}
}
