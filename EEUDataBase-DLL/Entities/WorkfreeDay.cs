using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEUDataBase_DLL.Entities
{
    public class WorkfreeDay: AbstractEntity
    {
        public DateTime Date { get; set; }
        public Employee Employee { get; set; }
    }
}
