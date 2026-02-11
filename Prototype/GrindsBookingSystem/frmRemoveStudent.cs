using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static GrindsBookingSystem.frmHome;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;

namespace GrindsBookingSystem
{
    public partial class frmRemoveStudent : Form
    {
        List<ComboBox> comboBoxes;
        private bool updating = false;
        public frmRemoveStudent()
        {
            InitializeComponent();

            dgvRemoveStudent.DataSource = Tutor.RetrieveAll().Tables[0];

            ControlFunctions.formatGridView(dgvRemoveStudent);

            ControlFunctions.FillBoxes("Students", cboStudentID, cboName, cboSName);

            comboBoxes = ControlFunctions.CreateComboList(cboStudentID, cboName, cboSName);

            foreach (ComboBox cb in comboBoxes)
            {
                cb.SelectedIndexChanged += ComboBoxChange;
            }

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

        public void ComboBoxChange(object sender, EventArgs e)
        {
            if (updating) return;

            ComboBox cbo = sender as ComboBox;

            if (cbo == null || cbo.SelectedItem == null)
            {
                return;
            }

            updating = true;

            if (cbo == cboStudentID)
            {
                ControlFunctions.ApplyFilters("'" + cboStudentID.Text + "'", "StudentID", "Students", cboStudentID, cboName, cboSName);
            }
            else if (cbo == cboName)
            {
                ControlFunctions.ApplyFilters("'" + cboName.Text + "'", "FirstName", "Students", cboStudentID, cboName, cboSName);
            }
            else if (cbo == cboSName)
            {
                ControlFunctions.ApplyFilters("'" + cboSName.Text + "'", "Surname", "Students", cboStudentID, cboName, cboSName);
            }

            dgvRemoveStudent.DataSource = Tutor.GetTutorList(cboStudentID).Tables[0];

            updating = false;

        }

        private void btnRemoveStudent_Click(object sender, EventArgs e)
        {
            if (dgvRemoveStudent.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dgvRemoveStudent.SelectedRows[0];

                Student s = Student.GetStudent(Convert.ToInt32(row.Cells[0].Value));

                s.SetID(row.Cells[0].Value.ToString());

                s.Remove();

                MessageBox.Show("Student Removed");
            }
            else
            {
                MessageBox.Show("No row selected.");
            }
        }
    }

}
