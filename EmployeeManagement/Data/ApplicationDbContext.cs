using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }


        public DbSet<Department> Departments { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
 new Department { DepartmentID = 901, DepartmentName = "Software Development" },
    new Department { DepartmentID = 902, DepartmentName = "Network Administration" },
    new Department { DepartmentID = 903, DepartmentName = "Cybersecurity" },
    new Department { DepartmentID = 904, DepartmentName = "Database Management" },
    new Department { DepartmentID = 905, DepartmentName = "Quality Assurance" },
    new Department { DepartmentID = 906, DepartmentName = "IT Support" },
    new Department { DepartmentID = 907, DepartmentName = "Cloud Services" },
    new Department { DepartmentID = 908, DepartmentName = "Project Management" },
    new Department { DepartmentID = 909, DepartmentName = "DevOps" },
    new Department { DepartmentID = 910, DepartmentName = "Web Development" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}