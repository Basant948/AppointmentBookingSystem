using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Domain.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
