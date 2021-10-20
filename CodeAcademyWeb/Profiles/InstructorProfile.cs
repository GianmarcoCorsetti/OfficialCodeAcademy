using AcademyModel.Entities;
using AutoMapper;
using CodeAcademyWeb.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAcademyWeb.Profiles
{
	public class InstructorProfile : Profile
	{
		public InstructorProfile()
		{
			CreateMap<Instructor, InstructorDTO>();
			CreateMap<InstructorDTO, Instructor>();
		}	
	}
}
