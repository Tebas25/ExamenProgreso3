using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProgreso3.Models
{
    public class PaisAPI
    {

        public class Class1
        {
            public Name name { get; set; }
            public string region { get; set; }
            public Maps maps { get; set; }
        }

        public class Name
        {
            public string common { get; set; }
            public string official { get; set; }
            public Nativename nativeName { get; set; }
        }

        public class Nativename
        {
            public Spa spa { get; set; }
        }

        public class Spa
        {
            public string official { get; set; }
            public string common { get; set; }
        }

        public class Maps
        {
            public string googleMaps { get; set; }
            public string openStreetMaps { get; set; }
        }

    }
}
