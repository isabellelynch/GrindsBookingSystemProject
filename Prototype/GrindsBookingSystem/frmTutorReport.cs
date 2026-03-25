using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace GrindsBookingSystem
{
    public partial class frmTutorReport : BaseForm
    {
        public frmTutorReport()
        {
            InitializeComponent();
        }
        private void chartTutorEarnings_MouseDown(object sender, MouseEventArgs e)
        {
            HitTestResult result = chartTutorEarnings.HitTest(e.X, e.Y);
            int pointIndex = result.PointIndex;
            Series series = result.Series;
            DataPoint point = series.Points[pointIndex];

            var tutorID = point.AxisLabel;
            if (tutorID != null) 
            {
                try
                {
                    Tutor t = Tutor.GetTutor(Convert.ToInt32(tutorID));
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

        private void frmTutorReport_Load(object sender, EventArgs e)
        {
            chartTutorEarnings.Series.Clear();
            chartTutorEarnings.ChartAreas.Clear();

            ChartArea area = new ChartArea();
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.Enabled = false;
            area.AxisX.Title = "Tutors";
            area.AxisY.Title = "Earnings (€) " + DateTime.Now.Year;
            area.AxisX.Interval = 1;
            chartTutorEarnings.ChartAreas.Add(area);
            

            Series series = new Series
            {
                Name = "Earnings",
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
            };
            chartTutorEarnings.Series.Add(series);



            DataTable dt = GetTutorEarnings();

            foreach (DataRow row in dt.Rows)
            {
                chartTutorEarnings.Series["Earnings"].Points.AddXY(
                    row["TutorID"].ToString(),
                    Convert.ToDecimal(row["TotalEarnings"])
                );
            }

        }

        private DataTable GetTutorEarnings()
        {
            string sql = "SELECT t.TutorID, NVL(SUM(tr.HourlyRate), 0) AS TotalEarnings " +
            "FROM Tutors t " +
            "JOIN TutorRates tr ON t.RateCode = tr.RateCode " +
            "LEFT JOIN Classes c ON t.TutorID = c.TutorID " +
            "LEFT JOIN Bookings b ON c.ClassID = b.ClassID " +
            "AND EXTRACT(YEAR FROM b.BookingDate) = EXTRACT(YEAR FROM SYSDATE) " +
            "GROUP BY t.TutorID, t.FirstName, t.Surname " +
            "ORDER BY TotalEarnings DESC";

            return Database.ExecuteMultiRowQuery(sql).Tables[0];
        }


    }
}


