﻿namespace PatientLog.Domain.Entities
{
    public class Patient: BaseEntity
    {
        public Patient() {
            Appointments = new List<Appointment>();
            MedicalReports = new List<MedicalReport>();
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public List<Appointment> Appointments { get; set; }
        public List<MedicalReport> MedicalReports { get; set; }
    }
}
