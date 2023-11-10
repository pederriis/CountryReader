using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryReader
{
    public class Country
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Country()
        {

        }

        public Country(int iD, string name)
        {
            ID = iD;
            Name = name;
        }
    }
}

   

