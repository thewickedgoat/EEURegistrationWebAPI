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
        private IAbsenceRepository absenceRepository;

        private IRepository<Department, int> departmentRepository;

        private IRepository<Employee, int> employeeRepository;

        private IRepository<HolidayYear, int> holidayYearRepository;

        private IRepository<HolidayYearSpec, int> holidayYearSpecRepository;

        private IRepository<PublicHoliday, int> publicHolidayRepository;

        private IMonthRepository monthRepository;

        private IRepository<Status, int> statusRepository;

        private IRepository<WorkfreeDay, int> workfreeDayRepository;

        public IAbsenceRepository GetAbsenceRepository(IContext context)
        {
            return absenceRepository ?? (absenceRepository = new AbsenceRepository(context));
        }

        public IRepository<Department, int> GetDepartmentRepository(IContext context)
        {
            return departmentRepository ?? (departmentRepository = new DepartmentRepository(context));
        }

        public IRepository<Employee, int> GetEmployeeRepository(IContext context)
        {
            return employeeRepository ?? (employeeRepository = new EmployeeRepository(context));
        }

        public IRepository<Status, int> GetStatusRepository(IContext context)
        {
            return statusRepository ?? (statusRepository = new StatusRepository(context));
        }

        public IRepository<HolidayYear, int> GetHolidayYearRepository(IContext context)
        {
            return holidayYearRepository ?? (holidayYearRepository = new HolidayYearRepository(context));
        }

        public IRepository<HolidayYearSpec, int> GetHolidayYearSpecRepository(IContext context)
        {
            return holidayYearSpecRepository ?? (holidayYearSpecRepository = new HolidayYearSpecRepository(context));
        }

        public IRepository<PublicHoliday, int> GetPublicHolidayRepository(IContext context)
        {
            return publicHolidayRepository ?? (publicHolidayRepository = new PublicHolidayRepository(context));
        }

        public IMonthRepository GetMonthRepository(IContext context)
        {
            return monthRepository ?? (monthRepository = new MonthRepository(context));
        }

        public IRepository<WorkfreeDay, int> GetWorkfreeDayRepository(IContext context)
        {
            return workfreeDayRepository ?? (workfreeDayRepository = new WorkfreeDayRepository(context));
        }
    }
}
