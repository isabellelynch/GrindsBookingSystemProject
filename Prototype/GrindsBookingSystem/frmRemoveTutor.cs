using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GrindsBookingSystem.frmAddTutor;
using static GrindsBookingSystem.frmHome;

namespace GrindsBookingSystem
{
        public partial class frmRemoveTutor : Form
        {
            public frmRemoveTutor()
            {
                InitializeComponent();
            }

            private void frmRemoveTutor_Load(object sender, EventArgs e)
            {
                if (lvRemoveTutors.Columns.Count == 0)
                {
                    lvRemoveTutors.Columns.Add("ID", 50);
                    lvRemoveTutors.Columns.Add("First Name", 120);
                    lvRemoveTutors.Columns.Add("Surname", 120);
                }

                lvRemoveTutors.View = View.Details;
                lvRemoveTutors.FullRowSelect = true;

            }

       

        private void UpdateListView(IEnumerable<Tutor> tutors)
            {
                lvRemoveTutors.Items.Clear();

                foreach (var t in tutors)
                {
                    var item = new ListViewItem(t.TutorID.ToString());
                    item.SubItems.Add(t.FirstName);
                    item.SubItems.Add(t.Surname);
                    lvRemoveTutors.Items.Add(item);

                }
            }

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

