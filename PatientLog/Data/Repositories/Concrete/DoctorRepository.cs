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
                    PhoneNumber, Address, SpecializationArea, HospitalName, CreatedDate, UpdatedDate)
                    VALUES ('{Guid.NewGuid()}', '{entity.Name}', '{entity.Surname}', '{entity.Email}', 
                    '{entity.Password}', @birthDate, '{entity.Gender}', '{entity.PhoneNumber}', 
                    '{entity.Address}', '{entity.SpecializationArea}','{entity.HospitalName}', @createdDate,
                    @updatedDate);
                    """;

            connection.Query(sql, new { birthDate = entity.BirthDate, createdDate = entity.CreatedDate, updatedDate = entity.UpdatedDate });

            connection.Close();

            return true;
        }
        public bool DeleteEntity(Doctor entity)
        {
            var connection = new SqlConnection(ConstVariables.ConnectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            string sql = $@"
                    DELETE FROM Doctors 
                    WHERE Id = '{entity.Id}';
                    ";

            connection.Query(sql);

            connection.Close();

            return true;
        }
        public List<Doctor> GetAllEntities()
        {
            var connection = new SqlConnection(ConstVariables.ConnectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            string sql = @"
                    SELECT * FROM Doctors;
                    ";

            var doctors = connection.Query<Doctor>(sql).ToList();

            connection.Close();

            return doctors;
        }
        public Doctor GetEntityById(Guid id)
        {
            var connection = new SqlConnection(ConstVariables.ConnectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            string sql = $"""
                    select
                    *
                    from Doctors d 
                    where d.Id = '{id}';
                """;


            Doctor? doctor = connection.Query<Doctor>(sql).FirstOrDefault();

            connection.Close();

            return doctor;
        }
        public Doctor GetEntityByEmail(string email)
        {
            var connection = new SqlConnection(ConstVariables.ConnectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            string sql = $"""
                    select
                    d.Id  as Id,
                    d.Name  as Name,
                    d.Surname as Surname ,
                    d.Email  as Email ,
                    d.BirthDate as BirthDate,
                    d.Gender as Gender,
                    d.PhoneNumber as PhoneNumber,
                    d.Address as Address,
                    d.SpecializationArea as SpecializationArea,
                    d.HospitalName as HospitalName,
                    d.CreatedDate as CreatedDate
                    from Doctors d 
                    where d.Email = '{email}';
                """;


            Doctor? doctor = connection.Query<Doctor>(sql).FirstOrDefault();

            connection.Close();

            return doctor;
        }
        public bool CheckDoctorExist(string email, string password)
        {
            var connection = new SqlConnection(ConstVariables.ConnectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            string sql = $"""
                        SELECT
                        Count(*)
                        FROM Doctors d
                        where d.Email = '{email}'
                        and d.Password = '{password}';
                """;


            int count = connection.Query<int>(sql).FirstOrDefault();

            connection.Close();

            return count >= 1;
        }

        public List<Doctor> GetAllDoctorsBySpecializationArea(string SpecializationArea, string HospitalName)
        {
            using (var connection = new SqlConnection(ConstVariables.ConnectionString))
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }

                string sql = @"
                SELECT * FROM Doctors
                WHERE SpecializationArea = @SpecializationArea
                AND HospitalName = @HospitalName;
                ";

                var doctors = connection.Query<Doctor>(sql, new { SpecializationArea, HospitalName }).ToList();

                connection.Close();

                return doctors;
            }
        }

        public Doctor GetEntityByFullName(string name, string surname)
        {
            using (var connection = new SqlConnection(ConstVariables.ConnectionString))
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }

                string sql = @"
                SELECT
                d.Id AS Id,
                d.Name AS Name,
                d.Surname AS Surname,
                d.Email AS Email,
                d.BirthDate AS BirthDate,
                d.Gender AS Gender,
                d.PhoneNumber AS PhoneNumber,
                d.Address AS Address,
                d.SpecializationArea AS SpecializationArea,
                d.HospitalName AS HospitalName,
                d.CreatedDate AS CreatedDate
                FROM Doctors d 
                WHERE d.Name = @Name 
                AND d.Surname = @Surname;
                ";

                Doctor? doctor = connection.Query<Doctor>(sql, new { Name = name, Surname = surname }).FirstOrDefault();

                connection.Close();

                return doctor;
            }
        }
    }
}
