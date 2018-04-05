using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEUDataBase_DLL.Entities
{
    public class PublicHoliday : AbstractEntity
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public HolidayYearSpec HolidayYearSpec { get; set; }
    }
}
