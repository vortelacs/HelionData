using Heliondata.Models;
using Microsoft.EntityFrameworkCore;

namespace Heliondata.Data
{
    public class HelionDBContext : DbContext
    {
        // private HelionDBContext()
        // {
        // }

        // private readonly IConfiguration _configuration;
        // public HelionDBContext(IConfiguration configuration) : this()
        // {
        //     _configuration = configuration;
        // }
        public HelionDBContext(DbContextOptions<HelionDBContext> options) : base(options) { }
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     // string connectionString = _configuration.GetConnectionString("MySqlConnection");
        //     // optionsBuilder.UseSqlServer(connectionString);
        // }


        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Representative> Representatives { get; set; }
        public DbSet<Workplace> Workplaces { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Process> Processes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.Entity<Company>(entity =>
            // {
            //     entity.HasKey(e => e.ID);
            //     entity.Property(e => e.Name).IsRequired();
            // });

            // modelBuilder.Entity<Employee>(entity =>
            // {
            //     entity.HasKey(e => e.ID);
            //     entity.Property(e => e.FirstName).IsRequired();
            //     entity.Property(d => d.LastName).IsRequired();
            //     entity.Property(d => d.Position).IsRequired();
            // });

            // modelBuilder.Entity<Representative>(entity =>
            // {
            //     entity.HasKey(e => e.ID);
            //     entity.Property(e => e.FirstName).IsRequired();
            //     entity.Property(d => d.LastName).IsRequired();
            //     entity.Property(d => d.Position).IsRequired();
            //     entity.Property(d => d.Email).IsRequired();
            // });

            // modelBuilder.Entity<Service>(entity =>
            // {
            //     entity.HasKey(e => e.ID);
            //     entity.Property(e => e.Name).IsRequired();
            // });
            // modelBuilder.Entity<Workplace>(entity =>
            // {
            //     entity.HasKey(e => e.ID);
            //     entity.Property(e => e.Name).IsRequired();
            //     entity.Property(d => d.Zone).IsRequired();
            //     entity.Property(d => d.City).IsRequired();
            //     entity.Property(d => d.Address).IsRequired();
            // });

            // modelBuilder.Entity<Process>(entity =>
            // {
            //     entity.HasKey(e => e.ID);
            //     entity.HasOne(e => e.Company);
            //     entity.HasMany(d => d.EmployeeProcesses)
            //         .WithOne(ep => ep.Process)
            //         .IsRequired();
            //     entity.HasOne(d => d.Representative).WithMany().HasForeignKey(e => e.RepresentativeId);
            //     entity.HasMany(d => d.ProcessServices)
            //         .WithOne(ps => ps.Process)
            //         .IsRequired();
            //     entity.Property(d => d.SignDate).IsRequired();
            //     entity.Property(d => d.ESignature).IsRequired();
            //     entity.Property(d => d.GPSLocation).IsRequired();
            //     entity.Property(d => d.ProcessWorkplaces).IsRequired();
            // });


            // modelBuilder.Entity<EmployeeProcess>(entity =>
            // {
            //     entity.HasKey(ps => ps.ID);
            //     entity.HasOne(ps => ps.Employee)
            //         .WithMany(p => p.EmployeeProcesses)
            //         .HasForeignKey(ps => ps.EmployeeId);
            //     entity.HasOne(ps => ps.Process)
            //         .WithMany(ps => ps.EmployeeProcesses)
            //         .HasForeignKey(ps => ps.ProcessId);
            // });

            // modelBuilder.Entity<ProcessService>(entity =>
            // {
            //     entity.HasKey(ps => ps.ID);
            //     entity.HasOne(ps => ps.Process)
            //         .WithMany(p => p.ProcessServices)
            //         .HasForeignKey(ps => ps.ProcessId);
            //     entity.HasOne(ps => ps.Service)
            //         .WithMany()
            //         .HasForeignKey(ps => ps.ServiceId);
            // });


            // modelBuilder.Entity<ProcessWorkplace>(entity =>
            // {
            //     entity.HasKey(ps => ps.ID);
            //     entity.HasOne(ps => ps.Process)
            //         .WithMany()
            //         .HasForeignKey(ps => ps.Process);
            //     entity.HasOne(ps => ps.Workplace)
            //         .WithMany()
            //         .HasForeignKey(ps => ps.Workplace);
            // });

        }
    }
}