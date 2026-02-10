using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace GrindsBookingSystem
{
    public abstract class Person
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }

        protected Person() : this(0, "", "", "", "", "") { }

        protected Person(int id, string name, string sname, string email, string phoneNo, String status)
        {
            PersonID = id;
            FirstName = name;
            Surname = sname;
            Email = email;
            Phone = phoneNo;
            Status = "A";
        }

        public override String ToString()
        {
            return "ID : " + PersonID + "\nName : " + FirstName + " " + Surname +
                "\nEmail Address : " + Email + "\nPhone Number : " + Phone +
                "\nStatus : " + Status;
        }

    }
}
