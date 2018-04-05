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
    class HolidayYearSpecRepository : IRepository<HolidayYearSpec, int>
    {
        private IContext context;

        public HolidayYearSpecRepository(IContext context)
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
        public HolidayYearSpec Create(HolidayYearSpec t)
        {
            using (var dbContext = GetContext())
            {
                dbContext.HolidayYearsSpecs.Add(t);
                dbContext.SaveChanges();
                return t;
            }
        }

        public bool Delete(int id)
        {
            using (var dbContext = GetContext())
            {
                var toBeDeleted = dbContext.HolidayYearsSpecs.FirstOrDefault(h => h.Id == id);
                if (toBeDeleted != null)
                {
                    dbContext.HolidayYearsSpecs.Remove(toBeDeleted);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public List<HolidayYearSpec> ReadAll()
        {
            using (var dbContext = GetContext())
            {
                return dbContext.HolidayYearsSpecs
                    .Include(h => h.PublicHolidays)
                    .Include(h => h.HolidayYears.Select(hy => hy.Employee))
                    .AsNoTracking()
                    .ToList();
            }
        }

        public HolidayYearSpec ReadById(int id)
        {
            using (var dbContext = GetContext())
            {
                return dbContext.HolidayYearsSpecs
                    .Include(h => h.PublicHolidays)
                    .Include(h => h.HolidayYears.Select(hy => hy.Employee))
                    .FirstOrDefault(h => h.Id == id);
            }
        }

        public HolidayYearSpec Update(HolidayYearSpec t)
        {
            using (var dbContext = GetContext())
            {
                var oldHolidayYearSpec = dbContext.HolidayYearsSpecs.FirstOrDefault(x => x.Id == t.Id);
                dbContext.MarkHolidayYearSpecAsModified(t, oldHolidayYearSpec);
                dbContext.SaveChanges();
                return t;
            }
        }
    }
}
