using Dapper;
using PatientLog.Data.Repositories.Abstract;
using PatientLog.Domain.Contracts;
using PatientLog.Domain.Entities;
using System.Data.SqlClient;

namespace PatientLog.Data.Repositories.Concrete
{
    public class MedicalReportRepository : IMedicalReportRepository
    {
        public bool AddEntity(MedicalReport entity)
        {
            try
            {
                using (var connection = new SqlConnection(ConstVariables.ConnectionString))
                {
                    connection.Open();

                    string sql = @"
                INSERT INTO MedicalReports (Id, Date, Path, PatientId, DoctorId, 
                AppointmentId, Details, CreatedDate, UpdatedDate)
                VALUES (@Id, @Date, @Path, @PatientId, @DoctorId, 
                @AppointmentId, @Details, @CreatedDate, @UpdatedDate);";

                    var parameters = new
                    {
                        Id = Guid.NewGuid(),
                        Date = entity.Date,
                        Path = entity.Path,
                        PatientId = entity.PatientId,
                        DoctorId = entity.DoctorId,
                        AppointmentId = entity.AppointmentId,
                        Details = entity.Details,
                        CreatedDate = entity.CreatedDate,
                        UpdatedDate = entity.UpdatedDate
                    };

                    connection.Execute(sql, parameters);
                }

                return true;
            }
            catch (SqlException ex)
            {
                // Log exception details (ex) here
                return false;
            }
        }


        public bool DeleteEntity(MedicalReport entity)
        {
            using (var connection = new SqlConnection(ConstVariables.ConnectionString))
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }

                string sql = @"
                    DELETE FROM MedicalReports 
                    WHERE Id = @Id;
                ";

                connection.Execute(sql, new { Id = entity.Id });

                connection.Close();

                return true;
            }
        }

        public List<MedicalReport> GetAllEntities()
        {
            using (var connection = new SqlConnection(ConstVariables.ConnectionString))
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }

                string sql = @"
                    SELECT * FROM MedicalReports;
                ";

                var medicalReports = connection.Query<MedicalReport>(sql).ToList();

                connection.Close();

                return medicalReports;
            }
        }

        public MedicalReport GetEntityById(Guid id)
        {
            using (var connection = new SqlConnection(ConstVariables.ConnectionString))
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }

                string sql = @"
                    SELECT * FROM MedicalReports 
                    WHERE Id = @Id;
                ";

                MedicalReport? medicalReport = connection.Query<MedicalReport>(sql, new { Id = id }).FirstOrDefault();

                connection.Close();

                return medicalReport;
            }
        }
    }
}
