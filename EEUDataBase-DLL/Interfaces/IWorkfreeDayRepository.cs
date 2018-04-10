using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EEUDataBase_DLL.Entities;

namespace EEUDataBase_DLL.Interfaces
{
    public interface IWorkfreeDayRepository : IRepository<WorkfreeDay, int>
    {
       List<WorkfreeDay> CreateWorkfreeDays(List<WorkfreeDay> t);
    }
}
