using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEUDataBase_DLL.Entities
{
    public enum Role
    {
        Medarbejder, Afdelingsleder, Administrator, CEO
    }
    public class Employee: AbstractEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        public List<HolidayYear> HolidayYears { get; set; }
        public Role EmployeeRole { get; set; }
        public Department Department { get; set; }
        public List<WorkfreeDay> WorkfreeDays { get; set; }
        public string Note { get; set; }
    }
}
