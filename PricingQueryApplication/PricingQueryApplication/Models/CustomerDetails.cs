using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PricingQueryApplication.Models
{
    public class CustomerDetails
    {
        string firstName;
        string lastName;
        string email;
        string phone;
        Address address;


        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public Address Address { get => address; set => address = value; }
    }
}