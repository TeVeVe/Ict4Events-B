using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClasses.Models
{
    class Event
    {
        public DateTime EndDate { get; set; }
        public int MaxGuests { get; set; }
        public String Name { get; set; }
        public DateTime StartDate { get; set; }

        public int GetVisitorsInside()
        {
            throw new NotImplementedException();
        }
    }
}
