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


            Tutor.FillTutorDataTable(dgvRemoveTutors, cboTutorID);

            updating = false;

        }

        private void btnRemoveTutor_Click(object sender, EventArgs e)
        {
            if (dgvRemoveTutors.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dgvRemoveTutors.SelectedRows[0];

                int id = Convert.ToInt32(row.Cells[0].Value);

                try
                {
                    Tutor t = Tutor.GetTutor(id);

                    t.CancelTutorsClasses();
                    t.DeleteBookings();
                    t.Delete();

                    SuccessMessage("The chosen tutor has been successfully removed");

                    Reset(this.Controls);
                }
                catch (Exception ex) 
                {
                    ErrorMessage(ex.Message);
                }
            }
            else
            {
                ErrorMessage("A unique tutor must be chosen to remove him/her from the Grinds Booking System, please select a single tutor before continuing.");
            }
        }

        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);

            ControlFunctions.FillBoxes("Tutors", cboTutorID, cboFirstName, cboSurname);
            
            GridViews.Default(dgvRemoveTutors);

            Tutor.FillTutorDataTable(dgvRemoveTutors, cboTutorID);

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

