using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EEUDataBase.Models
{
    public class UserLoginInfoViewModel
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }
    }
}