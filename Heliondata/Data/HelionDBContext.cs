using Heliondata.Models;
using Microsoft.EntityFrameworkCore;

namespace Heliondata.Data
{
    public class HelionDBContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Representative> Representatives { get; set; }
        public DbSet<Workplace> Workplaces { get; set; }
        public DbSet<Models.System> Systems { get; set; }
        public DbSet<Process> Processes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=helion;user=root;password=1234");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(d => d.LastName).IsRequired();
                entity.Property(d => d.Position).IsRequired();
            });
        }
    }
}