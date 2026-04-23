using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;



namespace GrindsBookingSystem
{
    public class Booking : InterfaceCRUD
    {
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
        }
        public string Read() 
        { 
            return this.ToString(); 
        }
        public void Update() 
        { 
            string sql = "UPDATE Bookings SET " +
                         "StudentID = :StudentID AND " +
                         "ClassID = :ClassID";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":StudentID", this.StudentID);
            cmd.Parameters.Add(":ClassID", this.ClassID);

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
                         "WHERE b.StudentID = :id";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":id", id);

            return Database.ExecuteMultiRowQuery(cmd);
        }

        public void SendBookingConfirmation()
        {
            string senderEmail = "isabellemarielynch@gmail.com";
            string appPassword = "***REMOVED***";

            string sql = "SELECT Email " +
                         "FROM Students " +
                         "WHERE StudentID = :id";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":id", this.StudentID);

            OracleDataReader odr = Database.ExecuteSingleRowQuery(cmd);

            if (odr.Read())
            {
                string recipientEmail = odr.GetString(0);
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
                         " AND StudentID = :student";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":class", this.ClassID);
            cmd.Parameters.Add(":student", this.StudentID);

            DataSet ds = Database.ExecuteMultiRowQuery(cmd);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            return true;
        }

        public static DataTable GetBookingDetails(string text)
        {
            string edit = "";

            if (text.Length > 0)
            {
                edit = " AND s.Description = '" + text + "' ";
            }

            string sql = "SELECT s.Description, s.SubjectLevel, s.SubjectCategory, " +
                         "CASE c.Day " +
                                "WHEN 1 THEN 'Monday'" +
                                "WHEN 2 THEN 'Tuesday'" +
                                "WHEN 3 THEN 'Wednesday'" +
                                "WHEN 4 THEN 'Thursday'" +
                                "WHEN 5 THEN 'Friday'" +
                                "END AS DayName, " +
                         "c.Time, c.RoomNo, c.CurrentEnrollment, r.Capacity " +
                         "FROM Classes c JOIN Subjects s " +
                         "ON c.SubjectID = s.SubjectID " +
                         "JOIN Rooms r ON c.RoomNo = r.RoomNo " +
                         "WHERE c.SemesterNo = :semester :edit" +
                         "ORDER BY s.Description, c.Day";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":semester", Class.GetCurrentSemester());
            cmd.Parameters.Add(":edit", edit);

            DataSet ds = Database.ExecuteMultiRowQuery(cmd);

            return ds.Tables[0];
        }

        public static int GetClassID(string bookingID)
        {
            int id = 0;
            string sql = "SELECT ClassID " +
                         "FROM Bookings " +
                         "WHERE BookingID = :booking";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":booking", bookingID);

            OracleDataReader dr = Database.ExecuteSingleRowQuery(cmd);

            if (dr.Read())
            {
                id = dr.GetInt32(0);
            }

            dr.Close();

            return id;
        }

        public static void ProcessRefund(string id, string student, string amount)
        {
            string sql = "INSERT INTO Refunds (BookingID, StudentID, Amount) " +
                         "VALUES (:id, :student, :amount)";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":id", id);
            cmd.Parameters.Add(":student", student);
            cmd.Parameters.Add(":amount", amount);

            Database.ExecuteNonQuery(cmd);
        }


        public static void CancelBooking(string bookingID, string studentID)
        {
            int classID = GetClassID(bookingID);

            string tutorID = GetTutorIDFromClassID(classID.ToString()).ToString();

            string amount = GetAmount(tutorID).ToString();

            ProcessRefund(bookingID, studentID, amount);

            Booking b = GetBooking(bookingID);
            
            b.Delete();
        }

        public static int GetTutorIDFromClassID(string classID)
        {
            int id = 0;
            string sql = "SELECT t.TutorID FROM Bookings b JOIN Classes c ON " +
                                "b.ClassID = c.ClassID JOIN Tutors t " +
                                "ON c.TutorID = t.TutorID " +
                                "WHERE b.ClassID = :class";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":class", classID);

            OracleDataReader dr = Database.ExecuteSingleRowQuery(cmd);

            if (dr.Read())
            {
                id = dr.GetInt32(0);
            }
            return id;
        }

        public int GetBookingID()
        {
            int id = 0;
            string sql = "SELECT BookingID " +
                         "FROM Bookings " +
                         "WHERE StudentID = :student" +
                         " AND ClassID = :class";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":student", this.StudentID);
            cmd.Parameters.Add(":class", this.ClassID);
            
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

            string sql = "SELECT ClassID, StudentID " +
                         "FROM Bookings " +
                         "WHERE BookingID = :booking";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":booking", bookingID);

            OracleDataReader dr = Database.ExecuteSingleRowQuery(cmd);

            if (dr.Read())
            {
                b.ClassID = dr.GetInt32(0);
                b.StudentID = dr.GetInt32(1);
            }
            dr.Close();

            return b;
        }
    }
}
