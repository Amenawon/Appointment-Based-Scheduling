namespace WebApi.Models
{
    public class AppointmentUser
    {
        public int AppointmentId { get; set; } // Foreign Key
        public string UserId { get; set; } // Foreign Key
        public string Role { get; set; }
        public string RsvpStatus { get; set; } // Going, Declined
    }
}
