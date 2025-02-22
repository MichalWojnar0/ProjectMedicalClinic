﻿using System.ComponentModel.DataAnnotations;

namespace ProjectMedicalClinic.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }

        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string? CurrentMedications { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
    }
}
