using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEUDataBase_DLL.Entities
{
    public enum Status
    {
        S, HS, F, HF, FF, HFF, K, B, BS, AF, A, HA, SN, GRAY
    }
    public class Absence : AbstractEntity
    {
        public Employee Employee { get; set; }
        public DateTime Date { get; set; }
        public Status Status { get; set; }

    }
}
