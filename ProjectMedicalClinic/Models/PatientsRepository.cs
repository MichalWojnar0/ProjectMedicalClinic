namespace ProjectMedicalClinic.Models
{
    public static class PatientsRepository
    {
        private static List<Patient> _patients = new List<Patient>()
        {
            new Patient {PatientId = 1,
            FirstName = "Michał",
            LastName = "Guest",
            DateOfBirth = new DateTime(1985, 5, 23),
            Gender = "Male",
            PhoneNumber = "123-456-7890",
            Address = "123 Main St, Warsaw, Poland",
            CurrentMedications = "Lisinopril, Albuterol" },

            new Patient {PatientId = 2,
            FirstName = "Anna",
            LastName = "Kowalski",
            DateOfBirth = new DateTime(1990, 8, 15),
            Gender = "Female",
            PhoneNumber = "987-654-3210",
            Address = "456 Elm St, Krakow, Poland",
            CurrentMedications = "Metformin"},

            new Patient {PatientId = 3,
            FirstName = "John",
            LastName = "Smith",
            DateOfBirth = new DateTime(1975, 12, 1),
            Gender = "Male",
            PhoneNumber = "555-123-4567",
            Address = "789 Oak St, Gdansk, Poland",
            CurrentMedications = "Atorvastatin"}
        };

        public static void AddPatient(Patient patient)
        {
            var maxId = _patients.Max(x => x.PatientId);
            patient.PatientId = maxId + 1;
            _patients.Add(patient);
        }

        public static List<Patient> GetPatients() => _patients;

        public static Patient? GetPatientById(int patientId)
        {
            var patient = _patients.FirstOrDefault(x => x.PatientId == patientId);
            if (patient != null) 
            {
                return new Patient
                {
                    PatientId = patient.PatientId,
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    DateOfBirth = patient.DateOfBirth,
                    Gender = patient.Gender,
                    PhoneNumber = patient.PhoneNumber,
                    Address = patient.Address,
                    CurrentMedications = patient.CurrentMedications,
                };

            }

            return null;
        }

        public static void UpdatePatient(int patientId, Patient patient)
        {
            if (patientId != patient.PatientId) return;

            var patientToUpdate = _patients.FirstOrDefault(x => x.PatientId == patientId);
            if (patientToUpdate != null) 
            {
                patientToUpdate.FirstName = patient.FirstName;
                patientToUpdate.LastName = patient.LastName;
                patientToUpdate.DateOfBirth = new DateTime();
                patientToUpdate.Gender = patient.Gender;
                patientToUpdate.PhoneNumber = patient.PhoneNumber;
                patientToUpdate.Address = patient.Address;
                patientToUpdate.CurrentMedications = patient.CurrentMedications;
            }
        }
        public static void DeletePatient(int patientId) 
        {
            var patient = _patients.FirstOrDefault(x => x.PatientId == patientId);
            if (patient != null)
            {
                _patients.Remove(patient);
            }
        }
    }
}
