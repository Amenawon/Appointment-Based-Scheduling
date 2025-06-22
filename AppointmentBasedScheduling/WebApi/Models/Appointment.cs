using WebApi.Models.AppointmentDetails;

namespace WebApi.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public string Location { get; set; }
        public Status Status { get; set; }
        public string OrganiserId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public List<AppointmentUser> AppointmentUsers { get; set; }
    }
}
