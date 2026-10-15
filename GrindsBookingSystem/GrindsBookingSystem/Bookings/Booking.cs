using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Data;



namespace GrindsBookingSystem
{
    public class Booking : InterfaceCRUD
    {
        public int BookingID { get; set; }
        public int StudentID { get; set; }
        public int ClassID { get; set; }

        public Booking() : this(0, 0) { }

        public Booking(int studentID, int classID)
        {
            StudentID = studentID;
            ClassID = classID;
        }

        public override string ToString()
        {
            return "Booking Details \n" +
                   "\nClassID : " + this.ClassID +
                   "\nStudentID : " + this.StudentID;
        }

        public void Create()
        {
            string sql = "INSERT INTO Bookings (StudentID, ClassID) " +
                         "VALUES (:StudentID, :ClassID)";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":StudentID", this.StudentID);
            cmd.Parameters.Add(":ClassID", this.ClassID);

            Database.ExecuteNonQuery(cmd);

            // nothing else updated CurrentEnrollment, so classes always showed 0 students and could never fill up
            ChangeEnrollment(this.ClassID, 1);
        }

        // adds (or with -1 removes) a student from a class's enrollment count
        private static void ChangeEnrollment(int classID, int change)
        {
            string sql = "UPDATE Classes " +
                         "SET CurrentEnrollment = GREATEST(CurrentEnrollment + :change, 0) " +
                         "WHERE ClassID = :ClassID";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":change", change);
            cmd.Parameters.Add(":ClassID", classID);

            Database.ExecuteNonQuery(cmd);
        }

        public string Read() 
        { 
            return this.ToString(); 
        }
        public void Update() 
        { 
            // columns in a SET are separated by commas (not AND), and the WHERE stops every booking being changed
            string sql = "UPDATE Bookings SET " +
                         "StudentID = :StudentID, " +
                         "ClassID = :ClassID " +
                         "WHERE BookingID = :ID";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":StudentID", this.StudentID);
            cmd.Parameters.Add(":ClassID", this.ClassID);
            cmd.Parameters.Add(":ID", this.BookingID);

            Database.ExecuteNonQuery(cmd);
        }
        public void Delete() 
        {
            int id = GetBookingID();

            string sql = "DELETE FROM " +
                         "Bookings " +
                         "WHERE BookingID = :ID";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":ID", id);

            Database.ExecuteNonQuery(cmd);

            ChangeEnrollment(this.ClassID, -1);
        }

        

        public static int GetAmount(string id)
        {
            int amount = 0;

            string sql = "SELECT tr.HourlyRate " +
                         "FROM Tutors t " +
                         "JOIN TutorRates tr ON t.RateCode = tr.RateCode " +
                         "WHERE t.TutorID = :id";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":id", id);

            OracleDataReader dr = Database.ExecuteSingleRowQuery(cmd);

            if (dr.Read())
            {
                amount = dr.GetInt32(0);
            }

            dr.Close();

            return amount;

        }

        public static DataSet GetStudentBookings(string id)
        {
            string sql = "SELECT b.BookingID, s.Description,c.Day,c.Time,tr.HourlyRate AS Amount " +
                         "FROM Bookings b " +
                         "JOIN Classes c ON b.ClassID = c.ClassID " +
                         "JOIN Subjects s ON c.SubjectID = s.SubjectID " +
                         "JOIN Tutors t ON c.TutorID = t.TutorID " +
                         "JOIN TutorRates tr ON t.RateCode = tr.RateCode " +
                         "WHERE b.StudentID = :id " +
                         "AND b.Status = :status " +
                         "AND c.Status = :status2";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":id", id);
            cmd.Parameters.Add(":status", 'A');
            cmd.Parameters.Add(":status2", 'A');

            return Database.ExecuteMultiRowQuery(cmd);
        }

        public void SendBookingConfirmation()
        {
            // The sender address and Gmail App Password are read from secrets.config (ignored by Git)
            // so they are never committed. If they have not been set up, no email is sent.
            string senderEmail = ConfigurationManager.AppSettings["GmailAddress"];

            string appPassword = ConfigurationManager.AppSettings["GmailAppPassword"];

            if (string.IsNullOrWhiteSpace(senderEmail) || string.IsNullOrWhiteSpace(appPassword))
            {
                return;
            }

            string sql = "SELECT Email " +
                         "FROM Students " +
                         "WHERE StudentID = :id";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":id", this.StudentID);

            string recipientEmail = "";

            // using closes the reader (and its connection) once the email address has been read
            using (OracleDataReader odr = Database.ExecuteSingleRowQuery(cmd))
            {
                if (odr.Read())
                {
                    recipientEmail = odr.GetString(0);
                }
            }

            if (recipientEmail != "")
            {
                string emailSubject = "Successful Class Booking";

                Class c = Class.GetClass(this.ClassID);

                Student s = Student.GetStudent(this.StudentID);

                string emailBody = GmailSender.GenerateBookingConfirmationEmail(c, s.FirstName + " " + s.Surname);

                GmailSender.SendEmail(senderEmail, appPassword, recipientEmail, emailSubject, emailBody);
            }
        }

        public bool HasStudentAlreadyBooked()
        {
            string sql = "SELECT * " +
                         "FROM Bookings " +
                         "WHERE ClassID = :class" +
                         " AND StudentID = :student" +
                         " AND Status = :status";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":class", this.ClassID);
            cmd.Parameters.Add(":student", this.StudentID);
            cmd.Parameters.Add(":status", 'A');

            DataSet ds = Database.ExecuteMultiRowQuery(cmd);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            return true;
        }

        public static DataTable GetBookingDetails(string text)
        {
            string sql = "";
            var cmd = new OracleCommand();

            if (text == "")
            {
                sql = "SELECT s.Description, s.SubjectLevel, s.SubjectCategory, " +
                         "CASE c.Day " +
                                "WHEN 1 THEN 'Monday' " +
                                "WHEN 2 THEN 'Tuesday' " +
                                "WHEN 3 THEN 'Wednesday' " +
                                "WHEN 4 THEN 'Thursday' " +
                                "WHEN 5 THEN 'Friday' " +
                                "END AS DayName, " +
                         "c.Time, c.RoomNo, c.CurrentEnrollment, r.Capacity " +
                         "FROM Classes c JOIN Subjects s " +
                         "ON c.SubjectID = s.SubjectID " +
                         "JOIN Rooms r ON c.RoomNo = r.RoomNo " +
                         "WHERE c.SemesterNo = :semester " +
                         "AND c.Status = 'A' " +
                         "ORDER BY s.Description, c.Day";

                cmd.CommandText = sql;

                cmd.Parameters.Add(":semester", Class.GetCurrentSemester());
            }
            else
            {
                sql = "SELECT s.Description, s.SubjectLevel, s.SubjectCategory, " +
                         "CASE c.Day " +
                                "WHEN 1 THEN 'Monday' " +
                                "WHEN 2 THEN 'Tuesday' " +
                                "WHEN 3 THEN 'Wednesday' " +
                                "WHEN 4 THEN 'Thursday' " +
                                "WHEN 5 THEN 'Friday' " +
                                "END AS DayName, " +
                         "c.Time, c.RoomNo, c.CurrentEnrollment, r.Capacity " +
                         "FROM Classes c JOIN Subjects s " +
                         "ON c.SubjectID = s.SubjectID " +
                         "JOIN Rooms r ON c.RoomNo = r.RoomNo " +
                         "WHERE c.SemesterNo = :semester " +
                         "AND c.Status = 'A' " +
                         "AND s.Description = :text " +
                         "ORDER BY s.Description, c.Day";

                cmd.CommandText = sql;

                cmd.Parameters.Add(":semester", Class.GetCurrentSemester());
                cmd.Parameters.Add(":text", text);
            }

            DataSet ds = Database.ExecuteMultiRowQuery(cmd);

            return ds.Tables[0];
        }

        public int GetBookingID()
        {
            int id = 0;
            string sql = "SELECT BookingID " +
                         "FROM Bookings " +
                         "WHERE StudentID = :student" +
                         " AND ClassID = :class" +
                         " AND Status = :status";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":student", this.StudentID);
            cmd.Parameters.Add(":class", this.ClassID);
            cmd.Parameters.Add(":status", 'A');
            
            OracleDataReader dr = Database.ExecuteSingleRowQuery(cmd);

            if (dr.Read())
            {
                id = dr.GetInt32(0);
            }

            dr.Close();

            return id;
        }

        public static Booking GetBooking(string bookingID)
        {
            Booking b = new Booking();

            string sql = "SELECT ClassID, StudentID, BookingID " +
                         "FROM Bookings " +
                         "WHERE BookingID = :booking";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":booking", bookingID);

            OracleDataReader dr = Database.ExecuteSingleRowQuery(cmd);

            if (dr.Read())
            {
                b.ClassID = dr.GetInt32(0);
                b.StudentID = dr.GetInt32(1);
                b.BookingID = dr.GetInt32(2);
            }
            dr.Close();

            return b;
        }
    }
}
