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
        }

        private void frmRemoveTutor_Load(object sender, EventArgs e)
        {
            dgvRemoveTutor.DataSource = Tutor.GetAllTutors().Tables[0];
            formatGridView(dgvRemoveTutor);

            loadFirstNames();
            loadSurnames();
            loadTutorIDs();

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

        public void loadTutorIDs()
        {
            cboTutID.Items.Clear();

            String sql = "SELECT TutorID FROM Tutors";

            DataSet ds = Database.ExecuteMultiRowQuery(sql);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cboTutID.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }

        }

        public void loadFirstNames()
        {
            cboNames.Items.Clear();

            String sql = "SELECT FirstName FROM Tutors";

            DataSet ds = Database.ExecuteMultiRowQuery(sql);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cboNames.Items.Add(ds.Tables[0].Rows[i][0]);
            }

        }
        public void loadSurnames()
        {
            cboSurnames.Items.Clear();

            String sql = "SELECT Surname FROM Tutors";

            DataSet ds = Database.ExecuteMultiRowQuery(sql);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cboSurnames.Items.Add(ds.Tables[0].Rows[i][0]);
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

