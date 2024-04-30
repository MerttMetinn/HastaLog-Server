﻿using PatientLog.Domain.Entities;

namespace PatientLog.Domain.Dtos.AdminDtos
{
    public class AdminAddDoctorDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string SpecializationArea { get; set; }
        public string HospitalName { get; set; }
    }
}