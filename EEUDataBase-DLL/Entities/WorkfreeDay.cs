using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEUDataBase_DLL.Entities
{
    public enum WorkFreedayType
    {
        Helligdag, Arbejdsfridag
    }

    public class WorkfreeDay: AbstractEntity
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }    
        public Employee Employee { get; set; }
        public WorkFreedayType Type { get; set; }
    }
}
