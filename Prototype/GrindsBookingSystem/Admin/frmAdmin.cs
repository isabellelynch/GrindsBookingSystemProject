using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;



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
            txtWorstTutor.Text = Tutor.PerformingTutor("ASC");
            txtBestTutor.Text = Tutor.PerformingTutor("DESC");
            GetTutorEarningsChart();
            Charts.MouseDown -= Charts_MouseDownTutors;
            Charts.MouseDown += Charts_MouseDownTutors;
            ControlFunctions.ReadOnly(this.Controls);
        }
        
        private int GenerateTotalAnnualRevenue()
        {
            int total = 0;
            string sql = "SELECT SUM(tr.HourlyRate) " +
                         "FROM Bookings b " +
                         "JOIN Classes c ON c.ClassID = b.ClassID " +
                         "JOIN Tutors t ON c.TutorID = t.TutorID " +
                         "JOIN TutorRates tr ON t.RateCode = tr.RateCode " +
                         "WHERE EXTRACT(YEAR FROM b.BookingDate) = EXTRACT(YEAR FROM SYSDATE)";
            
            var cmd = new OracleCommand(sql);
            
            OracleDataReader dr =  Database.ExecuteSingleRowQuery(cmd);

            if (dr != null && dr.Read()) 
            {
                if (!dr.IsDBNull(0))
                {
                    total = Convert.ToInt32(dr.GetValue(0));
                }    
            }

            dr.Close();

            return total;
        }

        private int GenerateTotalAnnualBookings()
        {
            int total = 0;
            string sql = "SELECT COUNT(*) " +
                         "FROM Bookings b " +
                         "WHERE EXTRACT(YEAR FROM b.BookingDate) = EXTRACT(YEAR FROM SYSDATE)";


            var cmd = new OracleCommand(sql);

            OracleDataReader dr = Database.ExecuteSingleRowQuery(cmd);

            if (dr.Read())
            {
                total = dr.GetInt32(0);
            }

            dr.Close();

            return total;
        }

        private int GetActive(string table)
        {
            int count = 0;

            string sql = "SELECT COUNT(*) " +
                         "FROM :table " +
                         "WHERE Status = :status";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":table", table);
            cmd.Parameters.Add(":status", 'A');

            OracleDataReader dr = Database.ExecuteSingleRowQuery(cmd);

            if (dr.Read())
            {
                count = dr.GetInt32(0);
            }

            dr.Close();

            return count;
        }

        private void GetTutorEarningsChart()
        {
            Charts.Series.Clear();
            Charts.ChartAreas.Clear();

            string sql = "SELECT t.TutorID," +
                         "NVL(COUNT(b.BookingID) * tr.HourlyRate, 0) AS TotalEarnings " +
                         "FROM Tutors t " +
                         "JOIN TutorRates tr ON t.RateCode = tr.RateCode " +
                         "LEFT JOIN Classes c ON t.TutorID = c.TutorID " +
                         "LEFT JOIN Bookings b ON c.ClassID = b.ClassID " +
                         "AND EXTRACT(YEAR FROM b.BookingDate) = EXTRACT(YEAR FROM SYSDATE) " +
                         "GROUP BY t.TutorID, tr.HourlyRate " +
                         "ORDER BY TotalEarnings DESC";

            var cmd = new OracleCommand(sql);

            DataTable dt =  Database.ExecuteMultiRowQuery(cmd).Tables[0];

            ChartArea area = new ChartArea();

            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.Enabled = false;
            area.AxisX.Interval = 1;
            area.AxisX.Title = "Tutors";
            area.AxisY.Title = "Earnings (€) " + DateTime.Now.Year;

            Charts.ChartAreas.Add(area);

            Series series = new Series
            {
                Name = "Tutor Earnings Analysis",
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
            };

            Charts.Series.Add(series);

            foreach (DataRow row in dt.Rows)
            {
                if(Convert.ToDecimal(row["TotalEarnings"]) <= 0)
                {
                    break;
                }
                Charts.Series["Tutor Earnings Analysis"].Points.AddXY(
                    row["TutorID"].ToString(),
                    Convert.ToDecimal(row["TotalEarnings"])
                );
            }
        }
       
        private void Charts_MouseDownTutors(object sender, MouseEventArgs e)
        {
            HitTestResult result = Charts.HitTest(e.X, e.Y);

            if (result.ChartElementType != ChartElementType.DataPoint)
                return;

            if (result.PointIndex < 0 || result.Series == null)
                return;

            DataPoint point = result.Series.Points[result.PointIndex];

            try
            {
                int tutorID = Convert.ToInt32(point.AxisLabel);

                Tutor t = Tutor.GetTutor(tutorID);

                MessageBox.Show(t.ToString(),
                                "Tutor Details",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message);
            }


        }


    }
}
