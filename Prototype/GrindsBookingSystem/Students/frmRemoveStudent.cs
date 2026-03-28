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
        public void ComboBoxChange(object sender, EventArgs e)
        {
            if (updating) return;

            ComboBox cbo = sender as ComboBox;

            if (cbo == null || cbo.SelectedItem == null)
            {
                return;
            }

            updating = true;

            ControlFunctions.Filters("Student", cbo, cboStudentID, cboFirstName, cboSurname);

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

                    int id = Convert.ToInt32(row.Cells[0].Value);

                    Student s = Student.GetStudent(id);

                    s.SetID(id.ToString());

                    s.Delete();

                    SuccessMessage("The following Student has now been removed from the system \n\n" + s.ToString());

                    Reset(this.Controls);
                }
                catch(Exception ex)
                {
                    ErrorMessage(ex.Message);
                }
                
            }
            else
            {
                ErrorMessage("No row selected. Please select a Student to be removed.");
            }
        }
        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);

            ControlFunctions.FillBoxes("Students", cboStudentID, cboFirstName, cboSurname);

            GridViews.Default(dgvRemoveStudent);

            dgvRemoveStudent.DataSource = Student.RetrieveAll().Tables[0];

            comboBoxes = ControlFunctions.CreateComboList(cboStudentID, cboFirstName, cboSurname);

            foreach (ComboBox cb in comboBoxes)
            {
                cb.SelectedIndexChanged -= ComboBoxChange;
                cb.SelectedIndexChanged += ComboBoxChange;
            }
        }
    }

}
