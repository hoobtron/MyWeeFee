using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MyWeeFee.Models
{
    public class MyWeeFeeContext : DbContext
    {        
        public DbSet<Admin> T_Admins { get; set; }
        public DbSet<Teacher> T_Teachers { get; set; }
        public DbSet<Student> T_Students { get; set; }
        public DbSet<Class> T_Classes { get; set; }
        public DbSet<Accesspoint> T_Accesspoints { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=MyWeeFee.db");
        }

        // define primary and foreign keys for DB Model entities
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<Admin>()
                .HasKey(a => a.Email);

            modelBuilder.Entity<Student>()
                .HasKey(s => s.Email);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Class)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.Class)
                .HasPrincipalKey(c => c.ClassName);
                
            modelBuilder.Entity<Teacher>()
                .HasKey(t => t.Email);

            modelBuilder.Entity<Accesspoint>()
                .HasKey(a => a.Location);

            modelBuilder.Entity<Class>()
                .HasKey(c => c.ClassName);

        }
    }
}