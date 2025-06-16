using Microsoft.AspNetCore.Identity;

namespace WebApi.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Organisation { get; set; }
        public bool IsPlaceholder { get; set; } = false;
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public List<AppointmentUser> AppointmentUsers { get; set; }
    }
}
