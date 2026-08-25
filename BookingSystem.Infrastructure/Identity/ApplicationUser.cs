using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Infrastructure.Identity
{
    public class ApplicationUser: IdentityUser
    {
        public string? FName { get; set; }
        public string? Lname { get; set; }
    }
}
