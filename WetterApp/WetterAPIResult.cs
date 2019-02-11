using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WetterApp
{

    public class WetterAPIResult
    {
        public Weather[] weather { get; set; }
        public Main main { get; set; }
    }

    public class Main
    {
       
        public double temp { get; set; }
    }

    public class Weather
    {
        public string icon { get; set; }
    }

}
