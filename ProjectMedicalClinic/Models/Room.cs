using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ProjectMedicalClinic.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        [Display(Name = "Patient")]
        public int? PatientId {  get; set; }
        public string Name { get; set; }
        public string Floor { get; set; }

        public Patient? Patient { get; set; }
    }
}
