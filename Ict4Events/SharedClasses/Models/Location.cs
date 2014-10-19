using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClasses.Models
{
    class Location
    {
        public string HouseNumber { get; set; }
        public string Name { get; set; }
        public int SpotCount { get; set; }
        public string Street { get; set; }

        public string GetAddress()
        {
            throw new NotImplementedException();
        }
    }
}
