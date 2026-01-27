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
using static GrindsBookingSystem.frmAddStudent;
using static GrindsBookingSystem.frmHome;

namespace GrindsBookingSystem
{
    public partial class frmAddTutor : Form
    {
        public frmAddTutor()
        {
            InitializeComponent();
        }
        private void btnAddTutor_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Before we add " + txtTutorName.Text + " " +
                                                    txtTutorSurname.Text + " to the system, have they supplied proof of their Garda Vetting" +
                                                    "information?",
                                                    "Please Confirm",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                

                String rate = cboTutorRates.Text.Substring(0,3);
                String subject = cboTutorSubjects.Text.Substring(0,3);

                Tutor t = new Tutor(Tutor.GetNextTutorID(), txtTutorName.Text, txtTutorSurname.Text, rate, subject, txtTutorPhone.Text, txtTutorEmail.Text);
                t.AddTutor();
                MessageBox.Show("Tutor " + txtTutorName.Text + " " + txtTutorSurname.Text + " has been succesfully added to the system.",
                                "Success",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);

                DialogResult addAnother = MessageBox.Show("Would you like to add another Tutor?",
                                                        "Please Confirm",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question);
                if (addAnother == DialogResult.Yes)
                {
                    clearUI();
                }
                else
                {
                    goHome();
                }

                return;
            }
            else
            {
                MessageBox.Show("Adding Tutor Function Cancelled, Tutor must be Garda Vetted before being added to the system",
                                "Cancelled",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                clearUI();
                return;
            }
        }
        
        public void goHome()
        {
            clearUI();
            Owner.Show();
            this.Hide();
        }
        public void loadRateCodes()
        {
            cboTutorRates.Items.Clear();

            String sql = "SELECT RateCode, Description FROM TutorRates ORDER BY RateCode";

            DataSet ds = Database.ExecuteMultiRowQuery(sql);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cboTutorRates.Items.Add(ds.Tables[0].Rows[i][0] + " - " + ds.Tables[0].Rows[i][1]);
            }
        }

        public void loadSubjects()
        {
            cboTutorSubjects.Items.Clear();

            String sql = "SELECT SubjectCode, Description FROM Subjects ORDER BY SubjectCode";
            DataSet ds = Database.ExecuteMultiRowQuery(sql);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cboTutorSubjects.Items.Add(ds.Tables[0].Rows[i][0] + " - " + ds.Tables[0].Rows[i][1]);
            }
        }


        public void clearUI()
        {
            txtTutorName.Clear();
            txtTutorSurname.Clear();
            txtTutorEmail.Clear();
            txtTutorPhone.Clear();
            cboTutorRates.Items.Clear();
            cboTutorSubjects.Items.Clear();
        }

        private void frmAddTutor_Load(object sender, EventArgs e)
        {
            loadRateCodes();
            loadSubjects();
        }
   

        private void btnBack_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
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
            clearUI();
        }
    }
}