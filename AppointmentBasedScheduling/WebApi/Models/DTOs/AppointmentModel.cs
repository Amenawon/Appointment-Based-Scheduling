namespace WebApi.Models.DTOs
{
    public class AppointmentModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public string OrganiserEmail { get; set; }
        public List<AppointmentUserModel> ListAttendees { get; set; }
    }
}
