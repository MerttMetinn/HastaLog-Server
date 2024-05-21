using Dapper;
using PatientLog.Data.Repositories.Abstract;
using PatientLog.Domain.Contracts;
using PatientLog.Domain.Dtos.AppointmentDtos;
using PatientLog.Domain.Entities;
using System.Data.SqlClient;

namespace PatientLog.Data.Repositories.Concrete
{
    public class AppointmentRepository : IAppointmentRepository
    {
        public bool AddEntity(Appointment entity)
        {
            using (var connection = new SqlConnection(ConstVariables.ConnectionString))
            {

                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }

                string sql = @"
            INSERT INTO Appointments (Id, Date, Clinic, HospitalName, PatientId, DoctorId, CreatedDate, UpdatedDate)
            VALUES (@Id, @Date, @Clinic, @HospitalName, @PatientId, @DoctorId, @CreatedDate, @UpdatedDate);
        ";

                connection.Execute(sql, new
                {
                    Id = Guid.NewGuid(),
                    Date = entity.Date,
                    Clinic = entity.Clinic,
                    HospitalName = entity.HospitalName,
                    PatientId = entity.PatientId,
                    DoctorId = entity.DoctorId,
                    CreatedDate = entity.CreatedDate,
                    UpdatedDate = entity.UpdatedDate
                });

                connection.Close();

                return true;
            }
        }

        public bool CheckAppointmentDate(AppointmentGetDto appointmentGetDto)
        {
            var connection = new SqlConnection(ConstVariables.ConnectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            string sql = $"""
                    SELECT
                    Count(*)
                    FROM Appointments a
                    WHERE a.Date = @Date
                    AND a.HospitalName = @HospitalName
                    AND a.Clinic = @Clinic
                    AND a.DoctorId = @DoctorId
            """;

            var parameters = new
            {
                Date = appointmentGetDto.Date,
                HospitalName = appointmentGetDto.HospitalName,
                Clinic = appointmentGetDto.Clinic,
                DoctorId = appointmentGetDto.DoctorId
            };

            int count = connection.Query<int>(sql, parameters).FirstOrDefault();

            connection.Close();

            return count >= 1;
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

        public List<Appointment> GetAppointmentsByPatientId(Guid patientId)
        {
            var connection = new SqlConnection(ConstVariables.ConnectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            string sql = $@"
                    SELECT * FROM Appointments WHERE PatientId = '{patientId}';
                    ";

            var appointments = connection.Query<Appointment>(sql).ToList();

            connection.Close();

            return appointments;
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
