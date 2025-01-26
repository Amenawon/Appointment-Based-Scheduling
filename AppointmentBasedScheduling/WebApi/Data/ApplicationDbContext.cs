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
        public DbSet<AppointmentUser> AppointmentUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AppointmentUser>()
                .HasKey(au => new { au.AppointmentId, au.UserId }); // Composite Key

            modelBuilder.Entity<AppointmentUser>()
                .HasOne<Appointment>()
                .WithMany(a => a.AppointmentUsers)
                .HasForeignKey(au => au.AppointmentId);

            modelBuilder.Entity<AppointmentUser>()
                .HasOne<User>()
                .WithMany(u => u.AppointmentUsers)
                .HasForeignKey(au => au.UserId);
        }

    }
}
