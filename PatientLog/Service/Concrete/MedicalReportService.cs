using PatientLog.Data.Repositories.Abstract;
using PatientLog.Domain.Dtos.MedicalReportDtos;
using PatientLog.Domain.Entities;
using PatientLog.Service.Abstract;

namespace PatientLog.Service.Concrete
{
    public class MedicalReportService : IMedicalReportService
    {
        private readonly IMedicalReportRepository _medicalReportRepository;

        public MedicalReportService(IMedicalReportRepository medicalReportRepository)
        {
            _medicalReportRepository = medicalReportRepository;
        }

        public void AddMedicalReport(MedicalReportAddDto medicalReportAddDto)
        {
            var medicalReport = new MedicalReport
            {
                Id = Guid.NewGuid(),
                Date = medicalReportAddDto.Date,
                Path = medicalReportAddDto.Path,
                PatientId = medicalReportAddDto.PatientId,
                DoctorId = medicalReportAddDto.DoctorId,
                AppointmentId = medicalReportAddDto.AppointmentId,
                Details = medicalReportAddDto.Details
            };

            _medicalReportRepository.AddEntity(medicalReport);
        }

        public void DeleteMedicalReport(MedicalReportDeleteDto medicalReportDeleteDto)
        {
            var medicalReport = _medicalReportRepository.GetEntityById(medicalReportDeleteDto.Id);
            if (medicalReport != null)
            {
                _medicalReportRepository.DeleteEntity(medicalReport);
            }
        }

        public List<MedicalReport> GetAllMedicalReports()
        {
            return _medicalReportRepository.GetAllEntities();
        }

        public MedicalReportGetDto? GetMedicalReportById(Guid id)
        {
            var medicalReport = _medicalReportRepository.GetEntityById(id);
            if (medicalReport == null)
            {
                return null;
            }

            return new MedicalReportGetDto
            {
                Id = medicalReport.Id,
                Date = medicalReport.Date,
                Path = medicalReport.Path,
                PatientId = medicalReport.PatientId,
                DoctorId = medicalReport.DoctorId,
                AppointmentId = medicalReport.AppointmentId,
                Details = medicalReport.Details
            };
        }
    }
}
