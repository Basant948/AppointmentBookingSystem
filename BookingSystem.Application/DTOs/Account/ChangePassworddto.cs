using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Application.DTOs.Account
{
    public class ChangePassworddto
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
