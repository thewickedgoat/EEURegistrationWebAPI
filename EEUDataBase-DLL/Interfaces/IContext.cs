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
        DbSet<Employee> Employees { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Absence> Absences { get; set; }
        int SaveChanges();
        void MarkEmployeeAsModified(Employee newEmployee, Employee employeeToUpdate);
        void MarkAbsenceAsModified(Absence newAbsence, Absence absenceToUpdate);
        void MarkDepartmentAsModified(Department department);
    }
}
