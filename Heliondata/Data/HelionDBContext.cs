using Heliondata.Models;
using Heliondata.Models.JoinModels;
using Microsoft.EntityFrameworkCore;

namespace Heliondata.Data
{
    public class HelionDBContext : DbContext
    {
        public HelionDBContext(DbContextOptions<HelionDBContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Representative> Representatives { get; set; }
        public DbSet<Workplace> Workplaces { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<ProcessWorkplace> ProcessWorkplaces { get; set; }
        public DbSet<EmployeeProcess> EmployeeProcesses { get; set; }
        public DbSet<ProcessService> ProcessServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>()
            .HasDiscriminator<string>("Discriminator")
            .HasValue<Company>("Company")
            .HasValue<PFA>("PFA")
            .HasValue<SRL>("SRL");


            modelBuilder.Entity<Service>().HasData(
            new Service { ID = 1, Name = "CCTV" },
            new Service { ID = 2, Name = "Security" }
            );

            modelBuilder.Entity<Workplace>().HasData(
            new Workplace { ID = 1, Name = "Headquarters", Zone = "Downtown", City = "New York", Address = "123 5th Ave" },
            new Workplace { ID = 2, Name = "Branch Office", Zone = "Uptown", City = "New York", Address = "456 7th Ave" }
            );
            modelBuilder.Entity<Company>().HasData(
                new { ID = 1, CUI = 1234589, Name = "Company A", Discriminator = "Company" },
                new { ID = 2, CUI = 9876521, Name = "Company B", Discriminator = "Company" }
            );

            modelBuilder.Entity<PFA>().HasData(
                new { ID = 3, CUI = 1112234, Name = "PFA John Doe", CNP = 12567890, Activity = "Freelancing", Discriminator = "PFA" }
            );

            modelBuilder.Entity<SRL>().HasData(
                new { ID = 4, CUI = 2223455, Name = "SRL Quick Services", RegistrationCode = 56789234, Discriminator = "SRL" }
            );

            modelBuilder.Entity<Representative>().HasData(
                new Representative { ID = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Position = "Manager", CompanyID = 1 },
                new Representative { ID = 2, FirstName = "Alice", LastName = "Smith", Email = "alice.smith@example.com", Position = "Supervisor", CompanyID = 1 },
                new Representative { ID = 3, FirstName = "Bob", LastName = "Johnson", Email = "bob.johnson@example.com", Position = "Director", CompanyID = 2 },
                new Representative { ID = 4, FirstName = "Emma", LastName = "Brown", Email = "emma.brown@example.com", Position = "Coordinator", CompanyID = 2 }
            );

            modelBuilder.Entity<Employee>().HasData(
            new Employee { ID = 1, FirstName = "Sam", LastName = "Wilson", Position = "Analyst" },
            new Employee { ID = 2, FirstName = "Lucy", LastName = "Hart", Position = "Manager" }
            );

            modelBuilder.Entity<Process>().HasData(
                new Process { ID = 1, CompanyId = 1, SignDate = DateTime.Parse("2024-04-01"), RepresentativeId = 1, ESignature = Convert.FromBase64String("U2lnbmF0dXJlMURhdGE="), GPSLocation = "47.0428222 21.9190659" },
                new Process { ID = 2, CompanyId = 2, SignDate = DateTime.Parse("2024-04-02"), RepresentativeId = 2, ESignature = Convert.FromBase64String("U2lnbmF0dXJlMURhdGE="), GPSLocation = "27.1433222 32.9123659" }
            );

            modelBuilder.Entity<EmployeeProcess>().HasData(
            new EmployeeProcess { ID = 1, EmployeeId = 1, ProcessId = 1 },
            new EmployeeProcess { ID = 2, EmployeeId = 2, ProcessId = 2 }
            );
            modelBuilder.Entity<ProcessService>().HasData(
            new ProcessService { ID = 1, ServiceId = 1, ProcessId = 1 },
            new ProcessService { ID = 2, ServiceId = 2, ProcessId = 2 }
            );

            modelBuilder.Entity<ProcessWorkplace>().HasData(
            new ProcessWorkplace { ID = 1, WorkplaceId = 1, ProcessId = 1 },
            new ProcessWorkplace { ID = 2, WorkplaceId = 2, ProcessId = 2 }
            );
        }



    }
}