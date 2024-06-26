﻿using Dapper;
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
            var connection = new SqlConnection(ConstVariables.ConnectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            string sql = $"""
                    INSERT INTO Admins  (Id ,Name , Surname , Email , Password , CreatedDate, UpdatedDate)
                    VALUES ('{Guid.NewGuid()}', '{entity.Name}', '{entity.Surname}', '{entity.Email}',
                    '{entity.Password}', @createdDate, @updatedDate);
                """;

            connection.Query(sql, new { createdDate = entity.CreatedDate, updatedDate = entity.UpdatedDate });

            connection.Close();

            return true;
        }
        public bool DeleteEntity(Admin entity)
        {
            var connection = new SqlConnection(ConstVariables.ConnectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            string sql = $@"
                    DELETE FROM Admins 
                    WHERE Id = '{entity.Id}';
                    ";

            connection.Query(sql);

            connection.Close();

            return true;
        }
        public List<Admin> GetAllEntities()
        {
            var connection = new SqlConnection(ConstVariables.ConnectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            string sql = @"
                    SELECT * FROM Admins;
                    ";

            var admins = connection.Query<Admin>(sql).ToList();

            connection.Close();

            return admins;
        }
        public Admin GetEntityById(Guid id)
        {
            var connection = new SqlConnection(ConstVariables.ConnectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            string sql = $"""
                    select
                    a.Id  as Id,
                    a.Name  as Name,
                    a.Surname as Surname ,
                    a.Email  as Email ,
                    a.Password as Password,
                    a.CreatedDate as CreatedDate
                    from Admins a 
                    where a.Id = '{id}';
                """;


            Admin? admin = connection.Query<Admin>(sql).FirstOrDefault();

            connection.Close();

            return admin;
        }
        public Admin GetEntityByEmail(string email)
        {
            var connection = new SqlConnection(ConstVariables.ConnectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            string sql = $"""
                    select
                    a.Id  as Id,
                    a.Name  as Name,
                    a.Surname as Surname ,
                    a.Email  as Email ,
                    a.CreatedDate as CreatedDate
                    from Admins a 
                    where a.Email = '{email}';
                """;


            Admin? admin = connection.Query<Admin>(sql).FirstOrDefault();

            connection.Close();

            return admin;
        }
        public bool CheckAdminExist(string email, string password)
        {
            var connection = new SqlConnection(ConstVariables.ConnectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            string sql = $"""
                        SELECT
                        Count(*)
                        FROM Admins a
                        where a.Email = '{email}'
                        and a.Password = '{password}';
                """;


            int count = connection.Query<int>(sql).FirstOrDefault();

            connection.Close();

            return count >= 1;
        }
    }
}
