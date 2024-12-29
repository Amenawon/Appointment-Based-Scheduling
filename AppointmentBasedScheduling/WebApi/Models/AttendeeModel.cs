namespace WebApi.Models
{
    public class AttendeeModel
    {
        public string? UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsRegistered { get; set; }
    }
}
