﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEUDataBase_DLL.Entities
{
    public class Status : AbstractEntity
    {
        public string StatusCode { get; set; }
        public string StatusName { get; set; }
    }
}
