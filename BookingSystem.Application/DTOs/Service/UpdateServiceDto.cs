using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Application.DTOs.Service
{
    public class UpdateServiceDto
    {
        public string Name { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public int Duration { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
