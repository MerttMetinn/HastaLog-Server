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
                    '{entity.Password}', '{entity.BirthDate}', '{entity.Gender}', '{entity.PhoneNumber}', 
                    '{entity.Address}', '{entity.CreatedDate}','{entity.UpdatedDate}');
                    """;

            connection.Query(sql);

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

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public bool UpdateEntity(Patient entity)
        {
            throw new NotImplementedException();
        }
    }
}
