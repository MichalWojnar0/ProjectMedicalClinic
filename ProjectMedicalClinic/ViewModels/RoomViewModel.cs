using ProjectMedicalClinic.Models;

namespace ProjectMedicalClinic.ViewModels
{
    public class RoomViewModel
    {
        public IEnumerable<Patient> Patients { get; set; } = new List<Patient>();
        public Room Room { get; set; } = new Room();
    }
}
