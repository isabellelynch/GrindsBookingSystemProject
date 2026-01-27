using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GrindsBookingSystem.frmHome;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GrindsBookingSystem
{
    public partial class frmShowBookings : Form
    {
        public frmShowBookings()
        {
            InitializeComponent();
        }


        public void reset()
        {
            frmHome.ClearCombos(this.Controls);
            cboStudentID.Enabled = true;
            cboName.Enabled = true;
            cboSName.Enabled = true;


            lvBookings.Items.Clear();
            grpCancelBooking.Visible = false;

        }



        private void frmShowBookings_Load(object sender, EventArgs e)
        {

            grpCancelBooking.Visible= false;
        }

        private void btnShowBookings_Click(object sender, EventArgs e)
        {

            grpCancelBooking.Visible = true;
            cboStudentID.Enabled = false;
            cboName.Enabled = false;
            cboSName.Enabled = false;

        }

        public void updateListView(IEnumerable<Booking> bookings)
        {

            lvBookings.Items.Clear();
            if (lvBookings.Columns.Count == 0)
            {

                lvBookings.Columns.Add("Booking Date", 100);
                lvBookings.Columns.Add("Grind Time", 115);
                lvBookings.Columns.Add("Booking Reference", 100);
                lvBookings.Columns.Add("Tutor ID", 115);
                lvBookings.Columns.Add("Amount", 130);
            }
            foreach (var b in bookings)
            {
                var item = new ListViewItem(b.DateOfBooking.ToShortDateString());
                item.SubItems.Add(b.GrindTime.ToShortTimeString());
                item.SubItems.Add(b.bookingRef.ToString());
                item.SubItems.Add(b.TutorID.ToString());
                item.SubItems.Add(b.Amount.ToString());


                item.Tag = b;

                lvBookings.Items.Add(item);
            }
            
            lvBookings.View = View.Details;
            lvBookings.FullRowSelect = true;
            lvBookings.GridLines = true;
            lvBookings.ListViewItemSorter = new DateTimeListViewComparer(0, 1, true);
            lvBookings.Sort();
        }

        private void btnRefresh_Click(object sender, EventArgs e) => reset();
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Owner.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
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
    }
}
