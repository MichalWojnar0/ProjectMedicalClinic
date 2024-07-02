using Microsoft.EntityFrameworkCore;

namespace ProjectMedicalClinic.Models
{
    public class MedicalClinicContext : DbContext
    {
        public MedicalClinicContext(DbContextOptions<MedicalClinicContext> options) : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasKey(d => d.DoctorId);
            modelBuilder.Entity<Patient>().HasKey(p => p.PatientId);
            modelBuilder.Entity<Room>().HasKey(r => r.RoomId);
            modelBuilder.Entity<Appointment>().HasKey(a => a.AppId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Room)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Room)
                .WithMany(r => r.Appointments)
                .HasForeignKey(a => a.RoomId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    DoctorId = 1,
                    DocFirstName = "John",
                    DocLastName = "Doe",
                    DocPhoneNumber = "555-1234",
                    DocAddress = "123 Main St, Hometown",
                    Specialization = "Cardiology",
                    YearsOfExperience = 20,
                },
                new Doctor
                {
                    DoctorId = 2,
                    DocFirstName = "Jane",
                    DocLastName = "Smith",
                    DocPhoneNumber = "555-5678",
                    DocAddress = "456 Elm St, Hometown",
                    Specialization = "Pediatrics",
                    YearsOfExperience = 15,
                },
                new Doctor
                {
                    DoctorId = 3,
                    DocFirstName = "Emily",
                    DocLastName = "Johnson",
                    DocPhoneNumber = "555-9101",
                    DocAddress = "789 Oak St, Hometown",
                    Specialization = "Dermatology",
                    YearsOfExperience = 10,
                },
                new Doctor
                {
                    DoctorId = 4,
                    DocFirstName = "Michael",
                    DocLastName = "Brown",
                    DocPhoneNumber = "555-1122",
                    DocAddress = "101 Pine St, Hometown",
                    Specialization = "Neurology",
                    YearsOfExperience = 25,
                },
                new Doctor
                {
                    DoctorId = 5,
                    DocFirstName = "Sarah",
                    DocLastName = "Williams",
                    DocPhoneNumber = "555-3344",
                    DocAddress = "202 Birch St, Hometown",
                    Specialization = "Orthopedics",
                    YearsOfExperience = 18,
                },
                new Doctor
                {
                    DoctorId = 6,
                    DocFirstName = "David",
                    DocLastName = "Miller",
                    DocPhoneNumber = "555-7788",
                    DocAddress = "303 Cedar St, Hometown",
                    Specialization = "General Surgery",
                    YearsOfExperience = 12,
                }
            );

            modelBuilder.Entity<Patient>().HasData(
                new Patient
                {
                    PatientId = 1,
                    FirstName = "Michał",
                    LastName = "Guest",
                    DateOfBirth = new DateTime(1985, 5, 23),
                    Gender = "Male",
                    PhoneNumber = "123-456-7890",
                    Address = "123 Main St, Warsaw, Poland",
                    CurrentMedications = "Lisinopril, Albuterol"
                },

                new Patient
                {
                    PatientId = 2,
                    FirstName = "Anna",
                    LastName = "Kowalski",
                    DateOfBirth = new DateTime(1990, 8, 15),
                    Gender = "Female",
                    PhoneNumber = "987-654-3210",
                    Address = "456 Elm St, Krakow, Poland",
                    CurrentMedications = "Metformin"
                },

                new Patient
                {
                    PatientId = 3,
                    FirstName = "John",
                    LastName = "Smith",
                    DateOfBirth = new DateTime(1975, 12, 1),
                    Gender = "Male",
                    PhoneNumber = "555-123-4567",
                    Address = "789 Oak St, Gdansk, Poland",
                    CurrentMedications = "Atorvastatin"
                }
            );

            modelBuilder.Entity<Room>().HasData(
                new Room { RoomId = 1, PatientId = 1, Name = "Room A", Floor = "First" },
                new Room { RoomId = 2, PatientId = 2, Name = "Room B", Floor = "Second" },
                new Room { RoomId = 3, PatientId = 3, Name = "Room C", Floor = "Third" }
            );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    AppId = 1,
                    AppointmentDate = DateTime.Today.AddDays(1),
                    PatientId = 1,
                    DoctorId = 1,
                    RoomId = 1,
                    Notes = "Follow-up appointment"
                },
            new Appointment
            {
                AppId = 2,
                AppointmentDate = DateTime.Today.AddDays(2),
                PatientId = 2,
                DoctorId = 2,
                RoomId = 2,
                Notes = "Initial consultation"
            },
            new Appointment
            {
                AppId = 3,
                AppointmentDate = DateTime.Today.AddDays(3),
                PatientId = 3,
                DoctorId = 3,
                RoomId = 3,
                Notes = "Check-up appointment"
            },
            new Appointment
            {
                AppId = 4,
                AppointmentDate = DateTime.Today.AddDays(4),
                PatientId = 4,
                DoctorId = 1,
                RoomId = 2,
                Notes = "Procedure follow-up"
            },
            new Appointment
            {
                AppId = 5,
                AppointmentDate = DateTime.Today.AddDays(5),
                PatientId = 2,
                DoctorId = 3,
                RoomId = 1,
                Notes = "Diagnostic discussion"
            }
            );
        }
    }
}
