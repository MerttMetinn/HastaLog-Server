﻿using PatientLog.Domain.Dtos.AdminDtos;
using PatientLog.Domain.Dtos.DoctorDtos;
using PatientLog.Domain.Entities;

namespace PatientLog.Service.Abstract
{
    public interface IDoctorService
    {
        void AddDoctor(DoctorAddDto doctorAddDto);
        void DeleteDoctor(DoctorDeleteDto doctorDeleteDto);
        List<Doctor> GetAllDoctors();
        DoctorGetDto? GetDoctorById(Guid id);
        DoctorGetDto? GetDoctorByEmail(string email);
        List<Doctor> GetAllDoctorsBySpecializationArea(string SpecializationArea, string HospitalName);
        bool CheckDoctorExist(string email, string password);
        DoctorGetDto? GetDoctorByFullName(string name, string surname);
    }
}
