namespace ProjectMedicalClinic.Models
{
    public class DoctorsRepository
    {
        private static List<Doctor> _doctors = new List<Doctor>()
        {
            new Doctor
            {
                DoctorId = 1,
                DocFirstName = "John",
                DocLastName = "Doe",
                PhoneNumber = "555-1234",
                Address = "123 Main St, Hometown",
                Specialization = "Cardiology",
                YearsOfExperience = 20,
            },
            new Doctor
            {
                DoctorId = 2,
                DocFirstName = "Jane",
                DocLastName = "Smith",
                PhoneNumber = "555-5678",
                Address = "456 Elm St, Hometown",
                Specialization = "Pediatrics",
                YearsOfExperience = 15,
            },
            new Doctor
            {
                DoctorId = 3,
                DocFirstName = "Emily",
                DocLastName = "Johnson",
                PhoneNumber = "555-9101",
                Address = "789 Oak St, Hometown",
                Specialization = "Dermatology",
                YearsOfExperience = 10,
            },
            new Doctor
            {
                DoctorId = 4,
                DocFirstName = "Michael",
                DocLastName = "Brown",
                PhoneNumber = "555-1122",
                Address = "101 Pine St, Hometown",
                Specialization = "Neurology",
                YearsOfExperience = 25,
            },
            new Doctor
            {
                DoctorId = 5,
                DocFirstName = "Sarah",
                DocLastName = "Williams",
                PhoneNumber = "555-3344",
                Address = "202 Birch St, Hometown",
                Specialization = "Orthopedics",
                YearsOfExperience = 18,
            },
            new Doctor
            {
                DoctorId = 6,
                DocFirstName = "David",
                DocLastName = "Miller",
                PhoneNumber = "555-7788",
                Address = "303 Cedar St, Hometown",
                Specialization = "General Surgery",
                YearsOfExperience = 12,
            }
        };
    }
}
