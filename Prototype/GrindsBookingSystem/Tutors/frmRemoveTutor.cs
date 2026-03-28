using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GrindsBookingSystem
{

    public partial class frmRemoveTutor : BaseForm
    {
        List<ComboBox> comboBoxes;
        private bool updating = false;
        public frmRemoveTutor()
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

            ControlFunctions.Filters("Tutor", cbo, cboTutorID, cboFirstName, cboSurname);

            dgvRemoveTutors.DataSource = Tutor.GetTutorList(cboTutorID).Tables[0];

            updating = false;

        }

        private void btnRemoveTutor_Click(object sender, EventArgs e)
        {
            if (dgvRemoveTutors.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dgvRemoveTutors.SelectedRows[0];

                int id = Convert.ToInt32(row.Cells[0].Value);

                Tutor t = Tutor.GetTutor(id);

                t.Delete();

                SuccessMessage("The chosen tutor has been successfully removed");

                Reset(this.Controls);
            }
            else
            {
                ErrorMessage("A tutor must be selected in order to be removed");
            }
        }

        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);

            ControlFunctions.FillBoxes("Tutors", cboTutorID, cboFirstName, cboSurname);
            
            GridViews.Default(dgvRemoveTutors);
            
            dgvRemoveTutors.DataSource = Tutor.GetTutorList(cboTutorID).Tables[0];

            comboBoxes = ControlFunctions.CreateComboList(cboTutorID, cboFirstName, cboSurname);

            foreach (ComboBox cb in comboBoxes)
            {
                cb.SelectedIndexChanged -= ComboBoxChange;
                cb.SelectedIndexChanged += ComboBoxChange;
            }
        }

        private void btnResetFilters_Click(object sender, EventArgs e)
        {
            Reset(this.Controls);
        }

    }


}

