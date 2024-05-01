
using Dapper;
using PatientLog.Data.Repositories.Abstract;
using PatientLog.Domain.Contracts;
using PatientLog.Domain.Entities;
using System.Data.SqlClient;

namespace PatientLog.Data.Repositories.Concrete
{
    public class AdminRepository : IAdminRepository
    {

        public bool AddEntity(Admin entity)
        {
            string sql = $"""
                    INSERT INTO Admins  (Id ,Name , Surname , Email , Password , CreatedDate, UpdatedDate)
                    VALUES ('{Guid.NewGuid()}', '{entity.Name}', '{entity.Surname}', '{entity.Email}', '{entity.Password}', '{entity.CreatedDate}', '{entity.UpdatedDate}');
                """;


            var connection = new SqlConnection(ConstVariables.ConnectionString);


            if(connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            connection.Query(sql);

            connection.Close();


            return true;
        }

        public void ChangeUserPassword(int userId, string password)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEntity(Admin entity)
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public Admin GetEntityById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public bool UpdateEntity(Admin entity)
        {
            throw new NotImplementedException();
        }
    }
}
