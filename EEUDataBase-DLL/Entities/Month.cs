using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEUDataBase_DLL.Entities
{
    public class Month : AbstractEntity
    {
        public DateTime MonthDate { get; set; }
        public List<Absence> AbsencesInMonth { get; set; }
        public HolidayYear HolidayYear { get; set; }
        public bool IsLockedByEmployee { get; set; }
        public bool IsLockedByChief { get; set; }
        public bool IsLockedByCEO { get; set; }
        public bool IsLockedByAdmin { get; set; }

    }
}
