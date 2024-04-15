using Heliondata.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore;

namespace Heliondata.Data
{
    public class HelionDBContext : DbContext
    {
        // Define your DbSet properties here, each representing a table in your database
        // For example:
        // public DbSet<YourEntity> YourEntities { get; set; }
        public DbSet<Company> Companies { get; set; }

        // Constructor to pass options to the base DbContext class    public DbSet<Book> Book { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=library;user=user;password=password");
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
                entity.HasKey(e => e.Name);
                entity.Property(e => e.Title).IsRequired();
                entity.HasOne(d => d.Publisher)
            .WithMany(p => p.Books);
            });
        }
    }
}
}