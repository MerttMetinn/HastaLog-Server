using Dapper;
using PatientLog.Data.Repositories.Abstract;
using PatientLog.Domain.Contracts;
using PatientLog.Domain.Entities;
using System.Data.SqlClient;

namespace PatientLog.Data.Repositories.Concrete
{
    public class DoctorRepository : IDoctorRepository
    {
        public bool AddEntity(Doctor entity)
        {
            var connection = new SqlConnection(ConstVariables.ConnectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            string sql = $"""
                    INSERT INTO Doctors  (Id ,Name , Surname , Email , Password, BirthDate, Gender, 
                    PhoneNumber, Adress, SpecializationArea, HospitalName, CreatedDate, UpdatedDate)
                    VALUES ('{Guid.NewGuid()}', '{entity.Name}', '{entity.Surname}', '{entity.Email}', 
                    '{entity.Password}', '{entity.BirthDate}', '{entity.Gender}', '{entity.PhoneNumber}', 
                    '{entity.Adress}', '{entity.SpecializationArea}','{entity.HospitalName}','{entity.CreatedDate}',
                    '{entity.UpdatedDate}');
                    """;

            connection.Query(sql);

            connection.Close();

            return true;
        }

        public bool DeleteEntity(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public Doctor GetEntityById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public bool UpdateEntity(Doctor entity)
        {
            throw new NotImplementedException();
        }
    }
}
