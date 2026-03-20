using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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

        public void Create()
        {
            string sql = "INSERT INTO Bookings (StudentID, ClassID) " +
                                    "VALUES (" + this.StudentID.ToString() + " , " + this.ClassID.ToString() + ")";

            Database.ExecuteNonQuery(sql);
        }
        public string Read() { return ""; }
        public void Update() { }
        public void Delete() { }

        public void IncrementCurrentEnrollment(int current)
        {
            current++;

            string sql = "UPDATE Classes SET CurrentEnrollment = " + current +
                  " WHERE ClassID = " + this.ClassID;
            try
            {
                Database.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                BaseForm.ErrorMessage(ex.Message);
            }
        }

        public int GetAmount(string id)
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
    }
}
