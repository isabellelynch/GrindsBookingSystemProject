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


        private void btnBack_Click(object sender, EventArgs e)
        {
            GoHome();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Exit();

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

            if (cbo == cboTutorID)
            {
                ControlFunctions.ApplyFilters("'" + cboTutorID.Text + "'", "TutorID", "Tutors", cboTutorID, cboFirstName, cboSurname);
            }
            else if (cbo == cboFirstName)
            {
                ControlFunctions.ApplyFilters("'" + cboFirstName.Text + "'", "FirstName", "Tutors", cboTutorID, cboFirstName, cboSurname);
            }
            else if (cbo == cboSurname)
            {
                ControlFunctions.ApplyFilters("'" + cboSurname.Text + "'", "Surname", "Tutors", cboTutorID, cboFirstName, cboSurname);
            }

            dgvRemoveTutor.DataSource = Tutor.GetTutorList(cboTutorID).Tables[0];

            updating = false;

        }

        private void btnRemoveTutor_Click(object sender, EventArgs e)
        {
            if (dgvRemoveTutor.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dgvRemoveTutor.SelectedRows[0];

                Tutor t = Tutor.GetTutor(Convert.ToInt32(row.Cells[0].Value));

                t.SetID(t.PersonID);

                t.Delete();

                MessageBox.Show("Tutor Removed");

                Reset(this.Controls);
            }
            else
            {
                MessageBox.Show("No row selected.");
            }
        }

        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);
            ControlFunctions.FillBoxes("Tutors", cboTutorID, cboFirstName, cboSurname);
            dgvRemoveTutor.DataSource = Tutor.GetTutorList(cboTutorID).Tables[0];

            ControlFunctions.formatGridView(dgvRemoveTutor);
            

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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Reset(this.Controls);
        }
    }


}

