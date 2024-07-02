using System.Numerics;

namespace ProjectMedicalClinic.Models
{
    public class AppointmentsRepository
    {
        private static List<Appointment> _appointments = new List<Appointment>()
        {
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
                PatientId = 3,
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
        };
        public static void AddAppointment(Appointment appointment)
        {
            if(_appointments.Any())
            {
                var maxId = _appointments.Max(x => x.AppId);
                appointment.AppId = maxId + 1;
            }
            else
            {
                appointment.AppId = 1;
            }

            if (_appointments == null) _appointments = new List<Appointment>();
            _appointments.Add(appointment);
        }
        public static List<Appointment> GetAppointments() => _appointments;

        public static Appointment? GetAppointmentById(int AppId)
        {
            var appointment = _appointments.FirstOrDefault(x => x.AppId == AppId);
            if(appointment != null)
            {
                return new Appointment
                {
                    AppId = appointment.AppId,
                    AppointmentDate = appointment.AppointmentDate,
                    PatientId = appointment.PatientId,
                    DoctorId = appointment.DoctorId,
                    RoomId = appointment.RoomId,
                    Notes = appointment.Notes
                };
            }
            return null;

        }
        public static void UpdateAppointment(int appointmentId, Appointment appointment)
        {
            var appointmentToUpdate = _appointments.FirstOrDefault(x => x.AppId == appointmentId);
            if(appointmentToUpdate != null)
            {
                appointmentToUpdate.AppointmentDate = appointment.AppointmentDate;
                appointmentToUpdate.PatientId = appointment.PatientId;
                appointmentToUpdate.DoctorId = appointment.DoctorId;
                appointmentToUpdate.RoomId = appointment.RoomId;
                appointmentToUpdate.Notes = appointment.Notes;
            }
        }

        public static void DeleteAppointment(int appointmentId)
        {
            var appointment = _appointments.FirstOrDefault(x =>x.AppId == appointmentId);
            if(appointment != null)
            {
                _appointments.Remove(appointment);
            }
        }

    }
}

