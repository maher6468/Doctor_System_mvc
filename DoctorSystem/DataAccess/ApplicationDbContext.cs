using DoctorSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorSystem.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Specialization> Specializations { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=DoctorSystem532;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Appointment>()
           .HasIndex(a => new { a.DoctorId, a.Date, a.Time })
           .IsUnique();
            modelBuilder.Entity<Specialization>().HasData(
            new Specialization { Id = 1, Name = "Cardiology" },
            new Specialization { Id = 2, Name = "Dentistry" },
            new Specialization { Id = 3, Name = "Dermatology" },
            new Specialization { Id = 4, Name = "Pediatrics" },
            new Specialization { Id = 5, Name = "Neurology" },
            new Specialization { Id = 6, Name = "Orthopedics" },
            new Specialization { Id = 7, Name = "Ophthalmology" },
            new Specialization { Id = 8, Name = "ENT" }
             ); modelBuilder.Entity<Doctor>().HasData(
    // Cardiology
              new Doctor { Id = 1, Name = "Ahmed Ali", SpecializationId = 1 },
              new Doctor { Id = 2, Name = "Mohamed Hassan", SpecializationId = 1 },
              new Doctor { Id = 3, Name = "Omar Khaled", SpecializationId = 1 },

    // Dentistry
              new Doctor { Id = 4, Name = "Youssef Ahmed", SpecializationId = 2 },
              new Doctor { Id = 5, Name = "Mahmoud Samir", SpecializationId = 2 },
              new Doctor { Id = 6, Name = "Karim Adel", SpecializationId = 2 },

    // Dermatology
              new Doctor { Id = 7, Name = "Mostafa Ali", SpecializationId = 3 },
              new Doctor { Id = 8, Name = "Amr Mohamed", SpecializationId = 3 },
              new Doctor { Id = 9, Name = "Hassan Ahmed", SpecializationId = 3 },

    // Pediatrics
              new Doctor { Id = 10, Name = "Sara Mohamed", SpecializationId = 4 },
              new Doctor { Id = 11, Name = "Mariam Ahmed", SpecializationId = 4 },
              new Doctor { Id = 12, Name = "Nour Khaled", SpecializationId = 4 },

    // Neurology
              new Doctor { Id = 13, Name = "Tarek Hassan", SpecializationId = 5 },
              new Doctor { Id = 14, Name = "Khaled Mahmoud", SpecializationId = 5 },
              new Doctor { Id = 15, Name = "Ahmed Samy", SpecializationId = 5 },

    // Orthopedics
              new Doctor { Id = 16, Name = "Islam Ahmed", SpecializationId = 6 },
              new Doctor { Id = 17, Name = "Hany Mohamed", SpecializationId = 6 },
              new Doctor { Id = 18, Name = "Walid Hassan", SpecializationId = 6 },

    // Ophthalmology
              new Doctor { Id = 19, Name = "Mina Adel", SpecializationId = 7 },
              new Doctor { Id = 20, Name = "George Samir", SpecializationId = 7 },
    new Doctor { Id = 21, Name = "Peter Ahmed", SpecializationId = 7 },

    // ENT
               new Doctor { Id = 22, Name = "Sherif Ali", SpecializationId = 8 },
               new Doctor { Id = 23, Name = "Ayman Khaled", SpecializationId = 8 },
               new Doctor { Id = 24, Name = "Mostafa Hassan", SpecializationId = 8 }
              );


        }
    }
}
