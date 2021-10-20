using AcademyModel.Entities;
using AcademyModel.Exceptions;
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
	public class CourseEditionController : Controller
	{
		private IDidactisService service;
		private IMapper mapper;
		public CourseEditionController(IDidactisService service, IMapper mapper)
		{
			this.service = service;
			this.mapper = mapper;
		}
		[HttpGet]
		public IActionResult GetAll()
		{
			var editions = service.GetAllEditions();
			var editionDTOs = mapper.Map<IEnumerable<CourseEditionDTO>>(editions);
			return Ok(editionDTOs);
		}
		[Route("{id}")]
		[HttpGet]
		public IActionResult FindById(long id)
		{
			var edition = service.GetEditionById(id);
			if (edition == null)
			{
				return NotFound();
			}
			var editionDTO = mapper.Map<CourseEditionDetailsDTO>(edition);
			return Ok(editionDTO);
		}
		[HttpPost]
		public IActionResult Create(CourseEditionDetailsDTO e)
		{
			try
			{
				var edition = mapper.Map<CourseEdition>(e);
				service.CreateCourseEdition(edition);
				var courseEditionDTO = mapper.Map<CourseEditionDetailsDTO>(edition);
				return Created($"/api/edition/{courseEditionDTO.Id}", courseEditionDTO);
			}
			catch (EntityNotFoundException ex)
			{
				return BadRequest(new ErrorObject(StatusCodes.Status400BadRequest, ex.Message));
			}
		}
		[HttpPut]
		public IActionResult Edit(CourseEditionDetailsDTO e)
		{
			try
			{
				var edition = mapper.Map<CourseEdition>(e);
				service.EditCourseEdition(edition);
				var courseEditionDTO = mapper.Map<CourseEditionDetailsDTO>(edition);
				return NoContent();
			}
			catch (EntityNotFoundException ex)
			{
				switch (ex.EntityName)
				{
					case nameof(CourseEdition):
						return NotFound(ex.Message);

					default:
						return BadRequest(new ErrorObject(StatusCodes.Status400BadRequest, ex.Message));
				}
			}
		}
		[Route("{id}")]
		[HttpDelete]
		public IActionResult Delete(long id)
		{
			try
			{
				service.DeleteCourseEdition(id);
				return NoContent();
			}
			catch (EntityNotFoundException ex)
			{
				return NotFound(new ErrorObject(StatusCodes.Status404NotFound, ex.Message));
			}
		}
		[HttpGet]
		[Route("course/{id}")]
		public IActionResult GetEditionsByCourseId(long id)
		{
			var editions = service.GetEditionsByCourseId(id);
			var editionDTOs = mapper.Map<IEnumerable<CourseEditionDTO>>(editions);
			return Ok(editionDTOs);
		}
	}
}
