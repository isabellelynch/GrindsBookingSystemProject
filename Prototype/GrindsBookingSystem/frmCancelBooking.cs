using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace GrindsBookingSystem
{
    public partial class frmCancelBooking : BaseForm
    {
        List<ComboBox> comboBoxes;
        private bool updating = false;
        public frmCancelBooking()
        {
            InitializeComponent();
            Reset(this.Controls);
        }



        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);

            ControlFunctions.EnableBoxes(cboStudentID, cboName, cboSName);

            grpCancelBooking.Visible = false;

            ControlFunctions.FillBoxes("Students", cboStudentID, cboName, cboSName);

            comboBoxes = ControlFunctions.CreateComboList(cboStudentID, cboName, cboSName);

            foreach (ComboBox cb in comboBoxes)
            {
                cb.SelectedIndexChanged -= ComboBoxChange;
                cb.SelectedIndexChanged += ComboBoxChange;
            }
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

            ControlFunctions.Filters("Student", cbo, cboStudentID, cboName, cboSName);

            dgvCancelBooking.DataSource = Student.GetStudentList(cboStudentID).Tables[0];

            updating = false;

        }
    }
}
