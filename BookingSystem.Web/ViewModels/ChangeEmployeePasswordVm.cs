namespace BookingSystem.Web.ViewModels
{
    public class ChangeEmployeePasswordVm
    {
        public string EmployeeId { get; set; } = string.Empty;

        public string NewPassword { get; set; } = string.Empty;

        public string ConfirmPassword { get; set; } = string.Empty;
    }
}