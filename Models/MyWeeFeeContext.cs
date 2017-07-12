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
            optionsBuilder.UseSqlite("Data Source=myweefee.db");
        }
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
    
    interface IUserControl
    {
        void logout();
        void login(string Email, string Password);
        void listUsers();
        void setStudent(Student Student);
        void toggleBlockStatus(Student Student);
    }

    public class User
    {
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Surename { get; set; }
        public string Password { get; set; }
    }

    public class Admin : User, IUserControl
    {
        public void logout() {}
        public void login(string Email, string Password) {}
        public void listUsers() {}
        public void setStudent(Student Student) {}
        public void toggleBlockStatus(Student Student){}
        public void setTeacher(Teacher Teacher) {}
        public void setClass(string Classname) {}
        public void listAPs() {}
        public void setAP(Accesspoint AP) {}
    }

    public class Teacher : User, IUserControl
    {
        public void logout() {}
        public void login(string Email, string Password) {}
        public void listUsers() {}
        public void setStudent(Student Student) {}
        public void toggleBlockStatus(Student Student){}
        public void reqClass(string Classname) {}
        public void setClass(Student Student, string Classname) {}
        public void toggleExamMode(Class Class) {}
    }
    
    public class Student : User
    {
        public bool IsBlocked { get; set; }
        public Class Class { get; set; }
    }
    
    public class Class
    {
        public string ClassName { get; set; }
        public bool ExamMode { get; set; }
        public List<Student> Students { get; set; }
    }

    public class Accesspoint
    {
        public string Location { get; set; }
        public string SSID { get; set; }
        public string Encryption { get; set; }
    }
}