using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Address
    {
        public Address(string addressLine, string country, string city)
        {
            AddressLine = addressLine;
            Country = country;
            City = city;
        }

        public Address(int id, string addressLine, string country, string city)
        {
            Id = id;
            AddressLine = addressLine;
            Country = country;
            City = city;
        }

        public int Id { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

    }
}

