using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EEUDataBase_DLL.Entities;

namespace EEUDataBase_DLL.Interfaces
{
    /*
     * This interface allows implementing classes to read a date-interval and still allowing to use IDataBase functionality
     */
    public interface IAbsenceDB : IDataBase<Absence,int>
    {
        List<Absence> ReadFromDateToDate(DateTime startDate, DateTime endDate);
    }
}
