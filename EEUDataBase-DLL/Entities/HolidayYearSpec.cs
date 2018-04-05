using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEUDataBase_DLL.Entities
{
    public class HolidayYearSpec: AbstractEntity
    {

        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<HolidayYear> HolidayYears { get; set; }
        public List<PublicHoliday> PublicHolidays { get; set; }

    }
}
