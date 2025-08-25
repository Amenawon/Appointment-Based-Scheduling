namespace WebApi.Models.DTOs
{
    public class AppointmentModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public int Duration { get; set; }
        public string Location { get; set; }
        public string OrganiserEmail { get; set; }
        public List<AppointmentUserModel> ListAttendees { get; set; }
        public bool isGuest { get; set; } = false;
    }
}
