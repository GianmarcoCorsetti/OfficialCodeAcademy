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
	public class CourseController : Controller
	{
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
		[HttpPost]
		public IActionResult CreateCourse(CourseDTO courseDTO)
		{
			var course = mapper.Map<Course>(courseDTO);
			course = service.CreateCourse(course);
			var resDTO = mapper.Map<CourseDTO>(course);
			return Created($"/api/courses/{resDTO.Id}", resDTO);
		}
		[HttpPut]
		public IActionResult UpdateCourse(CourseDTO courseDTO)
		{
			var course = mapper.Map<Course>(courseDTO);
			course = service.UpdateCourse(course);
			var resDTO = mapper.Map<CourseDTO>(course);
			return Created($"/api/courses/{resDTO.Id}", resDTO);
		}
		[HttpDelete]
		public IActionResult RemoveCourse(CourseDTO courseDTO)
		{
			var course = mapper.Map<Course>(courseDTO);
			service.DeleteCourse(course);
			var resDTO = mapper.Map<CourseDTO>(course);
			return Ok(resDTO);
		}

		[HttpDelete]
		[Route("{id}")]
		public IActionResult RemoveCourse(long id)
		{
			var course =service.GetCourseById(id);
			service.DeleteCourse(id);
			var resDTO = mapper.Map<CourseDTO>(course);
			return Ok(resDTO);
		}
		public IActionResult GetLastNCurses(int n)
		{
			var courses = service.GetLastCourses(n);

			var courseDTOs = mapper.Map<IEnumerable<CourseDTO>>(courses);
			return Ok(courseDTOs);
		}
	}
}
