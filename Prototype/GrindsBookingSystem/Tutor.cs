using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public String toString()
        {
            return "Tutor ID : " + TutorID + ", " + FirstName + ", " + Surname;
        }

        public static int GetNextTutorID()
        {
            string sqlQuery = "SELECT TutorID_SEQ.NEXTVAL FROM DUAL";

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

        public void AddTutor()
        {
            Debug.WriteLine(this);

            string sql = "INSERT INTO Tutors VALUES (" +
                TutorID + ",'" +
                FirstName + "','" +
                Surname + "','" +
                RateCode + "','" +
                Subject + "','" +
                Email + "','" +
                Phone + "')";

            Database.ExecuteNonQuery(sql);
        }

        public static DataSet GetAllTutors()
        {
            String sql = "SELECT TutorID, FirstName, Surname FROM Tutors ORDER BY TutorID";
            return Database.ExecuteMultiRowQuery(sql);
        }

      
       
    }
}

