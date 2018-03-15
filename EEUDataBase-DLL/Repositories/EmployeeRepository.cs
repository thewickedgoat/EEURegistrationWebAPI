using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EEUDataBase_DLL.Entities;
using EEUDataBase_DLL.Interfaces;
using EEUDataBase_DLL.Models;

namespace EEUDataBase_DLL.Repositories
{
    class EmployeeRepository : IRepository<Employee, int>
    {
        private IContext context;

        public EmployeeRepository(IContext context)
        {
            this.context = context;
        }
        /*
         * Fetches the database context and returns it
         */
        private IContext GetContext()
        {
            if (context.GetType().FullName.Equals("EEUDataBase_DLL.Models.ApplicationDbContext"))
            {
                return new ApplicationDbContext();
            }
            return context;
        }
        /*
         * Writes the given Employee to the database, returns it with an Id.
         */
        public Employee Create(Employee t)
        {
            using (var dbContext = GetContext())
            {
                var type = context.GetType();
                t.Department = dbContext.Departments.FirstOrDefault(x => x.Id == t.Department.Id);
                dbContext.Employees.Add(t);
                dbContext.SaveChanges();
                return t;
            }
        }
        /*
         * Deletes the Employee in the database with an matching ID
         * returns true or false depending on success or failure respectively
         */
        public bool Delete(int id)
        {
            using (var dbContext = GetContext())
            {
                var toBeDeleted = dbContext.Employees.Include(e => e.HolidayYears).FirstOrDefault(x => x.Id == id);
                if (toBeDeleted != null)
                {
                    dbContext.Employees.Remove(toBeDeleted);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        /*
         * Reads all Employees in the databse in the form of a list
         */
        public List<Employee> ReadAll()
        {
            using (var dbContext = GetContext())
            {
                return dbContext.Employees.Include(e => e.Department)
                    .Include(e => e.HolidayYears.Select(h => h.Months.Select(m => m.AbsencesInMonth.Select(a => a.Status))))
                    .ToList();
            }
        }
        /*  
         * Returns a single Employee based on the incoming ID
         */
        public Employee ReadById(int id)
        {
            using (var dbContext = GetContext())
            {
                return dbContext.Employees
                    .Include(e => e.Department)
                    .Include(e => e.WorkfreeDays)
                    .Include(e => e.HolidayYears.Select(h => h.Months.Select(m => m.AbsencesInMonth.Select(a => a.Status))))
                    .FirstOrDefault(x => x.Id == id);
            }
        }

        /*
         * Updates the Employee with an Id equal to the recieved Employee.
         * Returns the updated employee
         */
        public Employee Update(Employee t)
        {
            using (var dbContext = GetContext())
            {
                t.Department = dbContext.Departments.Include("Employees").FirstOrDefault(x => x.Id == t.Department.Id);
                var oldEmployee = dbContext.Employees.FirstOrDefault(x => x.Id == t.Id);
                oldEmployee.Department = t.Department;
                dbContext.MarkEmployeeAsModified(t, oldEmployee);
                dbContext.SaveChanges();
                return t;
            }
        }
    }
}
