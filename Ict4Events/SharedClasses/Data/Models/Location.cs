using System;
using System.Collections.Generic;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    public class Location
    {
        [Key]
        [FieldName("LOCATIONID")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public int SpotCount { get; set; }
        [DbIgnore]
        public IEnumerable<Spot> Spots { get; set; }

        public string GetAddress()
        {
            throw new NotImplementedException();
        }
    }
}
