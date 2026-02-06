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
        public frmAddStudent()
        {
            InitializeComponent();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            Student s = new Student(Person.GetNextID(), txtStudentName.Text, txtStudentSurname.Text, txtStudentEmail.Text, txtStudentPhone.Text);

            if (Person.IsValidPerson(s) != "Valid")
            {
                MessageBox.Show(Person.IsValidPerson(s) + "\nPlease make the necessary changes to the information and try again",
                    "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you wish to add student " + txtStudentName.Text + " " +
                                                    txtStudentSurname.Text + "to the system ?",
                                                    "Please Confirm",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                s.AddStudent(s);

                MessageBox.Show("Student " + txtStudentName.Text + txtStudentSurname.Text + "has been succesfully added to the system.",
                                "Success",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    
                DialogResult addAnother = MessageBox.Show("Would you like to add another Student?",
                                                        "Please Confirm",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question);
                if (addAnother == DialogResult.No)
                {
                    goHome();
                }
            }
            else
            {
                MessageBox.Show("Adding Student Function Cancelled",
                                "Cancelled",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Warning);
            }
            clearUI();
            return;
        }



        public void clearUI()
        {
            txtStudentName.Clear();
            txtStudentSurname.Clear();
            txtStudentEmail.Clear();
            txtStudentPhone.Clear();

        }
        public void goHome()
        {
            Owner.Show();
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
            goHome();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearUI();
        }

    }
}