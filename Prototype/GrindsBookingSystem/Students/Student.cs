using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace GrindsBookingSystem
{
    public class Student: Person, InterfaceCRUD
    {
        public Student(string name, string sname, string email, string phone) : 
            base(name, sname, email, phone)
        { 
            
        }

        public Student() : base() { }

        public override string ToString()
        {
            return base.ToString();
        }
        public void Create()
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
        
        public string Read()
        {
            Student s = GetStudent(Convert.ToInt32(this.PersonID));

            return s.ToString();
        }
        
        public void Update()
        {
            string sql = "UPDATE Students SET " +
                         "Email = '" + Email + "', " +
                         "PhoneNo = '" + Phone + 
                         "' WHERE StudentID = " + this.PersonID;
            try
            {
                Database.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void Delete() 
        {
            string sql = "UPDATE Students SET Status = 'I'" +
                " WHERE StudentID = '" + this.PersonID + "'";
            try
            {
                Database.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static DataSet RetrieveAll()
        {
            string sql = "SELECT StudentID, FirstName, Surname FROM Students WHERE Status = 'A' ORDER BY StudentID";
            return Database.ExecuteMultiRowQuery(sql);
        }


        public static Student GetStudent(int id)
        {
            string sql = "SELECT * FROM Students WHERE StudentID = '" + id + "'";

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);

            dr.Read();

            Student s = new Student(dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4));

            s.SetID(id.ToString());

            dr.Close();

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

        public static DataSet GetStudentList(ComboBox cb)
        {
            string idList = "";

            foreach (var v in cb.Items)
            {
                if (cb.Items.IndexOf(v) == cb.Items.Count - 1)
                {
                    idList += v.ToString();
                    break;
                }
                idList += v.ToString() + ",";
            }

            string sql = "SELECT StudentID, FirstName, Surname " +
                "FROM Students " +
                "WHERE StudentID IN (" + idList + ") " +
                "ORDER BY StudentID";

            return Database.ExecuteMultiRowQuery(sql);
        }

        
    }
}
