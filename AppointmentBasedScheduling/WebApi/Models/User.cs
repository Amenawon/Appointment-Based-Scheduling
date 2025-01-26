namespace WebApi.Models
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Organisation { get; set; }
        public DateTime CreateDate { get; set; }
        public List<AppointmentUser> AppointmentUsers { get; set; }
    }
}
