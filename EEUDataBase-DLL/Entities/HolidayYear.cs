using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEUDataBase_DLL.Entities
{
    public class HolidayYear : AbstractEntity
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Month> Months { get; set; }
        public Employee Employee { get; set; }
        public bool IsClosed { get; set; }
        public int HolidayAvailable { get; set; }
        public int HolidayFreedayAvailable { get; set; }
        public int RemainingHoliday { get; set; }
        public int RemainingHolidayFreedays { get; set; }

    }
}
