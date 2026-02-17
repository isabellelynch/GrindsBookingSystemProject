using System;
using System.Windows.Forms;


namespace GrindsBookingSystem
{
    public partial class frmHome : BaseForm
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void AddTutor_Click(object sender, EventArgs e)
        {
            NewPage(new frmAddTutor());
        }

        private void RemoveTutor_Click(object sender, EventArgs e)
        {
            NewPage(new frmRemoveTutor());
        }

        private void UpdateTutor_Click(object sender, EventArgs e)
        {
            NewPage(new frmUpdateTutor());
        }

        private void ViewTutor_Click(object sender, EventArgs e)
        {
            NewPage(new frmViewTutorDetails()) ;
        }

        private void AddStudent_Click(object sender, EventArgs e)
        {
            NewPage(new frmAddStudent());
        }

        private void RemoveStudent_Click(object sender, EventArgs e)
        {
            NewPage(new frmRemoveStudent());
        }

        private void UpdateStudent_Click(object sender, EventArgs e)
        {
            NewPage(new frmUpdateStudent());
        }

        private void ViewStudent_Click(object sender, EventArgs e)
        {
            NewPage(new frmViewStudentDetails());
        }

        private void MakeBooking_Click(object sender, EventArgs e)
        {
            NewPage(new frmAddBooking());
        }

        private void CancelBooking_Click(object sender, EventArgs e)
        {
            NewPage(new frmCancelBooking());
        }

        private void ViewBookings_Click(object sender, EventArgs e)
        {
            NewPage(new frmShowBookings());
        }

        private void YearlyRevenue_Click(object sender, EventArgs e)
        {
            NewPage(new frmAdmin());
        }

        private void EarningsAnalysis_Click(object sender, EventArgs e)
        {
            NewPage(new frmTutorReport());
        }
        
        private void scheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewPage(new frmViewSchedule());
        }
        private void NewPage(Form f)
        {
            f.Owner = this;
            f.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exit();
        }

        
    }
}
