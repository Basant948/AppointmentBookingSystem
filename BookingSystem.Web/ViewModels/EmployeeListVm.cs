namespace BookingSystem.Web.ViewModels
{
    public class EmployeeListVm
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public bool IsActive { get; set; }
    }
}