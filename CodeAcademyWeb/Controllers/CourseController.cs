using AcademyModel.Entities;
using AcademyModel.Services;
using AutoMapper;
using CodeAcademyWeb.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAcademyWeb.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CourseController : Controller {
		private IDidactisService service;
		private IMapper mapper;
		public CourseController(IDidactisService service, IMapper mapper)
		{
			this.service = service;
			this.mapper = mapper;
		}
		[HttpGet]
		public IActionResult GetAll()
		{
			var course = service.GetAllCourses();
			var courseDTOs = mapper.Map<IEnumerable<CourseDTO>>(course);
			return Ok(courseDTOs);
		}
		[HttpGet]
		[Route("{id}")]
		public IActionResult GetById(long id) {
			var course = service.GetCourseById(id);
			var courseDTO = mapper.Map<CourseDTO>(course);
			return Ok(courseDTO);
		}

		[HttpGet]
		[Route("areas")]
		public IActionResult GetAllAreas()
		{
			var areas = service.GetAllAreas();
			var areaDTOs = mapper.Map<IEnumerable<AreaDTO>>(areas);
			return Ok(areaDTOs);
		}
		[HttpGet]
		[Route("{id}/editions")]
		public IActionResult GetEditionsByCourseId(long id)
        {
			var editions = service.GetEditionsByCourseId(id);
			var editionsDTO = mapper.Map<IEnumerable<CourseEditionDTO>>(editions);
			return Ok(editionsDTO);
        }

		public IActionResult GetLastNCurses(int n)
		{
			var courses = service.GetLastCourses(n);

			var courseDTOs = mapper.Map<IEnumerable<CourseDTO>>(courses);
			return Ok(courseDTOs);
		}
		[HttpPost]
		public IActionResult CreateCourse(CourseDTO courseDTO)
        {
            var course = mapper.Map<Course>(courseDTO);
			course = service.CreateCourse(course);
			var createdDTO = mapper.Map<CourseDTO>(course);
			return Created($"api/course/{createdDTO.Id}", createdDTO);
        }

		[HttpPut]
		[Route("{id}")]
		public IActionResult UpdateCourse(CourseDTO courseDTO)
        { 
			var course = mapper.Map<Course>(courseDTO);
			course = service.UpdateCourse(course);
			var modifiedDTO = mapper.Map<CourseDTO>(course);
			return Created($"api/course/{modifiedDTO.Id}", modifiedDTO);
        }
	}
}
 