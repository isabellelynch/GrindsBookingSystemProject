using System;
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

    
        private void btnBack_Click(object sender, EventArgs e)
        {
            GoHome();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Exit();
        }
        private void chartTutorEarnings_MouseDown(object sender, MouseEventArgs e)
        {
            HitTestResult result = chartTutorEarnings.HitTest(e.X, e.Y);

            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                int pointIndex = result.PointIndex;
                Series series = result.Series;
                DataPoint point = series.Points[pointIndex];
                var tutorView = point.Tag as Tutor;

                if (tutorView != null)
                {
                    MessageBox.Show("The details of the chosen tutor are:\n\n" + $"Tutor ID : {tutorView.PersonID}\n" +
                        $"First Name : {tutorView.FirstName}\n" + $"Last Name : {tutorView.Surname}\n" +
                        $"Subject : {tutorView.Subject}\n" + $"Phone : {tutorView.Phone}\n" + $"Email : {tutorView.Email}",
                        "Tutor Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }
    }
}


