namespace WebApi.Models
{
    public class AppointmentModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        public string Location { get; set; }
        public Status Status { get; set; }
        public List<AttendeeModel> Attendees { get; set; }

        public UserModel CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
