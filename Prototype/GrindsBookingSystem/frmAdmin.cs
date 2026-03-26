using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;



namespace GrindsBookingSystem
{
    public partial class frmAdmin : BaseForm
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        
        private void frmAdmin_Load(object sender, EventArgs e)
        {
            txtRevenue.Text = GenerateTotalAnnualRevenue().ToString();
            txtTotalBookings.Text = GenerateTotalAnnualBookings().ToString();
            txtActiveStudents.Text = GetActive("Students").ToString();
            txtActiveTutors.Text = GetActive("Tutors").ToString();
            txtWorstTutor.Text = WorstPerformingTutor();
            txtLeastBooked.Text = LeastBookedClass();
        }

        private double GenerateTotalAnnualRevenue()
        {
            string sql = "SELECT SUM(tr.HourlyRate) " +
                         "FROM Bookings b " +
                         "JOIN Classes c ON b.ClassID = c.ClassID " +
                         "JOIN Tutors t ON c.TutorID = t.TutorID " +
                         "JOIN TutorRates tr ON t.RateCode = tr.RateCode " +
                         "WHERE EXTRACT(YEAR FROM b.BookingDate) = EXTRACT(YEAR FROM SYSDATE)";
            
            double total = 0;
            
            OracleDataReader dr =  Database.ExecuteSingleRowQuery(sql);
            if (dr.Read()) 
            {
                total = dr.GetDouble(0);
            }

            dr.Close();
            return total;
        }

        private int GenerateTotalAnnualBookings()
        {
            string sql = "SELECT COUNT(*) " +
                         "FROM Bookings " +
                         "WHERE EXTRACT(YEAR FROM b.BookingDate) = EXTRACT(YEAR FROM SYSDATE)";

            int total = 0;

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);

            if (dr.Read())
            {
                total = dr.GetInt32(0);
            }

            dr.Close();

            return total;
        }

        private int GetActive(string table)
        {
            string sql = "SELECT COUNT(*) " +
                         "FROM " + table +
                         "WHERE Status = 'A'";

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);

            int count = 0;

            if (dr.Read())
            {
                count = dr.GetInt32(0);
            }

            dr.Close();

            return count;
        }

        private string WorstPerformingTutor()
        {
            string sql ="SELECT t.FirstName, t.Surname NVL(SUM(tr.HourlyRate), 0) AS TotalEarnings " +
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
                if (ds.Tables[0].Rows.Count == 1) 
                { 
                    result = ds.Tables[0].Rows[0].ToString();
                }
            }
            return result;
        }

        private string LeastBookedClass()
        {
            string sql = "SELECT s.Description " +
                         "FROM Classes c " +
                         "LEFT JOIN Bookings b ON c.ClassID = b.ClassID " +
                         "JOIN Subjects s ON c.SubjectID = s.SubjectID " +
                         "GROUP BY c.ClassID " +
                         "ORDER BY BookingCount ASC " +
                         "FETCH FIRST 1 ROW WITH TIES";

            string result = "";

            DataSet ds = Database.ExecuteMultiRowQuery(sql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows.Count == 1)
                {
                    result = ds.Tables[0].Rows[0].ToString();
                }
            }
            return result;
        }









    }
}
