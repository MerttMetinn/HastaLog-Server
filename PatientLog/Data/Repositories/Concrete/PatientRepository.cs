using Dapper;
using PatientLog.Data.Repositories.Abstract;
using PatientLog.Domain.Contracts;
using PatientLog.Domain.Entities;
using System.Data.SqlClient;

namespace PatientLog.Data.Repositories.Concrete
{
    public class PatientRepository : IPatientRepository
    {
        public bool AddEntity(Patient entity)
        {
            var connection = new SqlConnection(ConstVariables.ConnectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }


            string sql = $"""
                    INSERT INTO Patients  (Id ,Name , Surname , Email , Password, BirthDate, Gender, 
                    PhoneNumber, Address, CreatedDate, UpdatedDate)
                    VALUES ('{Guid.NewGuid()}', '{entity.Name}', '{entity.Surname}', '{entity.Email}', 
                    '{entity.Password}', @birthDate, '{entity.Gender}', '{entity.PhoneNumber}', 
                    '{entity.Address}', @createdDate, @updatedDate);
                    """;

            connection.Query(sql, new { birthDate = entity.BirthDate, createdDate = entity.CreatedDate, updatedDate = entity.UpdatedDate});

            connection.Close();

            return true;
        }
        public bool DeleteEntity(Patient entity)
        {
            var connection = new SqlConnection(ConstVariables.ConnectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            string sql = $@"
                    DELETE FROM Patients 
                    WHERE Id = '{entity.Id}';
                    ";

            connection.Query(sql);

            connection.Close();

            return true;
        }
        public List<Patient> GetAllEntities()
        {
            var connection = new SqlConnection(ConstVariables.ConnectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            string sql = @"
                    SELECT * FROM Patients;
                    ";

            var patients = connection.Query<Patient>(sql).ToList();

            connection.Close();

            return patients;
        }
        public Patient GetEntityById(Guid id)
        {
            var connection = new SqlConnection(ConstVariables.ConnectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            string sql = $"""
                    select
                    *
                    from Patients p 
                    where p.Id = '{id}';
                """;


            Patient? patient = connection.Query<Patient>(sql).FirstOrDefault();

            connection.Close();

            return patient;
        }
        public Patient GetEntityByEmail(string email)
        {
            var connection = new SqlConnection(ConstVariables.ConnectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            string sql = $"""
                    select
                    p.Id  as Id,
                    p.Name  as Name,
                    p.Surname as Surname ,
                    p.Email  as Email ,
                    p.BirthDate as BirthDate,
                    p.Gender as Gender,
                    p.PhoneNumber as PhoneNumber,
                    p.Address as Address,
                    p.CreatedDate as CreatedDate
                    from Patients p 
                    where p.Email = '{email}';
                """;


            Patient? patient = connection.Query<Patient>(sql).FirstOrDefault();

            connection.Close();

            return patient;
        }
        public bool CheckPatientExist(string email, string password)
        {
            var connection = new SqlConnection(ConstVariables.ConnectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            string sql = $"""
                        SELECT
                        Count(*)
                        FROM Patients p
                        where p.Email = '{email}'
                        and p.Password = '{password}';
                """;


            int count = connection.Query<int>(sql).FirstOrDefault();

            connection.Close();

            return count >= 1;
        }
    }
}
