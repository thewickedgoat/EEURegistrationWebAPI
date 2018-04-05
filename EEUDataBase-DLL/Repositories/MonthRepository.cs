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
    class MonthRepository : IMonthRepository
    {
        private IContext context;

        public MonthRepository(IContext context)
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
        public Month Create(Month t)
        {
            using(var dbContext = GetContext())
            {
                t.HolidayYear = dbContext.HolidayYears.FirstOrDefault(x => x.Id == t.HolidayYear.Id);
                dbContext.Months.Add(t);
                dbContext.SaveChanges();
                return t;
            }
        }

        public List<Month> CreateMonths(List<Month> t)
        {
            using(var dbContext = GetContext())
            {
                foreach(var month in t)
                {
                    month.HolidayYear = dbContext.HolidayYears.FirstOrDefault(x => x.Id == month.HolidayYear.Id);
                    dbContext.Months.Add(month);
                }
                dbContext.SaveChanges();
                return t;
            }
        }

        public bool Delete(int id)
        {
            
            using(var dbContext = GetContext())
            {
                var toBeDeleted = dbContext.Months.Include("AbsencesInMonth").FirstOrDefault(m => m.Id == id);
                if(toBeDeleted != null)
                {
                    dbContext.Months.Remove(toBeDeleted);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public List<Month> ReadAll()
        {
            using(var dbContext = GetContext())
            {
                return dbContext.Months
                    .Include("HolidayYear")
                    .Include(m => m.AbsencesInMonth.Select(a => a.Status))
                    .AsNoTracking()
                    .ToList();
            }
        }

        public Month ReadById(int id)
        {
            using(var dbContext = GetContext())
            {
                return dbContext.Months
                    .Include("HolidayYear")
                    .Include(m => m.AbsencesInMonth.Select(a => a.Status))
                    .Include(m => m.AbsencesInMonth.Select(a => a.Month))
                    .FirstOrDefault(m => m.Id == id);
            }
        }

        public Month Update(Month t)
        {
            using(var dbContext = GetContext())
            {
                var oldMonth = dbContext.Months
                    .Include("HolidayYear")
                    .Include(m => m.AbsencesInMonth.Select(a => a.Status))
                    .FirstOrDefault(m => m.Id == t.Id);
                dbContext.MarkMonthAsModified(t, oldMonth);
                dbContext.SaveChanges();
                return t;
            }
        }
    }
}
