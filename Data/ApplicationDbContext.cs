using HospitalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
      new Doctor
      {
          Id = 1,
          Name = "Ahmed Ali",
          Specialization = "Cardiology",
          Image = "doctor1.jpg"
      },

      new Doctor
      {
          Id = 2,
          Name = "Mohamed Hassan",
          Specialization = "Pediatrics",
          Image = "doctor2.jpg"
      },

      new Doctor
      {
          Id = 3,
          Name = "Omar Khaled",
          Specialization = "Dermatology",
          Image = "doctor3.jpg"
      },

      new Doctor
      {
          Id = 4,
          Name = "Youssef Ahmed",
          Specialization = "Neurology",
          Image = "doctor4.jpg"
      },

      new Doctor
      {
          Id = 5,
          Name = "Mahmoud Samir",
          Specialization = "Orthopedics",
          Image = "doctor5.jpg"
      },

      new Doctor
      {
          Id = 6,
          Name = "Mostafa Adel",
          Specialization = "Dentistry",
          Image = "doctor6.jpg"
      }
  );
        }
    }
}