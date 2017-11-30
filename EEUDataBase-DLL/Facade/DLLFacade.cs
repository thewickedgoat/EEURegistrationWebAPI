using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EEUDataBase_DLL.Entities;
using EEUDataBase_DLL.Interfaces;
using EEUDataBase_DLL.Repositories;

namespace EEUDataBase_DLL.Facade
{
    public class DLLFacade
    {
        private IAbsenceDB absenceDB;

        private IDataBase<Department, int> departmentDB;

        private IDataBase<Employee, int> employeeDB;

        public IAbsenceDB GetAbsenceDB(IContext context)
        {
            return absenceDB ?? (absenceDB = new AbsenceDB(context));
        }

        public IDataBase<Department, int> GetDepartmentDB(IContext context)
        {
            return departmentDB ?? (departmentDB = new DepartmentDB(context));
        }

        public IDataBase<Employee, int> GetEmployeeDB(IContext context)
        {
            return employeeDB ?? (employeeDB = new EmployeeDB(context));
        }
    }
}
