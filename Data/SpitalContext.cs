using Microsoft.EntityFrameworkCore;
using Bledea_Aurica_Iuliana_SpitalApp.Models;

namespace Bledea_Aurica_Iuliana_SpitalApp.Data
{
    // clasa trebuie sa mosteneasca DbContext
    public class SpitalContext : DbContext
    {
        // constructor care primeste optiunile de configurare
        public SpitalContext(DbContextOptions<SpitalContext> options)
            : base(options)
        {
        }

        // definim cate un DbSet pentru fiecare model
        // acestea vor deveni tabelele din baza de date
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        // optional putem suprascrie metoda OnModelCreating
        // pentru a adauga configurari suplimentare
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configuram relatiile dintre entitati

            // un departament poate avea mai multi doctori
            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Department)
                .WithMany(d => d.Doctors)
                .HasForeignKey(d => d.DepartmentID);

            // o programare are un singur pacient
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientID);

            // o programare are un singur doctor
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorID);
        }
    }
}