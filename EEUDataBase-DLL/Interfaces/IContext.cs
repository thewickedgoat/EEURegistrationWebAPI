using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EEUDataBase_DLL.Entities;

namespace EEUDataBase_DLL.Interfaces
{
    public interface IContext : IDisposable
    {
        DbSet<Absence> Absences { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<HolidayYear> HolidayYears { get; set; }
        DbSet<Month> Months { get; set; }
        DbSet<Status> Statuses { get; set; }
        int SaveChanges();
        void MarkAbsenceAsModified(Absence newAbsence, Absence absenceToUpdate);
        void MarkDepartmentAsModified(Department department);
        void MarkEmployeeAsModified(Employee newEmployee, Employee employeeToUpdate);
        void MarkHolidayYearAsModified(HolidayYear holidayYear);
        void MarkMonthAsModified(Month newMonth, Month monthToUpdate);
        void MarkStatusAsModified(Status newStatus, Status statusToUpdate);
    }
}
