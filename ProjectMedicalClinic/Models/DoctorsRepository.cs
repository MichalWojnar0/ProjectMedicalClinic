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
        };

        public static void AddDoctor(Doctor doctor)
        {
            if (_doctors != null && _doctors.Count > 0)
            {
                var maxId = _doctors.Max(x => x.DoctorId);
                doctor.DoctorId = maxId + 1;
            }
            else
            {
                doctor.DoctorId = 1;
            }
            if (_doctors == null) _doctors = new List<Doctor>();
            _doctors.Add(doctor);
        }

        public static List<Doctor> GetDoctors() => _doctors;

        public static Doctor? GetDoctorById(int doctorId)
        {
            var doctor = _doctors.FirstOrDefault(x => x.DoctorId == doctorId);
            if (doctor != null)
            {
                return new Doctor
                {
                    DoctorId = doctorId,
                    DocFirstName = doctor.DocFirstName,
                    DocLastName = doctor.DocLastName,
                    DocPhoneNumber = doctor.DocPhoneNumber,
                    DocAddress = doctor.DocAddress,
                    Specialization = doctor.Specialization,
                    YearsOfExperience = doctor.YearsOfExperience,
                };
            }
            return null;
        }
        public static void UpdateDoctor(int doctorId, Doctor doctor)
        {
            if (doctorId != doctor.DoctorId) return;
            var doctorToUpdate = _doctors.FirstOrDefault(x => x.DoctorId == doctorId);
            if (doctorToUpdate != null) 
            {
                doctorToUpdate.DocFirstName = doctor.DocFirstName;
                doctorToUpdate.DocLastName = doctor.DocLastName;
                doctorToUpdate.DocPhoneNumber = doctor.DocPhoneNumber;
                doctorToUpdate.DocAddress = doctor.DocAddress;
                doctorToUpdate.Specialization = doctor.Specialization;
                doctorToUpdate.YearsOfExperience = doctor.YearsOfExperience;
            }
        }

        public static void DeleteDoctor(int doctorId) 
        {
            var doctor = _doctors.FirstOrDefault(x => x.DoctorId == doctorId);
            if (doctor != null) 
            {
                _doctors.Remove(doctor);
            }
        }
    }

}
