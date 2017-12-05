using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EEUDataBase_DLL.Entities;
using EEUDataBase_DLL.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace EEUDataBase_DLL.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new ApplicationDBInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasOptional(e => e.Department).WithMany(d => d.Employees);
            //.WillCascadeOnDelete(false);

            modelBuilder.Entity<Absence>().HasRequired(a => a.Employee).WithMany(e => e.Absences);

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Absence> Absences { get; set; }
        public void MarkAbsenceAsModified(Absence newAbsence, Absence absenceToUpdate)
        {
            Entry(absenceToUpdate).CurrentValues.SetValues(newAbsence);
        }

        public DbSet<Department> Departments { get; set; }
        public void MarkDepartmentAsModified(Department department)
        {
            Entry(department).State = EntityState.Modified;
        }
        public DbSet<Employee> Employees { get; set; }
        public void MarkEmployeeAsModified(Employee newEmployee, Employee employeeToUpdate)
        {
            Entry(employeeToUpdate).CurrentValues.SetValues(newEmployee);
        }
    }
}
