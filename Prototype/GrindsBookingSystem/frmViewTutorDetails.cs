using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GrindsBookingSystem.frmAddStudent;
using static GrindsBookingSystem.frmAddTutor;
using static GrindsBookingSystem.frmHome;

namespace GrindsBookingSystem
{
    public partial class frmViewTutorDetails : Form
    {
        private bool updating = false;
        public frmViewTutorDetails()
        {
            InitializeComponent();

            List<ComboBox> comboBoxes = loadComboBoxes.CreateComboList(cboTutorID, cboName, cboLastName);

            loadComboBoxes.IDFirstnameSurname(comboBoxes, "Tutor");
            
            foreach(ComboBox cb  in comboBoxes)
            {
                cb.SelectedIndexChanged += ComboBoxChange;
            }
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
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


            if (cbo == cboTutorID)
            {
                ApplyFilters(cboTutorID.Text, "TutorID");
            }
            else if (cbo == cboName)
            {
                ApplyFilters("'" + cboName.Text + "'", "FirstName");
            }
            else if (cbo == cboLastName) 
            {
                ApplyFilters("'" + cboLastName.Text + "'", "Surname");
            }

        }
        public void ApplyFilters(String value, String column)
        {
            updating = true;

            String sql = "SELECT TutorID, FirstName, Surname FROM Tutors WHERE " + column + " = " + value;
            DataSet ds = Database.ExecuteMultiRowQuery(sql);

            cboTutorID.Items.Clear();
            cboName.Items.Clear();
            cboLastName.Items.Clear();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cboTutorID.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                cboName.Items.Add(ds.Tables[0].Rows[i][1]);
                cboLastName.Items.Add(ds.Tables[0].Rows[i][2]);
            }

            if (cboTutorID.Items.Count > 1)
            {
                if(column == "FirstName")
                {
                    cboName.SelectedIndex = cboName.Items.IndexOf(value);
                    cboTutorID.SelectedIndex = -1;
                    cboLastName.SelectedIndex = -1;

                }
                else if (column == "Surname")
                {
                    cboName.SelectedIndex = -1;
                    cboTutorID.SelectedIndex = -1;
                    cboLastName.SelectedIndex = cboLastName.Items.IndexOf(value);

                }
            }
            else
            {
                cboTutorID.SelectedIndex = 0;
                cboName.SelectedIndex = 0;
                cboLastName.SelectedIndex = 0;
            }
                updating = false;
        }
       
        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            cboTutorID.SelectedIndex = 0;

            String sql = "SELECT * FROM Tutors WHERE TutorID = " + cboTutorID.Text;

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);
            dr.Read();

            if (dr != null)
            {
                MessageBox.Show("The selected Tutors deatils are as follows\n\nTutor ID: " + dr.GetInt32(0).ToString() + "\nFirst Name: " +
                                dr.GetString(1) + "\nSurname: " + dr.GetString(2) + "\nRate Code: " + dr.GetString(3) + "\nSubject: " +
                                dr.GetString(4) + "\nPhone Number: " + dr.GetString(5) + "\nEmail Address: " + dr.GetString(6), "Tutor Details",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
    
}
