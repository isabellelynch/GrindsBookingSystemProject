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


        public Tutor() : this(0, "", "", "", "", "", "") { }

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

        public static Tutor GetTutor(int id)
        {
            String sql = "SELECT * FROM Tutors WHERE TutorID = " + id;

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);

            dr.Read();

            Tutor t = new Tutor(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4), dr.GetString(5), dr.GetString(6));

            return t;

        }

        public static void UpdateTutor(int id, String rate, String sub, String email, String phone)
        {
            String sql = "UPDATE Tutors SET RateCode = '" + rate + "', SubjectCode = '" + sub +
                "', Email = '" + email + "', PhoneNo = '" + phone + "' WHERE TutorID = " + id;
            try
            {
                Database.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public static String GetTutorDetails(int id)
        {
            try 
            { 
                String sql = "SELECT * FROM Tutors WHERE TutorID = " + id;

                OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);
                dr.Read();

            
                return "Tutor ID: " + dr.GetInt32(0).ToString() + "\nFirst Name: " + dr.GetString(1) + "\nSurname: " + 
                        dr.GetString(2) + "\nRate Code: " + dr.GetString(3) + "\nSubject: " +
                        dr.GetString(4) + "\nPhone Number: " + dr.GetString(5) + "\nEmail Address: " + dr.GetString(6);
            }
            catch 
            {
                return "";
            }
        }

        public static String IsValidTutor(Tutor t)
        {
            if (!Validation.Name(t.FirstName))
            {
                return "First Name not in the correct format.";
            }
            else if(!Validation.Name(t.Surname))
            {
                return "Surname not in the correct format.";
            }
            else if (!Validation.Email(t.Email))
            {
                return "Email not in the correct format.";
            }
            else if (!Validation.IrishPhoneNumber(t.Phone))
            {
                return "Phone Number not in the correct format, must be XXX-XXXXXXX.";
            }
            else if (string.IsNullOrWhiteSpace(t.RateCode))
            {
                return "Rate Code must be selected";
            }
            else if (string.IsNullOrWhiteSpace(t.Subject))
            {
                return "Subject must be selected";
            }
            else
            {
                return "Valid";
            }
        }
    } 
}

