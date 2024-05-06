using Dapper;
using PatientLog.Data.Repositories.Abstract;
using PatientLog.Domain.Contracts;
using PatientLog.Domain.Entities;
using System.Data.SqlClient;

namespace PatientLog.Data.Repositories.Concrete
{
    public class AppointmentRepository : IAppointmentRepository
    {
        public bool AddEntity(Appointment entity)
        {
            var connection = new SqlConnection(ConstVariables.ConnectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            //Düzeltilecek
            string sql = $"""
                    INSERT INTO Appointments  (Id ,Date , HospitalName , PatientId , DoctorId , CreatedDate, UpdatedDate)
                    VALUES ('{Guid.NewGuid()}', '{entity.Date}', '{entity.HospitalName}', '{entity.PatientId}', '{entity.DoctorId}', '{entity.CreatedDate}', '{entity.UpdatedDate}');
                """;

            connection.Query(sql);

            connection.Close();

            return true;
        }

        public bool DeleteEntity(Appointment entity)
        {
            var connection = new SqlConnection(ConstVariables.ConnectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            string sql = $@"
                    DELETE FROM Appointments 
                    WHERE Id = '{entity.Id}';
                    ";

            connection.Query(sql);

            connection.Close();

            return true;
        }

        public List<Appointment> GetAllEntities()
        {
            var connection = new SqlConnection(ConstVariables.ConnectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            string sql = @"
                    SELECT * FROM Appointments;
                    ";

            var appointments = connection.Query<Appointment>(sql).ToList();

            connection.Close();

            return appointments;
        }

        public Appointment GetEntityById(Guid id)
        {
            var connection = new SqlConnection(ConstVariables.ConnectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            string sql = $"""
                    select
                    *
                    from Appointments a 
                    where a.Id = '{id}';
                """;


            Appointment? appointment = connection.Query<Appointment>(sql).FirstOrDefault();

            connection.Close();

            return appointment;
        }
    }
}
