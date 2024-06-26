﻿namespace PatientLog.Domain.Entities
{
    public class Doctor: BaseEntity
    {
        public Doctor()
        {
            MedicalReports = new List<MedicalReport>();
            Appointments = new List<Appointment>();
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string SpecializationArea { get; set; }
        public string HospitalName { get; set; }
        public List<MedicalReport> MedicalReports { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
