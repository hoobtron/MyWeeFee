using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MyWeeFee.Models
{
    // The MyWeeFeeContext object handles the task of connecting to the database 
    // and mapping Admin (Teacher, etc) objects to database records
    public class MyWeeFeeContext : DbContext
    {  
        public MyWeeFeeContext (DbContextOptions<MyWeeFeeContext> options)
            : base(options)
        {
        }
      
        public DbSet<Admin> T_Admins { get; set; }
        public DbSet<Teacher> T_Teachers { get; set; }
        public DbSet<Class> T_Classes { get; set; }
        public DbSet<Student> T_Students { get; set; }
        public DbSet<Accesspoint> T_Accesspoints { get; set; }
        public DbSet<APEncryption> T_APEncryptions { get; set; }
        public DbSet<Logitem> T_Logitems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=MyWeeFee.db");
        }

        // constraints in Fluent API notation
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // define primary and foreign keys for DB Model entities
            modelBuilder.Entity<Admin>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Student>()
                .HasKey(s => s.Id);
                
            modelBuilder.Entity<Class>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Class)
                .WithMany(s => s.Students)
                .HasForeignKey(s => s.Id);
                
            modelBuilder.Entity<Teacher>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Accesspoint>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<APEncryption>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Logitem>()
                .HasKey(l => l.Id);

            // set default values
            modelBuilder.Entity<Accesspoint>()
                    .Property(a => a.SSID)
                    .HasDefaultValue("OSZimt MyWeeFee");

            // modelBuilder.Entity<Logitem>()
            //     .Property(l => l.Created)
            //     .HasDefaultValueSql("getdate()");

            // the default value for bools (Student.IsBlocked and Class.ExamMode) is false
        }
    }
}