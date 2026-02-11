using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GrindsBookingSystem.frmAddTutor;
using static GrindsBookingSystem.frmHome;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;

namespace GrindsBookingSystem
{

    public partial class frmRemoveTutor : Form
    {
        List<ComboBox> comboBoxes;
        private bool updating = false;
        public frmRemoveTutor()
        {
            InitializeComponent();

            dgvRemoveTutor.DataSource = Tutor.RetrieveAll().Tables[0];

            ControlFunctions.formatGridView(dgvRemoveTutor);

            ControlFunctions.FillBoxes("Tutors", cboTutorID, cboFirstName, cboSurname);

            comboBoxes = ControlFunctions.CreateComboList(cboTutorID, cboFirstName, cboSurname);

            foreach (ComboBox cb in comboBoxes)
            {
                cb.SelectedIndexChanged += ComboBoxChange;
            }
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Owner.Show();
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

                t.SetID(row.Cells[0].Value.ToString());

                t.Remove();

                MessageBox.Show("Tutor Removed");
            }
            else
            {
                MessageBox.Show("No row selected.");
            }
        }
    }


}

