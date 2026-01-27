using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GrindsBookingSystem
{
    public class Tutor
    {
        public int TutorID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string RateCode { get; set; }
        public string Subject { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }


        public Tutor() : this(0, "", "", "", "","","") { }

        public Tutor(int id, string name, string sname, string rate, string sub, string phoneNo, string emailAddress)
        {
            TutorID = id;
            FirstName = name;
            Surname = sname;
            RateCode = rate;
            Subject = sub;
            Phone = phoneNo;
            Email = emailAddress;
        }
    }
}

