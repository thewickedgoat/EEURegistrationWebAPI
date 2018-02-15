using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEUDataBase_DLL.Entities
{
    
    public class Absence : AbstractEntity
    {
        public DateTime Date { get; set; }
        public Status Status { get; set; }
        public Month Month { get; set; }
    }
}
