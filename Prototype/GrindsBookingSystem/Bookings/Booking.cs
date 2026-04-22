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

            Database.ExecuteNonQueryCommand(cmd);
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

            Database.ExecuteNonQueryCommand(cmd);
        }
        public void Delete() 
        {
            int id = GetBookingID();

            string sql = "DELETE FROM " +
                         "Bookings " +
                         "WHERE BookingID = :ID";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":ID", id);

            Database.ExecuteNonQueryCommand(cmd);
        }

        

        public static int GetAmount(string id)
        {
            string sql = "SELECT tr.HourlyRate " +
                         "FROM Tutors t " +
                         "JOIN TutorRates tr ON t.RateCode = tr.RateCode " +
                         "WHERE t.TutorID = " + id;

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);

            if (dr.Read())
            {
                return dr.GetInt32(0);
            }
            else
            {
                return 0;
            }

        }

        public static DataSet GetStudentBookings(string id)
        {
            string sql = "SELECT b.BookingID, s.Description,c.Day,c.Time,tr.HourlyRate AS Amount " +
                         "FROM Bookings b " +
                         "JOIN Classes c ON b.ClassID = c.ClassID " +
                         "JOIN Subjects s ON c.SubjectID = s.SubjectID " +
                         "JOIN Tutors t ON c.TutorID = t.TutorID " +
                         "JOIN TutorRates tr ON t.RateCode = tr.RateCode " +
                         "WHERE b.StudentID = " + id;

            return Database.ExecuteMultiRowQuery(sql);
        }

        public void SendBookingConfirmation()
        {
            string senderEmail = "isabellemarielynch@gmail.com";
            string appPassword = "***REMOVED***";

            string sql = "SELECT Email FROM Students WHERE StudentID = " + this.StudentID;

            OracleDataReader odr = Database.ExecuteSingleRowQuery(sql);

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
            string sql = "SELECT * FROM Bookings WHERE ClassID = " + this.ClassID +
                        " AND StudentID = " + this.StudentID;

            DataSet ds = Database.ExecuteMultiRowQuery(sql);

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
                         "WHERE c.SemesterNo = " + Class.GetCurrentSemester() + edit +
                         "ORDER BY s.Description, c.Day";

            DataSet ds = Database.ExecuteMultiRowQuery(sql);

            return ds.Tables[0];
        }

        public static int GetClassID(string bookingID)
        {
            string sql = "SELECT ClassID " +
                         "FROM Bookings " +
                         "WHERE BookingID = " + bookingID;

            int id = 0;

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);

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
                         "VALUES(" + id + "," + student + "," + amount + ")";

            Database.ExecuteNonQuery(sql);
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
            string sql = "SELECT t.TutorID FROM Bookings b JOIN Classes c ON " +
                                "b.ClassID = c.ClassID JOIN Tutors t " +
                                "ON c.TutorID = t.TutorID " +
                                "WHERE b.ClassID = " + classID;

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);
            if (dr.Read())
            {
                return dr.GetInt32(0);
            }
            else
            {
                return 0;
            }
        }

        public int GetBookingID()
        {
            string sql = "SELECT BookingID " +
                         "FROM Bookings " +
                         "WHERE StudentID = " + this.StudentID +
                         " AND ClassID = " + this.ClassID;
            
            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);
            
            dr.Read();

            int id = dr.GetInt32(0);

            dr.Close();

            return id;
        }

        public static Booking GetBooking(string bookingID)
        {
            string sql = "SELECT ClassID, StudentID " +
                         "FROM Bookings " +
                         "WHERE BookingID = " + bookingID;

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);

            dr.Read();

            Booking b = new Booking();
            b.ClassID = dr.GetInt32(0);
            b.StudentID = dr.GetInt32(1);

            dr.Close();

            return b;
        }
    }
}
