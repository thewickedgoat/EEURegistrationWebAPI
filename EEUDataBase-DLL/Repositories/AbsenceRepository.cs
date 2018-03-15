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
    class AbsenceRepository : IAbsenceRepository
    {
        private IContext context;

        /*
         * Fetches the database context and returns it
         */
        private IContext GetContext()
        {
            if (context.GetType().FullName.Equals("EEU_DLL.Models.ApplicationDbContext"))
            {
                return new ApplicationDbContext();
            }
            return context;
        }

        public AbsenceRepository(IContext context)
        {
            this.context = context;
        }

        /*
         * Writes incoming Absence to the database, and return it with an id
         */
        public Absence Create(Absence t)
        {
            using(var dbContext = GetContext())
            {
                var type = context.GetType();
                t.Month = dbContext.Months.FirstOrDefault(x => x.Id == t.Month.Id);
                t.Status = dbContext.Statuses.FirstOrDefault(x => x.Id == t.Status.Id);
                dbContext.Absences.Add(t);
                dbContext.SaveChanges();
                return t;
            }
        }

        /*
         * Deletes the Absence in the database with an matching ID
         * returns true or false depending on success or failure respectively
         */
        public bool Delete(int id)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var toBeDeleted = dbContext.Absences.FirstOrDefault(x => x.Id == id);
                if (toBeDeleted != null)
                {
                    dbContext.Absences.Remove(toBeDeleted);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        /*
         * Reads all absences in the databse in the form of a list
         */
        public List<Absence> ReadAll()
        {
            {
                using (var dbContext = GetContext())
                {
                    return dbContext.Absences.Include("Status").ToList();
                }
            }
        }

        /*
         * Returns a single absence based on the incoming ID
         */
        public Absence ReadById(int id)
        {
            using (var dbContext = GetContext())
            {
                return dbContext.Absences
                    .Include("Status")
                    .Include("Month")
                    .FirstOrDefault(x => x.Id == id);
            }
        }

        /*
         * Returns a list<Absence> with date equal or smaller to firstDate, and equal or larger to lastDate
         */
        public List<Absence> ReadFromDateToDate(DateTime startDate, DateTime endDate)
        {
            using (var dbContext = GetContext())
            {
                var absencesInRange = (IQueryable<Absence>)from a in dbContext.Absences.Include("Status") where a.Date >= startDate && a.Date <= endDate select a;
                return absencesInRange.ToList();
            }
        }

        /*
         * Updates the Absence with an Id equal to the recieved Absence.
         * Returns the recieved absence
         */
        public Absence Update(Absence t)
        {
            using (var dbContext = GetContext())
            {
                t.Status = dbContext.Statuses.FirstOrDefault(x => x.Id == t.Status.Id);
                t.Month = dbContext.Months.Include(m => m.Employee).FirstOrDefault(x => x.Id == t.Month.Id);
                var oldAbsence = dbContext.Absences.Include("Status").Include("Month").FirstOrDefault(x => x.Id == t.Id);
                oldAbsence.Status = t.Status;
                dbContext.MarkAbsenceAsModified(t, oldAbsence);
                dbContext.SaveChanges();
                return t;
            }
        }
    }
}
