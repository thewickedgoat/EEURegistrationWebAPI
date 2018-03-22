using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEUDataBase_DLL.Entities
{
    public class HolidayYear : AbstractEntity
    {
        public HolidayYearSpec CurrentHolidayYear { get; set; }
        public List<Month> Months { get; set; }
        public Employee Employee { get; set; }
        public bool IsClosed { get; set; }
        public double HolidayAvailable { get; set; }
        public double HolidayFreedayAvailable { get; set; }
        public double HolidaysUsed { get; set; }
        public double HolidayFreedaysUsed { get; set; }
        public double HolidayTransfered { get; set; }
    }
}
