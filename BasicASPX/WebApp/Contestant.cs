using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class Contestant
    {
        private string _StreetAddress2;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 {
            get
            {
                return _StreetAddress2;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _StreetAddress2 = null;
                }
                else
                {
                    _StreetAddress2 = value;
                }
            }
        }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }

        public Contestant()
        {

        }
        public Contestant(string firstName, string lastName, string streetAddress1, string streetAddress2, string city, string province, string postal, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            StreetAddress1 = streetAddress1;
            StreetAddress2 = streetAddress2;
            City = city;
            Province = province;
            PostalCode = postal;
            Email = email;
        }
    }
}