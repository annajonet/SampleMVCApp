using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PricingQueryApplication.Models
{
    public class Address
    {
        string line1;
        string city;
        string postCode;
        string country;

        public string Line1 { get => line1; set => line1 = value; }
        public string City { get => city; set => city = value; }
        public string PostCode { get => postCode; set => postCode = value; }
        public string Country { get => country; set => country = value; }
    }
}