using PatientLog.Domain.Dtos.MedicalReportDtos;
using PatientLog.Domain.Entities;

namespace PatientLog.Service.Abstract
{
    public interface IMedicalReportService
    {
        void AddMedicalReport(MedicalReportAddDto medicalReportAddDto);
        void DeleteMedicalReport(MedicalReportDeleteDto medicalReportDeleteDto);
        List<MedicalReport> GetAllMedicalReports();
        MedicalReportGetDto? GetMedicalReportById(Guid id);
    }
}
