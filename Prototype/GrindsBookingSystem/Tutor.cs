using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace GrindsBookingSystem
{
    public class Tutor : Person, InterfaceCRUD
    {
        public string RateCode { get; set; }
        public string Subject { get; set; }


        public Tutor(string name, string sname, string emailAddress, string phoneNo, string rate, string sub) 
            : base(name, sname, emailAddress, phoneNo)
        {
            RateCode = rate;
            Subject = sub;
        }

        public override string ToString()
        {
            return base.ToString() + "\nRate Code : " + RateCode +
                "\nSubject Code : " + Subject;
        }

        public void Create()
        {
            Debug.WriteLine(this);

            string sql = "INSERT INTO Tutors (FirstName, Surname" +
                ",Email, PhoneNo, RateCode, SubjectID, Status) VALUES ('" +
                FirstName + "','" +
                Surname + "','" +
                Email + "','" +
                Phone + "','" +
                RateCode + "','" +
                Subject + "'," +
                "'A')";

            Database.ExecuteNonQuery(sql);
        }


        public string Read()
        {
            Tutor t = GetTutor(Convert.ToInt32(this.PersonID));

            return t.ToString();
        }


        public void Update()
        {
            string sql = "UPDATE Tutors SET Email = '" + Email + "', PhoneNo = '" + Phone + "', RateCode = '" + RateCode
                + "', SubjectCode = '" + Subject + "' WHERE TutorID = '" + this.PersonID + "'";
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
            string sql = "UPDATE Tutors SET Status = 'I'" +
                " WHERE TutorID = '" + this.PersonID + "'";
            
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
            string sql = "SELECT * FROM Tutors WHERE Status = 'A' ORDER BY TutorID";
            return Database.ExecuteMultiRowQuery(sql);
        }

        public static DataSet GetTutorList(ComboBox cb)
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

            string sql = "SELECT TutorID, FirstName, Surname " +
                "FROM Tutors " +
                "WHERE TutorID IN (" + idList + ") " +
                "ORDER BY TutorID";

            return Database.ExecuteMultiRowQuery(sql);
        }

        public static Tutor GetTutor(int id)
        {
            string sql = "SELECT * FROM Tutors WHERE TutorID = '" + id + "'";

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);

            dr.Read();

            Tutor t = new Tutor(dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4), dr.GetString(5), dr.GetString(6));

            t.SetID(id.ToString());

            dr.Close();

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

