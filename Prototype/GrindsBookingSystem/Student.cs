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
    public class Student: Person, InterfaceCRUD
    {
        public Student(string name, string sname, string email, string phone) : 
            base(name, sname, email, phone)
        { 
            
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void Add()
        {
            Debug.WriteLine(this);

            string sql = "INSERT INTO Students (FirstName, Surname" +
                ",Email, PhoneNo, Status) VALUES ('" +
                FirstName + "','" +
                Surname + "','" +
                Email + "','" +
                Phone + "'," +
                "'A')";


            Database.ExecuteNonQuery(sql);
        }

        public void Remove() 
        {
            string sql = "UPDATE Students SET Status = 'I'" +
                " WHERE StudentID = '" + PersonID + "'";
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
            string sql = "UPDATE Students SET Email = '" + Email + "', PhoneNo = '" + Phone + 
                "' WHERE StudentID = " + PersonID;
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
                string sql = "SELECT * FROM Students WHERE StudentID = " + PersonID;

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


        public DataSet RetrieveAll()
        {
            string sql = "SELECT StudentID, FirstName, Surname FROM Students ORDER BY StudentID";
            return Database.ExecuteMultiRowQuery(sql);
        }

        public static int GetNextID()
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

        public static Student GetStudent(int id)
        {
            string sql = "SELECT * FROM Students WHERE StudentID = '" + id + "'";

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);

            dr.Read();

            Student s = new Student(dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4));

            return s;
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
           
            return "Valid";
        }
    }
}
