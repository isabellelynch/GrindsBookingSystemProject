using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static GrindsBookingSystem.frmAddStudent;
using static GrindsBookingSystem.frmHome;

namespace GrindsBookingSystem
{
    public partial class frmAddTutor : Form
    {
        public frmAddTutor()
        {
            InitializeComponent();
            ClearUI();
        }
        private void btnAddTutor_Click(object sender, EventArgs e)
        {
            String rate = cboTutorRates.Text.Substring(0,3);
            String subject = cboTutorSubjects.Text.Substring(0,3);

            Tutor t = new Tutor(Tutor.GetNextTutorID(), txtTutorName.Text, txtTutorSurname.Text, rate, subject, txtTutorPhone.Text, txtTutorEmail.Text);
            if(Tutor.IsValidTutor(t) == "Valid")
            {
                t.AddTutor();

                DialogResult addAnother = MessageBox.Show("Tutor " + txtTutorName.Text + " " + txtTutorSurname.Text + " has been succesfully added to the system. Would you like to add another Tutor?",
                                                            "Success",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question);
                if (addAnother == DialogResult.Yes)
                {
                    ClearUI();
                }
                else
                {
                    GoHome();
                }
            }
            else
            {
                MessageBox.Show("Invalid Entry, " + Tutor.IsValidTutor(t), "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        public void GoHome()
        {
            ClearUI();
            Owner.Show();
            this.Hide();
        }
        

        public void ClearUI()
        {
            loadComboBoxes.ClearControls(this.Controls);
            loadComboBoxes.RateCodes(cboTutorRates);
            loadComboBoxes.Subjects(cboTutorSubjects);
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            GoHome();
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearUI();
        }
    }
}