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

namespace GrindsBookingSystem
{

    public partial class frmRemoveTutor : Form
    {
        public frmRemoveTutor()
        {
            InitializeComponent();

            List<ComboBox> comboBoxes = loadComboBoxes.CreateComboList(cboTutID, cboNames, cboSurnames);

            dgvRemoveTutor.DataSource = Tutor.GetAllTutors().Tables[0];

            formatGridView(dgvRemoveTutor);

            loadComboBoxes.IDFirstnameSurname(comboBoxes, "Tutor");
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

        public static void formatGridView(DataGridView grid)
        {
            grid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grid.Columns[0].DefaultCellStyle.Format = "0000";
            grid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            grid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            grid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

       


    }


}

