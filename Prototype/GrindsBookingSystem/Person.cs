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
        public string Type { get; set; }

        protected Person() : this(0, "", "", "", "") { }

        protected Person(int id, string name, string sname, string email, string phoneNo)
        {
            PersonID = id;
            FirstName = name;
            Surname = sname;
            Email = email;
            Phone = phoneNo;
        }

        public override String ToString()
        {
            return "ID : " + PersonID + "\nName : " + FirstName + " " + Surname +
                "\nType : " + Type + "\nEmail Address : " + Email + "\nPhone Number : " + Phone;
        }

        public static int GetNextID()
        {
            string sqlQuery = "SELECT IdNum_SEQ.NEXTVAL FROM DUAL";

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sqlQuery);

            dr.Read();

            int nextIDnum;
            if (dr.IsDBNull(0))
            {
                nextIDnum = 1;
            }
            else
            {
                nextIDnum = dr.GetInt32(0);
            }
            
            
            dr.Close();
            return nextIDnum;
        }

        public void AddPerson(Person p)
        {
            string sql = "INSERT INTO People VALUES ("+
                p.PersonID + ",'" +
                p.FirstName + "','" +
                p.Surname + "','" +
                p.Email + "','" +
                p.Phone +"')";

            Database.ExecuteNonQuery(sql);
        }

        public static String IsValidPerson(Person p)
        {
            if (!Validation.Name(p.FirstName))
            {
                return "First Name not in the correct format.";
            }
            else if (!Validation.Name(p.Surname))
            {
                return "Surname not in the correct format.";
            }
            else if (!Validation.Email(p.Email))
            {
                return "Email not in the correct format.";
            }
            else if (!Validation.IrishPhoneNumber(p.Phone))
            {
                return "Phone Number not in the correct format, must be XXX-XXXXXXX.";
            }
            if(p is Tutor)
            {
                Tutor t = (Tutor)p;

                if (string.IsNullOrWhiteSpace(t.RateCode))
                {
                    return "Rate Code must be selected";
                }
                else if (string.IsNullOrWhiteSpace(t.Subject))
                {
                    return "Subject must be selected";
                }
            }
            return "Valid";
        }

    }
}
