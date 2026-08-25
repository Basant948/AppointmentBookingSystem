using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public string UserId { get; set; } = null!;

        public bool IsActive { get; set; } = true;
    }
}
