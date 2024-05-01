using Microsoft.EntityFrameworkCore;
using PatientLog.Domain.Entities;

namespace PatientLog.Data.Contexts
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicalReport>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<MedicalReport>()
                .HasOne(x => x.Patient)
                .WithMany(x => x.MedicalReports)
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<MedicalReport>()
                .HasOne(x => x.Doctor)
                .WithMany(x => x.MedicalReports)
                .HasForeignKey(x => x.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<MedicalReport>()
                .HasOne(x => x.Appointment)
                .WithMany(x => x.MedicalReports)
                .HasForeignKey(x => x.AppointmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }


        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<MedicalReport> MedicalReports { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleUser> RoleUsers { get; set; }
    }
}
