using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookingSystem.Application.DTOs.Employee
{
    public class CreateEmployeeDto
    {
        [Required]
        public string Fname { get; set; }
        public string Lname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
