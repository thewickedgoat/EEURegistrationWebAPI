﻿using System;
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
    class HolidayYearRepository : IHolidayYearRepository
    {
        private IContext context;

        public HolidayYearRepository(IContext context)
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
        public HolidayYear Create(HolidayYear t)
        {
            using(var dbContext = GetContext())
            {
                t.CurrentHolidayYear = dbContext.HolidayYearsSpecs.FirstOrDefault(x => x.Id == t.CurrentHolidayYear.Id);
                t.Employee = dbContext.Employees.FirstOrDefault(x => x.Id == t.Employee.Id);
                dbContext.HolidayYears.Add(t);
                dbContext.SaveChanges();
                return t;
            }
        }

        public List<HolidayYear> CreateHolidayYears(List<HolidayYear> t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            using(var dbContext = GetContext())
            {
                var toBeDeleted = dbContext.HolidayYears.FirstOrDefault(h => h.Id == id);
                if(toBeDeleted != null)
                {
                    dbContext.HolidayYears.Remove(toBeDeleted);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public List<HolidayYear> ReadAll()
        {
            using(var dbContext = GetContext())
            {
                return dbContext.HolidayYears
                    .Include(h => h.Employee.Department)
                    .Include(h => h.CurrentHolidayYear.HolidayYears)
                    .Include(h => h.Months.Select(m => m.AbsencesInMonth.Select(a => a.Status)))
                    .AsNoTracking()
                    .ToList();
            }
        }

        public HolidayYear ReadById(int id)
        {
            using (var dbContext = GetContext())
            {
                return dbContext.HolidayYears
                    .Include(h => h.Employee.Department)
                    .Include(h => h.Months.Select(m => m.AbsencesInMonth.Select(a => a.Status)))
                    .Include(h => h.CurrentHolidayYear.PublicHolidays)
                    .FirstOrDefault(h => h.Id == id);
            }
        }

        public HolidayYear Update(HolidayYear t)
        {
            using(var dbContext = GetContext())
            {
                var oldHolidayYear = dbContext.HolidayYears.FirstOrDefault(x => x.Id == t.Id);
                t.CurrentHolidayYear = oldHolidayYear.CurrentHolidayYear;
                t.Months = oldHolidayYear.Months;
                t.Employee = oldHolidayYear.Employee;
                dbContext.MarkHolidayYearAsModified(t, oldHolidayYear);
                dbContext.SaveChanges();
                return t;
            }
        }

       
    }
}
