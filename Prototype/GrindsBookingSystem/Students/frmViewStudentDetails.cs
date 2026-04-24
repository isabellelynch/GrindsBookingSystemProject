using GrindsBookingSystem.HelperClasses;
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
            int id = Convert.ToInt32(cboStudentID.Items[0]);

            try
            {
                Student s = Student.GetStudent(id);

                String details = s.Read();
                if (details != null)
                {
                    CustomMessageBox.ShowDetails("The selected Students details are \n\n" + details,
                                                 "Student Details");
                }
                else
                {
                    ErrorMessage("The selected Student could not be found.");
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message);
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
