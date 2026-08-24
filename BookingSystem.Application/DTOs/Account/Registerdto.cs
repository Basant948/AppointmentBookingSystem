using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookingSystem.Application.DTOs.Account
{
    public class Registerdto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Fname { get; set; }
        [Required]
        public string Lname { get; set; }
    }
}
