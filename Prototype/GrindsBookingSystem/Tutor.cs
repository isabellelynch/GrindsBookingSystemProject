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
    public class Tutor : Person, InterfaceCRUD
    {
        public string RateCode { get; set; }
        public string Subject { get; set; }


        public Tutor(int id, string name, string sname, string rate, string sub, string emailAddress, string phoneNo, string status) 
            : base(id, name, sname, emailAddress, phoneNo, status)
        {
            RateCode = rate;
            Subject = sub;
        }

        public override string ToString()
        {
            return base.ToString() + "\nRate Code : " + RateCode +
                "\nSubject Code : " + Subject;
        }

        public void Add()
        {
            Debug.WriteLine(this);

            string sql = "INSERT INTO Tutors VALUES (" +
                "'T' || LPAD(" + PersonID + ", 3, '0')" +
                FirstName + "','" +
                Surname + "','" +
                RateCode + "','" +
                Subject + "')" +
                Email + "','" +
                Phone + "')";

            Database.ExecuteNonQuery(sql);
        }

        public void Remove() 
        {
            string sql = "UPDATE Tutors SET Status = 'I'" +
                " WHERE PersonID = " + PersonID;
            try
            {
                Database.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Update()
        {
            string sql = "UPDATE Tutors SET Email = '" + Email + "', PhoneNo = '" + Phone + "RateCode = '" + RateCode
                + "', SubjectCode = '" + Subject + "' WHERE PersonID = " + PersonID;
            try
            {
                Database.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public string View(int id)
        {
            try
            {
                string sql = "SELECT t.TutorID, p.FirstName, p.Surname, t.RateCode, t.SubjectCode, p.PhoneNo, p.Email FROM Tutors t JOIN People p " +
                    "ON t.TutorID = p.PersonID WHERE t.TutorID = " + id;

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
        public static int GetNextID()
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
        public DataSet RetrieveAll()
        {
            string sql = "SELECT TutorID, FirstName, Surname FROM Tutors ORDER BY TutorID";
            return Database.ExecuteMultiRowQuery(sql);
        }

        public static DataSet GetSpecificTutors(ComboBox cb)
        {
            string idList = "";
            foreach (var v in cb.Items) 
            {
                if (cb.Items.IndexOf(v) == cb.Items.Count-1)
                {
                    idList += v.ToString();
                    break;
                }
                idList += v.ToString() + ",";
            }

            string sql = "SELECT t.TutorID, p.FirstName, p.Surname " +
                "FROM People p JOIN Tutors t ON p.PersonID = t.TutorID " +
                "WHERE p.PersonID IN (" + idList + ") " +
                "ORDER BY TutorID";
            return Database.ExecuteMultiRowQuery(sql);
        }

        public static Tutor GetTutor(int id)
        {
            string sql = "SELECT t.TutorID, p.FirstName, p.Surname, t.RateCode, t.SubjectCode, p.Email, p.PhoneNo " +
                "FROM People p JOIN Tutors t ON p.PersonID = t.TutorID WHERE t.TutorID = " + id;

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);

            dr.Read();

            Tutor t = new Tutor(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4), dr.GetString(5), dr.GetString(6), "A");

            return t;
        }


        public String IsValid()
        {
            if (!Validation.Name(FirstName))
            {
                return "First Name not in the correct format.";
            }
            else if (!Validation.Name(Surname))
            {
                return "Surname not in the correct format.";
            }
            else if (!Validation.Email(Email))
            {
                return "Email not in the correct format.";
            }
            else if (!Validation.IrishPhoneNumber(Phone))
            {
                return "Phone Number not in the correct format, must be XXX-XXXXXXX.";
            }
            else if (string.IsNullOrWhiteSpace(RateCode))
            {
                return "Rate Code must be selected";
            }
            else if (string.IsNullOrWhiteSpace(Subject))
            {
                return "Subject must be selected";
            }
            
            return "Valid";
        }


    } 
}

