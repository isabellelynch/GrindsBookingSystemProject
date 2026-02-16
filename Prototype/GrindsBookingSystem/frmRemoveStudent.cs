using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GrindsBookingSystem
{
    public partial class frmRemoveStudent : BaseForm
    {
        List<ComboBox> comboBoxes;
        private bool updating = false;
        public frmRemoveStudent()
        {
            InitializeComponent();

            Reset(this.Controls);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GoHome();
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

            dgvRemoveStudent.DataSource = Student.GetStudentList(cboStudentID).Tables[0];

            updating = false;

        }

        private void btnRemoveStudent_Click(object sender, EventArgs e)
        {
            if (dgvRemoveStudent.SelectedRows.Count == 1)
            {
                try
                {
                    DataGridViewRow row = dgvRemoveStudent.SelectedRows[0];

                    Student s = Student.GetStudent(Convert.ToInt32(row.Cells[0].Value));

                    s.SetID(row.Cells[0].Value.ToString());

                    s.Delete();

                    MessageBox.Show("The following Student has now been removed from the system \n\n" + s.ToString(),
                                    "Student Removed",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    Reset(this.Controls);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            else
            {
                MessageBox.Show("No row selected. Please select a Student to be removed.");
            }
        }
        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);

            comboBoxes = ControlFunctions.CreateComboList(cboStudentID, cboName, cboSName);

            foreach (ComboBox cb in comboBoxes)
            {
                cb.SelectedIndexChanged -= ComboBoxChange;
                cb.SelectedIndexChanged += ComboBoxChange;
            }

            dgvRemoveStudent.DataSource = Student.RetrieveAll().Tables[0];
            ControlFunctions.formatGridView(dgvRemoveStudent);
            ControlFunctions.FillBoxes("Students", cboStudentID, cboName, cboSName);

        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Reset(this.Controls);
        }
    }

}
