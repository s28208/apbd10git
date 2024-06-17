using WebApplication2.Models;

namespace WebApplication2.Data;

using Microsoft.EntityFrameworkCore;


public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Patient>().HasData(new List<Patient>
            {
                new Patient {
                    IdPatient = 1,
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    Birthdate = DateOnly.Parse("2004-05-28")
                },
                new Patient {
                    IdPatient = 2,
                    FirstName = "Anna",
                    LastName = "Nowak",
                    Birthdate = DateOnly.Parse("2000-06-15")

                }
            });

            modelBuilder.Entity<Doctor>().HasData(new List<Doctor>
            {
                new Doctor {
                    IdDoctor = 1,
                    FirstName = "Adam",
                    LastName = "Nowak",
                    Email = "adamnowak@gmail.com"
                },
                new Doctor {
                    IdDoctor = 2,
                    FirstName = "Aleksandra",
                    LastName = "Wiśniewska",
                    Email = "aleksandrawislecka@gmail.com"
                }
            });

            modelBuilder.Entity<Medicament>().HasData(new List<Medicament>
            {
                new Medicament
                {
                    IdMedicament = 1,
                    Name = "m1",
                    Description = "description m1",
                    Type = "A"
                },
                new Medicament
                {
                    IdMedicament = 2,
                    Name = "m2",
                    Description = "description m2",
                    Type = "B"
                },
                new Medicament
                {
                    IdMedicament = 3,
                    Name = "m3",
                    Description = "description m3",
                    Type = "A"
                }
            });

            modelBuilder.Entity<Prescription>().HasData(new List<Prescription>
            {
                new Prescription
                {
                    IdPrescription = 1,
                    Date = DateOnly.Parse("2024-05-28"),
                    DueDate = DateOnly.Parse("2024-05-29"),
                    IdPatient = 1,
                    IdDoctor = 2
                },
                new Prescription
                {
                    IdPrescription = 2,
                    Date = DateOnly.Parse("2024-05-31"),
                    DueDate = DateOnly.Parse("2024-06-01"),
                    IdPatient = 1,
                    IdDoctor = 1
                },
                new Prescription
                {
                    IdPrescription = 3,
                    Date = DateOnly.Parse("2024-06-01"),
                    DueDate = null,
                    IdPatient = 2,
                    IdDoctor = 1
                }
            });

            modelBuilder.Entity<PrescriptionMedicament>().HasData(new List<PrescriptionMedicament>
            {
                new PrescriptionMedicament
                {
                    IdPrescription = 1,
                    IdMedicament = 1,
                    Dose = 3,
                    Details = "details 1"
                },
                new PrescriptionMedicament
                {
                    IdPrescription = 1,
                    IdMedicament = 3,
                    Dose = 4,
                    Details = "details 2"
                },
                new PrescriptionMedicament
                {
                    IdPrescription = 2,
                    IdMedicament = 2,
                    Details = "details 3"
                    
                },
                new PrescriptionMedicament
                {
                    IdPrescription = 2,
                    IdMedicament = 1,
                    Details = "details 4"
                }
            });
    }
}