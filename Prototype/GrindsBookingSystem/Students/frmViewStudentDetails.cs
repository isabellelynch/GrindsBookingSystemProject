using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace GrindsBookingSystem
{
    public partial class frmViewStudentDetails : BaseForm
    {
        List<ComboBox> comboBoxes;

        private bool updating = false;
        public frmViewStudentDetails()
        {
            InitializeComponent();

            ControlFunctions.FillBoxes("Students", cboStudentID, cboFirstName, cboSurname);

            comboBoxes = ControlFunctions.CreateComboList(cboStudentID, cboFirstName, cboSurname);

            foreach(ComboBox cb in comboBoxes)
            {
                cb.SelectedIndexChanged -= ComboBoxChange;
                cb.SelectedIndexChanged += ComboBoxChange;
            }
        }

      

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            Student s = Student.GetStudent(Convert.ToInt32(cboStudentID.Items[0]));

            String details = s.Read();

            if (details != null)
            {
                MessageBox.Show("The selected Students details are \n\n" + details,
                    "Student Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("The selected Student could not be found.",
                    "Student Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            updating = false;

        }

        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);

            comboBoxes = ControlFunctions.CreateComboList(cboStudentID, cboFirstName, cboSurname);

            ControlFunctions.FillBoxes("Students", cboStudentID, cboFirstName, cboSurname);

            foreach (ComboBox cb in comboBoxes)
            {
                cb.SelectedIndexChanged -= ComboBoxChange;
                cb.SelectedIndexChanged += ComboBoxChange;
            }

        }
    }
}
