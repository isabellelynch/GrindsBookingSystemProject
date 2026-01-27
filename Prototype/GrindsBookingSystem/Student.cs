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
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Student() : this(0, "", "", "", "") { }

        public Student(int id, string name, string sname, string emailAddress, string phoneNo)
        {
            StudentID = id;
            FirstName = name;
            Surname = sname;
            Email = emailAddress;
            Phone = phoneNo;
        }

        public String toString()
        {
            return "Student ID : " + StudentID + ", " + FirstName + ", " + Surname;
        }

        public static int GetNextStudentID()
        {
            string sqlQuery = "SELECT StudentID_SEQ.NEXTVAL FROM DUAL";

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

        public void AddStudent()
        {
            Debug.WriteLine(this);

            string sql = "INSERT INTO Students VALUES ("+
                StudentID + ",'" +
                FirstName + "','" +
                Surname + "','" +
                Email + "','" +
                Phone + "')";

            Database.ExecuteNonQuery(sql);
        }

    }
}
