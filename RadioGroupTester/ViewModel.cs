using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioGroupTester
{
    internal enum Roles { Angestellter, Abteilungsleiter, CEO, Shareholder   }

    class ViewModel
    {
        public Roles Role { get; set; } = Roles.Angestellter;
    }
}
