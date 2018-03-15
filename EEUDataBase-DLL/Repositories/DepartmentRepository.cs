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
    class DepartmentRepository : IRepository<Department, int>
    {
        private IContext context;

        public DepartmentRepository(IContext context)
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
         * Writes the given Department to the database, returns it with an Id.
         */
        public Department Create(Department t)
        {
            using (var dbContext = GetContext())
            {
                dbContext.Departments.Add(t);
                dbContext.SaveChanges();
                return t;
            }
        }
        /*
         * Deletes the Department with Id matching to the given id on the database.
         * Returns true or false based on success or failure respectively
         */
        public bool Delete(int id)
        {
            using (var dbContext = GetContext())
            {
                var toBeDeleted = dbContext.Departments.Include("Employees").FirstOrDefault(x => x.Id == id);
                if (toBeDeleted != null && toBeDeleted.Id != 1)
                {
                    foreach (var employee in toBeDeleted.Employees)
                    {
                        employee.Department = dbContext.Departments.FirstOrDefault(x => x.Id == 1);
                    }
                    dbContext.Departments.Remove(toBeDeleted);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        /*
         * Returns a List<Department> of all Departments in the database
         */
        public List<Department> ReadAll()
        {
            using (var dbContext = GetContext())
            {
                List<Department> departments = dbContext.Departments
                    .Include(d => d.Employees.Select(e => e.HolidayYears.Select(h => h.Months.Select(m => m.AbsencesInMonth.Select(a => a.Status))))).ToList();
                //foreach (var department in departments)
                //{
                //    foreach (var employee in department.Employees)
                //    {
                //        List<HolidayYear> holidayYears = dbContext.Employees.Include("HolidayYears").FirstOrDefault(x => x.Id == employee.Id).HolidayYears.ToList();
                //        if (holidayYears != null)
                //        {
                //            employee.HolidayYears = holidayYears;
                //        }
                //        else
                //        {
                //            employee.HolidayYears = new List<HolidayYear>();
                //        }
                //    }
                //}
                return departments;
            }
        }
        /*
         * Returns a single Department based on the incoming ID
         */
        public Department ReadById(int id)
        {
            using (var dbContext = GetContext())
            {
                return dbContext.Departments
                    .Include(d => d.Employees.Select(e => e.HolidayYears.Select(h => h.Months.Select(m => m.AbsencesInMonth.Select(a => a.Status))))).FirstOrDefault(x => x.Id == id);
            }
        }

        /*
         * Overwrites the Department in the database with equal Id to the given Department. 
         * Returns the given Department.
         */
        public Department Update(Department t)
        {
            using (var dbContext = GetContext())
            {
                dbContext.MarkDepartmentAsModified(t);
                dbContext.SaveChanges();
                return t;
            }
        }

        
    }
}
