using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace GrindsBookingSystem
{
    public class Tutor : Person, InterfaceCRUD
    {
        public string RateCode { get; set; }
        public Tutor(string name, string sname, string emailAddress, string phoneNo, string rate) 
            : base(name, sname, emailAddress, phoneNo)
        {
            RateCode = rate;
        }

        public Tutor():base()
        {
            RateCode = "";
        }

        public override string ToString()
        {
            return base.ToString() + 
                   "\nRate Code : " + RateCode;
        }

        public void Create()
        {
            string sql = "INSERT INTO Students (FirstName, Surname, Email, PhoneNo, RateCode, Status) " +
                "VALUES (:FirstName, :Surname, :Email, :Phone, :RateCode, :Status)";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":FirstName", FirstName);
            cmd.Parameters.Add(":Surname", Surname);
            cmd.Parameters.Add(":Email", Email);
            cmd.Parameters.Add(":Phone", Phone);
            cmd.Parameters.Add(":RateCode", RateCode);
            cmd.Parameters.Add(":Status", 'A');

            Database.ExecuteNonQueryCommand(cmd);
        }


        public string Read()
        {
            Tutor t = GetTutor(Convert.ToInt32(this.PersonID));

            return t.ToString();
        }


        public void Update()
        {
            string sql = "UPDATE Tutors SET " +
                         "Email = :Email, " +
                         "PhoneNo = :PhoneNo, " +
                         "RateCode = :RateCode " +
                         "WHERE TutorID = :ID";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":Email", Email);
            cmd.Parameters.Add(":Phone", Phone);
            cmd.Parameters.Add(":RateCode", RateCode);
            cmd.Parameters.Add(":ID", this.PersonID);

            Database.ExecuteNonQueryCommand(cmd);
        }

        public void Delete() 
        {
            string sql = "UPDATE Tutors SET " +
                         "Status = :S " +
                         "WHERE TutorID = :ID";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":S", 'I');
            cmd.Parameters.Add(":ID", this.PersonID);

            Database.ExecuteNonQueryCommand(cmd);
        }
        public static DataSet RetrieveAll()
        {
            string sql = "SELECT * " +
                         "FROM Tutors " +
                         "WHERE Status = 'A' " +
                         "ORDER BY TutorID";
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

            Tutor t = new Tutor(dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4), dr.GetString(5));

            t.SetID(id.ToString());

            dr.Close();

            return t;
        }

        public static string WorstPerformingTutor()
        {
            string sql = "SELECT t.FirstName, t.Surname, NVL(SUM(tr.HourlyRate), 0) AS TotalEarnings " +
                        "FROM Tutors t " +
                        "JOIN TutorRates tr ON t.RateCode = tr.RateCode " +
                        "LEFT JOIN Classes c ON t.TutorID = c.TutorID " +
                        "LEFT JOIN Bookings b ON c.ClassID = b.ClassID " +
                        "AND EXTRACT(YEAR FROM b.BookingDate) = EXTRACT(YEAR FROM SYSDATE) " +
                        "GROUP BY t.TutorID, t.FirstName, t.Surname " +
                        "ORDER BY TotalEarnings ASC " +
                        "FETCH FIRST 1 ROW WITH TIES";

            string result = "";

            DataSet ds = Database.ExecuteMultiRowQuery(sql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                result = ds.Tables[0].Rows[0]["FirstName"].ToString() + " " +
                         ds.Tables[0].Rows[0]["Surname"].ToString() + " €" +
                         ds.Tables[0].Rows[0]["TotalEarnings"].ToString();
            }

            return result;
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
            
            return "Valid";
        }

        public static DataTable GetTutorsSubjects(string id)
        {
            string sql = "SELECT s.Description, s.SubjectLevel, s.SubjectCategory " +
                         "FROM Subjects s " +
                         "JOIN Tutor_Subjects ts ON s.SubjectID = ts.SubjectID" +
                         " WHERE ts.TutorID = '" + id + "'";

            DataSet ds = Database.ExecuteMultiRowQuery(sql);

            return ds.Tables[0];
        } 

        public static int GetTutorID(string name, string surname)
        {
            string sql = "SELECT TutorID FROM Tutors WHERE FirstName = '" + name +
                "' AND Surname = '" + surname + "'";

            int id = 0;

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);

            if (dr.Read())
            {
                 id = dr.GetInt32(0);
            }

            dr.Close();

            return id;
        }


    } 
}

