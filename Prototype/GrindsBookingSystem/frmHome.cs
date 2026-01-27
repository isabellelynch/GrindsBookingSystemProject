using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GrindsBookingSystem.frmAddStudent;
using static GrindsBookingSystem.frmAddTutor;
using Oracle.ManagedDataAccess.Client;

namespace GrindsBookingSystem
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();

        }
     

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmAddTutor();
            form.Owner = this;
            form.Show();
            this.Hide();
        }

        private void removeTutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmRemoveTutor();
            form.Owner = this;
            form.Show();
            this.Hide();
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmAddStudent();
            form.Owner = this;
            form.Show();
            this.Hide();
        }

        private void removeStuentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmRemoveStudent();
            form.Owner = this;
            form.Show();
            this.Hide();
        }

        private void updateTutorDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmUpdateTutor();
            form.Owner = this;
            form.Show();
            this.Hide();
        }

        private void updateStudentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmUpdateStudent();
            form.Owner = this;
            form.Show();
            this.Hide();
        }

        private void viewStudentDetaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmViewStudentDetails();
            form.Owner = this;
            form.Show();
            this.Hide();
        }

        private void viewTutorDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmViewTutorDetails();
            form.Owner = this;
            form.Show();
            this.Hide();
        }

        private void scheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmSchedule();
            form.Owner = this;
            form.Show(); 
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit ?",
                                                   "Please Confirm",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void makeBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmAddBooking();
            form.Owner = this;
            form.Show();
            this.Hide();
        }
  
        private void cancelBokingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmCancelBooking();
            form.Show();
            form.Owner = this;
            this.Hide();
        }

        private void viewBookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmShowBookings();
            form.Show();
            form.Owner = this;
            this.Hide();
        }
        public static void ClearCombos(Control.ControlCollection Controls)
        {
            foreach (Control control in Controls)
            {
                if (control is ComboBox comboBox)
                {
                    comboBox.Items.Clear();
                    comboBox.Text = "";
                }
            }
        }
        public static String ValidateInput(String Firstname, String Lastname, String Email, String Phone, String StudentTutor, int tutorRateIndex, int tutorSubjectIndex)
        {
            if (Firstname.Equals(""))
            {
                return StudentTutor + " First Name field must not be empty.";
            }
            else if (!Regex.IsMatch(Firstname, @"^[a-zA-Z\s]+$"))
            {
                return StudentTutor + " First Name field must only contain letters.";
            }


            else if (Lastname.Equals(""))
            {
                return StudentTutor + " Surname field must not be empty.";
            }
            else if (!Regex.IsMatch(Lastname, @"^[a-zA-Z\s]+$"))
            {
                return StudentTutor + " Surname field must only contain letters.";
            }

            else if (Email.Equals(""))
            {
                return StudentTutor + " Email field must not be empty.";
            }
            else if (!Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                return StudentTutor + " Email field must be in the correct format, example : isabelle@gmail.com";
            }
            else if (Phone.Equals(""))
            {
                return StudentTutor + " Phone Number field must not be empty.";
            }
            else if (!Regex.IsMatch(Phone, @"\d{3}-\d{7}$"))
            {
                return StudentTutor + " Phone Number field must be in the format XXX-XXXXXXX.";
            }
            else if (StudentTutor.Equals("Tutor") && tutorRateIndex == -1)
            {
                return "Tutor Rate Code must be selected.";
            }
            else if (StudentTutor.Equals("Tutor") && tutorSubjectIndex == -1)
            {
                return "Tutor Subject must be selected.";
            }
            

            else
            {
                return "valid";
            }
        }

        public static void UpdateComboS<T>(ComboBox combo, IEnumerable<T> values)
        {
            string current = combo.Text;
            combo.Items.Clear();
            foreach (var v in values)
                combo.Items.Add(v);
            if (string.IsNullOrWhiteSpace(current))
            {
                combo.SelectedIndex = -1;
                return;
            }
            try
            {
                T converted = (T)Convert.ChangeType(current, typeof(T));
                if (values.Contains(converted))
                    combo.Text = current;
                else
                    combo.SelectedIndex = -1;
            }
            catch
            {
                combo.SelectedIndex = -1;
            }
        }

        public static void UpdateComboBoxesS(
            IEnumerable<Student> filtered,
            ComboBox cboStudentID,
            ComboBox cboNames,
            ComboBox cboSurnames,
            EventHandler idChanged,
            EventHandler nameChanged,
            EventHandler surnameChanged)
        {
            cboStudentID.SelectedIndexChanged -= idChanged;
            cboNames.SelectedIndexChanged -= nameChanged;
            cboSurnames.SelectedIndexChanged -= surnameChanged;

            UpdateComboS(cboStudentID, filtered.Select(s => s.StudentID).Distinct());
            UpdateComboS(cboNames, filtered.Select(s => s.FirstName).Distinct());
            UpdateComboS(cboSurnames, filtered.Select(s => s.Surname).Distinct());

            cboStudentID.SelectedIndexChanged += idChanged;
            cboNames.SelectedIndexChanged += nameChanged;
            cboSurnames.SelectedIndexChanged += surnameChanged;
        }

        public static void UpdateComboBoxesT(
            IEnumerable<Tutor> filtered,
            ComboBox cboTutorID,
            ComboBox cboNames,
            ComboBox cboSurnames,
            EventHandler idChanged,
            EventHandler nameChanged,
            EventHandler surnameChanged)
        {
            cboTutorID.SelectedIndexChanged -= idChanged;
            cboNames.SelectedIndexChanged -= nameChanged;
            cboSurnames.SelectedIndexChanged -= surnameChanged;

            UpdateComboS(cboTutorID, filtered.Select(T => T.TutorID).Distinct());
            UpdateComboS(cboNames, filtered.Select(T => T.FirstName).Distinct());
            UpdateComboS(cboSurnames, filtered.Select(T => T.Surname).Distinct());

            cboTutorID.SelectedIndexChanged += idChanged;
            cboNames.SelectedIndexChanged += nameChanged;
            cboSurnames.SelectedIndexChanged += surnameChanged;
        }

        public class DateTimeListViewComparer : IComparer
        {
            private readonly int dateColumnIndex;
            private readonly int timeColumnIndex;
            private readonly bool ascending;

            public DateTimeListViewComparer(int dateColumnIndex, int timeColumnIndex, bool ascending = true)
            {
                this.dateColumnIndex = dateColumnIndex;
                this.timeColumnIndex = timeColumnIndex;
                this.ascending = ascending;
            }

            public int Compare(object x, object y)
            {
                var item1 = x as ListViewItem;
                var item2 = y as ListViewItem;

                // Read values
                DateTime date1 = DateTime.Parse(item1.SubItems[dateColumnIndex].Text);
                DateTime date2 = DateTime.Parse(item2.SubItems[dateColumnIndex].Text);

                TimeSpan time1 = TimeSpan.Parse(item1.SubItems[timeColumnIndex].Text);
                TimeSpan time2 = TimeSpan.Parse(item2.SubItems[timeColumnIndex].Text);

                // Combine date + time
                DateTime dt1 = date1.Add(time1);
                DateTime dt2 = date2.Add(time2);

                return ascending ? dt1.CompareTo(dt2) : dt2.CompareTo(dt1);
            }
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void tutorEarningsAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmTutorReport();
            form.Show();
            form.Owner = this;
            this.Hide();
        }

        private void yearlyRevenueAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmAdmin();
            form.Show();
            form.Owner = this;
            this.Hide();
        }
    }
}
