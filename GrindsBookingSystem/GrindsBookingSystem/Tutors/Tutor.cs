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
            string sql = "INSERT INTO Tutors (FirstName, Surname, Email, PhoneNo, RateCode, Status) " +
                "VALUES (:FirstName, :Surname, :Email, :Phone, :RateCode, :Status)";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":FirstName", FirstName);
            cmd.Parameters.Add(":Surname", Surname);
            cmd.Parameters.Add(":Email", Email);
            cmd.Parameters.Add(":Phone", Phone);
            cmd.Parameters.Add(":RateCode", RateCode);
            cmd.Parameters.Add(":Status", 'A');

            Database.ExecuteNonQuery(cmd);
        }


        public string Read()
        {
            return this.ToString();
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
            cmd.Parameters.Add(":PhoneNo", Phone);
            cmd.Parameters.Add(":RateCode", RateCode);
            cmd.Parameters.Add(":ID", this.PersonID);

            Database.ExecuteNonQuery(cmd);
        }

        public void Delete() 
        {
            string sql = "UPDATE Tutors SET " +
                         "Status = :S " +
                         "WHERE TutorID = :ID";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":S", 'I');
            cmd.Parameters.Add(":ID", this.PersonID);

            Database.ExecuteNonQuery(cmd);
        }

        public void CancelTutorsClasses()
        {
            string sql = "UPDATE Classes SET " +
                         "Status = :S " +
                         "WHERE TutorID = :ID";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":S", 'C');
            cmd.Parameters.Add(":ID", this.PersonID);

            Database.ExecuteNonQuery(cmd);
        }
        public void DeleteBookings()
        {
            string sql = "UPDATE Bookings " +
                         "SET Status = :S " +
                         "WHERE ClassID IN (SELECT ClassID FROM Classes WHERE TutorID = :tutorID)";

            var cmd = new OracleCommand(sql);
            cmd.Parameters.Add(":S", 'C');
            cmd.Parameters.Add(":tutorID", this.PersonID);

            Database.ExecuteNonQuery(cmd);
        }
        public static DataSet RetrieveAll()
        {
            string sql = "SELECT * " +
                         "FROM Tutors " +
                         "WHERE Status = :status " +
                         "ORDER BY TutorID";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":status", 'A');

            return Database.ExecuteMultiRowQuery(cmd);
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

            // "IN ()" is invalid SQL, so when the filters leave no tutors use an ID that can't exist
            if (idList == "")
            {
                idList = "-1";
            }

            string sql = $@"SELECT * 
                         FROM Tutors 
                         WHERE TutorID IN ({idList}) 
                         ORDER BY TutorID";

            var cmd = new OracleCommand(sql);

            return Database.ExecuteMultiRowQuery(cmd);
        }

        public static void FillTutorDataTable(DataGridView dgv, ComboBox cb)
        {
            DataTable dt = GetTutorList(cb).Tables[0];

            dt.Columns.RemoveAt(dt.Columns.Count - 1);

            dgv.DataSource = dt;
        }

        public static Tutor GetTutor(int id)
        {
            Tutor t = new Tutor();

            string sql = "SELECT * " +
                         "FROM Tutors " +
                         "WHERE TutorID = :id";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":id", id);

            OracleDataReader dr = Database.ExecuteSingleRowQuery(cmd);

            if (dr.Read())
            {
                t = new Tutor(dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4), dr.GetString(5));
                t.SetID(id.ToString());
            }
           
            dr.Close();
            return t;
        }

        public static string BestPerformingTutor()
        {
            string result = "";
            // earnings = number of this year's bookings x the tutor's hourly rate (the same sum as the chart on the admin page).
            // SUM(HourlyRate) used to count a class with no bookings as one booking, and included removed tutors.
            string sql = "SELECT t.FirstName, t.Surname, COUNT(b.BookingID) * tr.HourlyRate AS TotalEarnings " +
                        "FROM Tutors t " +
                        "JOIN TutorRates tr ON t.RateCode = tr.RateCode " +
                        "LEFT JOIN Classes c ON t.TutorID = c.TutorID " +
                        "LEFT JOIN Bookings b ON c.ClassID = b.ClassID " +
                        "AND b.Status = 'A' " +
                        "AND EXTRACT(YEAR FROM b.BookingDate) = EXTRACT(YEAR FROM SYSDATE) " +
                        "WHERE t.Status = 'A' " +
                        "GROUP BY t.TutorID, t.FirstName, t.Surname, tr.HourlyRate " +
                        "ORDER BY TotalEarnings DESC " +
                        "FETCH FIRST 1 ROW WITH TIES";

            var cmd = new OracleCommand(sql);
            
            DataSet ds = Database.ExecuteMultiRowQuery(cmd);

            if (ds.Tables[0].Rows.Count > 0)
            {
                result = ds.Tables[0].Rows[0]["FirstName"].ToString() + " " +
                         ds.Tables[0].Rows[0]["Surname"].ToString() + " €" +
                         ds.Tables[0].Rows[0]["TotalEarnings"].ToString();
            }

            return result;
        }

        public static string WorstPerformingTutor()
        {
            string result = "";
            string sql = "SELECT t.FirstName, t.Surname, COUNT(b.BookingID) * tr.HourlyRate AS TotalEarnings " +
                        "FROM Tutors t " +
                        "JOIN TutorRates tr ON t.RateCode = tr.RateCode " +
                        "LEFT JOIN Classes c ON t.TutorID = c.TutorID " +
                        "LEFT JOIN Bookings b ON c.ClassID = b.ClassID " +
                        "AND b.Status = 'A' " +
                        "AND EXTRACT(YEAR FROM b.BookingDate) = EXTRACT(YEAR FROM SYSDATE) " +
                        "WHERE t.Status = 'A' " +
                        "GROUP BY t.TutorID, t.FirstName, t.Surname, tr.HourlyRate " +
                        "ORDER BY TotalEarnings ASC " +
                        "FETCH FIRST 1 ROW WITH TIES";

            var cmd = new OracleCommand(sql);

            DataSet ds = Database.ExecuteMultiRowQuery(cmd);

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
                         " WHERE ts.TutorID = :id";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add("id", id);

            DataSet ds = Database.ExecuteMultiRowQuery(cmd);

            return ds.Tables[0];
        } 

        // frmAddClass passes the tutor's ID here, but this used to check the room (RoomNo = tutor ID),
        // so a tutor could be given two classes at the same time. Cancelled classes are ignored.
        public static bool IsTutorFree(int day, int time, string tutorID)
        {
            int classID = 0;

            string sql = "SELECT ClassID FROM Classes " +
                         "WHERE Day = :day " +
                         "AND Time = :time " + 
                         "AND TutorID = :tutor " + 
                         "AND SemesterNo = :semester " +
                         "AND Status = :status";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":day", day);
            cmd.Parameters.Add(":time", time);
            cmd.Parameters.Add(":tutor", tutorID);
            cmd.Parameters.Add(":semester", Class.GetCurrentSemester());
            cmd.Parameters.Add(":status", 'A');

            OracleDataReader dr = Database.ExecuteSingleRowQuery(cmd);

            if (dr.Read())
            {
                classID = dr.GetInt32(0);
            }
            dr.Close();
            if (classID == 0)
            {
                return true;
            }
            return false;

        }

        public static int HoursWorked(string tutorID)
        {
            int hours = 0;
            string sql = "SELECT COUNT(*) AS Hours " +
                         "FROM Classes " +
                         "WHERE TutorID = :id " +
                         "AND SemesterNo = :semester " +
                         "AND Status = :status";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":id", tutorID);
            cmd.Parameters.Add(":semester", Class.GetCurrentSemester());
            cmd.Parameters.Add(":status", 'A');

            OracleDataReader dr = Database.ExecuteSingleRowQuery(cmd);
            if (dr.Read())
            {
                hours = dr.GetInt32(0);
            }
            dr.Close();
            return hours;
        }

        public static bool DoesTutorExist(string email)
        {
            string sql = "SELECT 1 " +
                         "FROM Tutors " +
                         "WHERE Email = :email";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":email", email);

            // the reader has to be closed, otherwise its database connection is never given back
            using (OracleDataReader dr = Database.ExecuteSingleRowQuery(cmd))
            {
                return dr.Read();
            }
        }

    } 
}

