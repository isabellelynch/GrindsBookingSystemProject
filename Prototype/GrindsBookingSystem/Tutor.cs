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
    public class Tutor : Person
    {
        public string RateCode { get; set; }
        public string Subject { get; set; }


        public Tutor(int id, string name, string sname, string rate, string sub, string phoneNo, string emailAddress) 
            : base(id, name, sname, phoneNo, emailAddress)
        {
            RateCode = rate;
            Subject = sub;
        }

        public override String ToString()
        {
            return base.ToString() + "\nRate Code : " + RateCode +
                "\nSubject Code : " + Subject;
        }

        public void AddTutor()
        {
            AddPerson(this);

            Debug.WriteLine(this);

            string sql = "INSERT INTO Tutors VALUES (" +
                base.PersonID + ",'" +
                RateCode + "','" +
                Subject + "','";

            Database.ExecuteNonQuery(sql);
        }

        public static DataSet GetAllTutors()
        {
            String sql = "SELECT t.TutorID, p.FirstName, p.Surname FROM People p JOIN Tutors t ON t.TutorID = p.PersonID ORDER BY TutorID";
            return Database.ExecuteMultiRowQuery(sql);
        }

        public static Tutor GetTutor(int id)
        {
            String sql = "SELECT * FROM People WHERE PersonID = " + id;

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);

            dr.Read();

            Tutor t = new Tutor(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4), dr.GetString(5), dr.GetString(6));

            return t;
        }

        public static void UpdateTutor(Tutor t)
        {
            String sql = "UPDATE People SET Email = '" + t.Email + "', PhoneNo = '" + t.Phone + "' WHERE TutorID = " + t.PersonID;
            String sql2 = "UPDATE Tutors SET RateCode = '" + t.RateCode + "', SubjectCode = '" + t.Subject;
            try
            {
                Database.ExecuteNonQuery(sql);
                Database.ExecuteNonQuery(sql2);
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
    } 
}

