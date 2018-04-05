using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EEUDataBase_DLL.Models;
using EEUDataBase_DLL.Entities;
using EEUDataBase_DLL.Interfaces;

namespace EEUDataBase_DLL.Repositories
{
    class PublicHolidayRepository: IRepository<PublicHoliday, int>
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

        public PublicHolidayRepository(IContext context)
        {
            this.context = context;
        }

        public PublicHoliday Create(PublicHoliday t)
        {
            using (var dbContext = GetContext())
            {
                t.HolidayYearSpec = dbContext.HolidayYearsSpecs.FirstOrDefault(x => x.Id == t.HolidayYearSpec.Id);
                dbContext.PublicHolidays.Add(t);
                dbContext.SaveChanges();
                return t;
            }
        }

        public bool Delete(int id)
        {
            using (var dbContext = GetContext())
            {
                var toBeDeleted = dbContext.PublicHolidays.FirstOrDefault(s => s.Id == id);
                if (toBeDeleted != null)
                {
                    dbContext.PublicHolidays.Remove(toBeDeleted);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public List<PublicHoliday> ReadAll()
        {
            using (var dbContext = GetContext())
            {
                return dbContext.PublicHolidays.ToList();
            }
        }

        public PublicHoliday ReadById(int id)
        {
            using (var dbContext = GetContext())
            {
                return dbContext.PublicHolidays.FirstOrDefault(s => s.Id == id);
            }
        }

        public PublicHoliday Update(PublicHoliday t)
        {
            using (var dbContext = GetContext())
            {
                var oldPublicHoliday = dbContext.PublicHolidays.FirstOrDefault(s => s.Id == t.Id);
                dbContext.MarkPublicHolidayAsModified(t, oldPublicHoliday);
                dbContext.SaveChanges();
                return t;
            }
        }
    }
}
