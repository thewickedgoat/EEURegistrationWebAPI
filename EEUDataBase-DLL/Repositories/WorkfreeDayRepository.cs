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
    class WorkfreeDayRepository : IWorkfreeDayRepository
    {
        private IContext context;

        private IContext GetContext()
        {
            if (context.GetType().FullName.Equals("EEUDataBase_DLL.Models.ApplicationDbContext"))
            {
                return new ApplicationDbContext();
            }
            return context;
        }

        public WorkfreeDayRepository(IContext context)
        {
            this.context = context;
        }

        public WorkfreeDay Create(WorkfreeDay t)
        {
            using (var dbContext = GetContext())
            {
                t.Employee = dbContext.Employees.FirstOrDefault(x => x.Id == t.Employee.Id);
                dbContext.WorkfreeDays.Add(t);
                dbContext.SaveChanges();
                return t;
            }
        }

        public List<WorkfreeDay> CreateWorkfreeDays(List<WorkfreeDay> t)
        {
            using (var dbContext = GetContext())
            {
                foreach (var workfreeDay in t)
                {
                    workfreeDay.Employee = dbContext.Employees.FirstOrDefault(x => x.Id == workfreeDay.Employee.Id);
                    dbContext.WorkfreeDays.Add(workfreeDay);
                }
                dbContext.SaveChanges();
                return t;
            }
        }

        public bool Delete(int id)
        {
            using (var dbContext = GetContext())
            {
                var toBeDeleted = dbContext.WorkfreeDays.FirstOrDefault(s => s.Id == id);
                if (toBeDeleted != null)
                {
                    dbContext.WorkfreeDays.Remove(toBeDeleted);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public List<WorkfreeDay> ReadAll()
        {
            using (var dbContext = GetContext())
            {
                return dbContext.WorkfreeDays.ToList();
            }
        }

        public WorkfreeDay ReadById(int id)
        {
            using (var dbContext = GetContext())
            {
                return dbContext.WorkfreeDays.FirstOrDefault(s => s.Id == id);
            }
        }

        public WorkfreeDay Update(WorkfreeDay t)
        {
            using (var dbContext = GetContext())
            {
                var oldWorkfreeDay = dbContext.WorkfreeDays.FirstOrDefault(s => s.Id == t.Id);
                dbContext.MarkWorkfreeDayAsModified(t, oldWorkfreeDay);
                dbContext.SaveChanges();
                return t;
            }
        }
    }
}
