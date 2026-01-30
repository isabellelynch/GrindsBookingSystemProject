using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static GrindsBookingSystem.frmHome;

namespace GrindsBookingSystem
{
    public partial class frmRemoveStudent : Form
    {
        public frmRemoveStudent()
        {
            InitializeComponent();

            List<ComboBox> comboBoxes = loadComboBoxes.CreateComboList(cboStudentID, cboName, cboSName);

            loadComboBoxes.IDFirstnameSurname(comboBoxes, "Student");

            lvRemoveStudent.Columns.Clear();

            lvRemoveStudent.Columns.Add("ID", 50);
            lvRemoveStudent.Columns.Add("First Name", 120);
            lvRemoveStudent.Columns.Add("Surname", 120);

            lvRemoveStudent.View = View.Details;
            lvRemoveStudent.FullRowSelect = true;

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

        private void btnBack_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }
   
    }

}
