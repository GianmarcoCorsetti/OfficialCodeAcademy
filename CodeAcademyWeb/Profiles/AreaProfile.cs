using AcademyModel.Entities;
using AutoMapper;
using CodeAcademyWeb.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAcademyWeb.Profiles
{
	public class AreaProfile : Profile
	{
		public AreaProfile()
		{
			CreateMap<Area, AreaDTO>();
			CreateMap<AreaDTO, Area>();
		}
	}
}
