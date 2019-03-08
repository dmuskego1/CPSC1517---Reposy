using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class GridViewData
    {
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string FullOrPartTime { get; set; }
        public string Jobs { get; set; }

        public GridViewData()
        {

        }
        public GridViewData(string fullName, string email, string phoneNum, string fullOrPartTime, string jobs)
        {
            FullName = fullName;
            EmailAddress = email;
            PhoneNumber = phoneNum;
            FullOrPartTime = fullOrPartTime;
            Jobs = jobs;
        }

    }
}