using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentUser> AppointmentUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppointmentUser>()
                .HasKey(au => new { au.AppointmentId, au.UserId });

            modelBuilder.Entity<AppointmentUser>()
                .Property(au => au.UserId)
                .HasMaxLength(256);

            modelBuilder.Entity<AppointmentUser>()
                .HasOne<Appointment>()
                .WithMany(a => a.AppointmentUsers)
                .HasForeignKey(au => au.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AppointmentUser>()
                .HasOne<User>()
                .WithMany(u => u.AppointmentUsers)
                .HasForeignKey(au => au.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(a => a.OrganiserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
