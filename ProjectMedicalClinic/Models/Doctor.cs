using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectMedicalClinic.Models
{
    public class Doctor
    {

        public int DoctorId { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string DocFirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string DocLastName { get; set; }
        [Required]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }

        public string Specialization { get; set; }
        public int YearsOfExperience { get; set; }

        public ICollection<Patient>? Patients { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }

    }
}
