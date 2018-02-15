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
            //Modelbuilder for Absences
            modelBuilder.Entity<Absence>().HasRequired(a => a.Status);
            modelBuilder.Entity<Absence>().HasRequired(a => a.Month).WithMany(m => m.AbsencesInMonth);

            //Modelbuilder for Employees
            modelBuilder.Entity<Employee>().HasRequired(e => e.Department).WithMany(d => d.Employees);
            
            //.WillCascadeOnDelete(false); 

            //Modelbuilder for HolidayYear
            modelBuilder.Entity<HolidayYear>().HasRequired(h => h.Employee).WithMany(e => e.HolidayYears).WillCascadeOnDelete(); 

            //Modelbuilder for Months
            modelBuilder.Entity<Month>().HasRequired(m => m.Employee);

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
        public DbSet<HolidayYear> HolidayYears { get; set; }
        public void MarkHolidayYearAsModified(HolidayYear holidayYear)
        {
            Entry(holidayYear).State = EntityState.Modified;
            //Entry(holidayYearToUpdate).CurrentValues.SetValues(newHolidayYear);
        }
        public DbSet<Month> Months { get; set; }
        public void MarkMonthAsModified(Month newMonth, Month monthToUpdate)
        {
            Entry(monthToUpdate).CurrentValues.SetValues(newMonth);
        }
        public DbSet<Status> Statuses { get; set; }
        public void MarkStatusAsModified(Status newStatus, Status statusToUpdate)
        {
            Entry(statusToUpdate).CurrentValues.SetValues(newStatus);
        }
    }
}
