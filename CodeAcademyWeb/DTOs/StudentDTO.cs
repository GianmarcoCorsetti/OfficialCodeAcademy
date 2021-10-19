using AcademyModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAcademyWeb.DTOs
{
	public class StudentDTO
	{
		public long Id { get; set; }
		public string Firstname { get; set; }
		public string Surname { get; set; }
		public string DateOfBirth { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public bool IsEmployee { get; set; }
		
		public StudentDTO(){ }
		public StudentDTO(Student original) 
		{
			Id = original.Id;
			Firstname = original.Firstname;
			Surname = original.Lastname;
			Address = original.Address;
			City = original.City;
			Email = original.Email;
			PhoneNumber = original.PhoneNumber;
			IsEmployee = original.IsEmployee;
			DateOfBirth = original.DateOfBirth.ToString("yyyy/MM/dd", null);
		}
	}
}
