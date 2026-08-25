namespace BookingSystem.Application.DTOs.Employee
{
    public class EditEmployeeDto
    {
        public string Id { get; set; } = null!;

        public string Fname { get; set; } = null!;

        public string Lname { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}