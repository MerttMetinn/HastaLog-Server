using PatientLog.Domain.Dtos.MedicalReportDtos;
using PatientLog.Domain.Entities;
using PatientLog.Service.Abstract;

namespace PatientLog.Service.Concrete
{
    public class MedicalReportService : IMedicalReportService
    {
        public void AddMedicalReport(MedicalReportAddDto medicalReportAddDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteMedicalReport(MedicalReportDeleteDto medicalReportDeleteDto)
        {
            throw new NotImplementedException();
        }

        public List<MedicalReport> GetAllMedicalReports()
        {
            throw new NotImplementedException();
        }

        public MedicalReportGetDto? GetMedicalReportById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
