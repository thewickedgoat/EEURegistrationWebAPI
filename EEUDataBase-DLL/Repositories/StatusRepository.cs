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
    class StatusRepository : IRepository<Status, int>
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

        public StatusRepository(IContext context)
        {
            this.context = context;
        }

        public Status Create(Status t)
        {
            using(var dbContext = GetContext())
            {
                dbContext.Statuses.Add(t);
                dbContext.SaveChanges();
                return t;
            }
        }

        public bool Delete(int id)
        {
            using(var dbContext = GetContext())
            {
                var toBeDeleted = dbContext.Statuses.FirstOrDefault(s => s.Id == id);
                if (toBeDeleted != null)
                {
                    dbContext.Statuses.Remove(toBeDeleted);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public List<Status> ReadAll()
        {
            using(var dbContext = GetContext())
            {
                return dbContext.Statuses.ToList();
            }
        }

        public Status ReadById(int id)
        {
            using(var dbContext = GetContext())
            {
                return dbContext.Statuses.FirstOrDefault(s => s.Id == id);
            }
        }

        public Status Update(Status t)
        {
            using(var dbContext = GetContext())
            {
                var oldStatus = dbContext.Statuses.FirstOrDefault(s => s.Id == t.Id);
                dbContext.MarkStatusAsModified(t, oldStatus);
                dbContext.SaveChanges();
                return t;
            }
        }
    }
}
