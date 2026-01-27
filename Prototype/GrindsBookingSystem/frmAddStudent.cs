using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static GrindsBookingSystem.frmHome;

namespace GrindsBookingSystem
{
    public partial class frmAddStudent : Form
    {
        String validMessage = "";
        public frmAddStudent()
        {
            InitializeComponent();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you wish to add student " + txtStudentName.Text + " " +
                                                    txtStudentSurname.Text + "to the system ?",
                                                    "Please Confirm",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Student s = new Student(Student.GetNextStudentID(), txtStudentName.Text, txtStudentSurname.Text, txtStudentEmail.Text, txtStudentPhone.Text);
                MessageBox.Show(s.toString());
                s.AddStudent();

                MessageBox.Show("Student " + txtStudentName.Text + txtStudentSurname.Text + "has been succesfully added to the system.",
                                "Success",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    
                DialogResult addAnother = MessageBox.Show("Would you like to add another Student?",
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
                MessageBox.Show("Adding Student Function Cancelled",
                                "Cancelled",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                clearUI();
                return;
            }
        }



        public void clearUI()
        {
            txtStudentName.Clear();
            txtStudentSurname.Clear();
            txtStudentEmail.Clear();
            txtStudentPhone.Clear();
            validMessage = "";
        }
        public void goHome()
        {
            clearUI();
            frmHome home = new frmHome();
            home.Show();
            this.Close();

        }


        private void exitBtnAddStudent_Click(object sender, EventArgs e)
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

        private void backBtnAddStudent_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearUI();
        }

    }
}