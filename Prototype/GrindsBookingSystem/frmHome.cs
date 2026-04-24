using System;
using System.Windows.Forms;

//General References used throughout the project for learning purposes
//
//Books
//
//Gaddis, T. (2017) Starting Out with Visual C#. 5th edn. Boston: Pearson.
//
//Sells, C. (2006) Windows Forms Programming in C#. 2nd edn. Boston: Addison-Wesley.
//
//Microsoft Documentation
//
//Microsoft (n.d.) ADO.NET Overview. Available at: https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/
//
//Microsoft (n.d.) Windows Forms Overview. Available at: https://learn.microsoft.com/en-us/dotnet/desktop/winforms/


namespace GrindsBookingSystem
{
    public partial class frmHome : Form
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
            NewPage(new frmManageBookings());
        }
        private void YearlyRevenue_Click(object sender, EventArgs e)
        {
            NewPage(new frmAdmin());
        }

        private void scheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewPage(new frmViewSchedule());
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = CustomDialogMessageBox.Show("Are you sure you want to exit ?",
                                                              "Please Confirm");
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void NewPage(Form f)
        {
            f.Owner = this;
            f.Show();
            this.Hide();
        }

        private void AssignSubjects_Click(object sender, EventArgs e)
        {
            NewPage(new frmAssignSubjects());
        }

        private void AddSubject_Click(object sender, EventArgs e)
        {
            NewPage(new frmAddSubject());
        }
    }
}
