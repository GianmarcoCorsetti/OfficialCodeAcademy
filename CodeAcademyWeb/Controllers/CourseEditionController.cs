using AcademyModel.BuisnessLogic;
using AcademyModel.BusinessLogic;
using AcademyModel.Entities;
using AcademyModel.Exceptions;
using AcademyModel.Services;
using AutoMapper;
using CodeAcademyWeb.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NodaTime;
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
		[Route("search")]
		public IActionResult FindEditions([FromQuery]long? istructorId, LocalDate? start, LocalDate? end, bool? inTheFuture, bool? inThePast, string titleLike) 
		{
			var info = new EditionSearchInfo
			{
				InstructorId = istructorId,
				Start = start,
				End = end,
				InTheFuture = inTheFuture,
				InThePast = inThePast,
				TitleLike = titleLike,
            };
            var editions = service.FindEditions(info);
            var editionDTOs = mapper.Map<IEnumerable<CourseEditionDTO>>(editions);
            return Ok(editionDTOs);
            //return $"istructorId: {istructorId}, start: {start}, end: {end}, inTheFuture: {inTheFuture}, inThePast: {inThePast}, titleLike: {titleLike}";
        }
		[HttpGet]
		[Route("searchDTO")]
		public IActionResult FindEditionDTO([FromQuery] long? id, [FromQuery] string code, [FromQuery] string description, [FromQuery] LocalDate? startDate, [FromQuery] LocalDate? endDate,
														[FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice, [FromQuery] long? courseId, [FromQuery] string courseTitle, [FromQuery] long? instructorId,
														[FromQuery] string instructorFullName, [FromQuery] string instructorFirstname, [FromQuery] string instructorLastname)
        {
			var infoDetails = new EditionSearchInfoDetails
			{
				Id = id,
				Code = code,
				Description = description,
				StartDate = startDate,
				EndDate = endDate,
				MinPrice = minPrice,
				MaxPrice = maxPrice,
				CourseId = courseId,
				CourseTitle = courseTitle,
				InstructorId = instructorId,
				InstructorFullName = instructorFullName,
				InstructorFirstname = instructorFirstname,
				InstructorLastname = instructorLastname,
			};
			var editions = service.FindEditionsDetailed(infoDetails);
			var editionDTOs = mapper.Map<IEnumerable<CourseEditionDetailsDTO>>(editions);
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

		//[HttpGet]
		//[Route("search/IsFuture")]
		//public IActionResult GetEditionsPastOrFuture(bool isFuture)
		//{
		//	var info = EditionSearchInfo{
		//		isFuture = isFuture
		//	}
  //          var editions = service.Search(isFuture);
  //          var editionsDTOs = mapper.Map<IEnumerable<CourseEditionDetailsDTO>>(editions);
  //          return Ok(editionsDTOs);
  //          //return $" Ciao : {isFuture}"; // funziona con ?isFuture=True // isFuture=False
		//}
		
	}
}
