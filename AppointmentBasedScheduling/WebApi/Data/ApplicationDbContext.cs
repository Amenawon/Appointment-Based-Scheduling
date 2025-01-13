using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Attendee> Attendees { get; set; }

    }
}
