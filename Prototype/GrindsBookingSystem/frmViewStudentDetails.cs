using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GrindsBookingSystem.frmAddStudent;
using static GrindsBookingSystem.frmHome;


namespace GrindsBookingSystem
{
    public partial class frmViewStudentDetails : Form
    {
        private bool updating = false;
        public frmViewStudentDetails()
        {
            InitializeComponent();

            List<ComboBox> comboBoxes = loadComboBoxes.CreateComboList(cboStudentID, cboFirstName, cboLastName);

            loadComboBoxes.IDFirstnameSurname(comboBoxes, "Student");

            foreach(ComboBox cb in comboBoxes)
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

      

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            cboStudentID.SelectedIndex = 0;

            String sql = "SELECT * FROM Students WHERE StudentID = " + cboStudentID.Text;

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);
            dr.Read();

            if (dr != null)
            {
                MessageBox.Show("The selected Students details are as follows\n\nStudent ID: " + dr.GetInt32(0).ToString() + "\nFirst Name: " +
                                dr.GetString(1) + "\nSurname: " + dr.GetString(2) + "\nPhone Number: " + dr.GetString(3) + "\nEmail Address: " +
                                dr.GetString(4), "Tutor Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            if (cbo == cboStudentID)
            {
                ApplyFilters(cboStudentID.Text, "StudentID", "Student", comboBoxes, cbo);
            }
            else if (cbo == cboFirstName)
            {
                ApplyFilters("'" + cboFirstName.Text + "'", "FirstName", "Student", comboBoxes, cbo);
            }
            else if (cbo == cboLastName)
            {
                ApplyFilters("'" + cboLastName.Text + "'", "Surname", "Student", comboBoxes, cbo);
            }

        }
        public void ApplyFilters(String value, String column, String location, List<ComboBox> c, ComboBox send)
        {
            updating = true;

            String sql = "SELECT " + location + "ID, FirstName, Surname FROM " + location + "s WHERE " + column + " = " + value;
            DataSet ds = Database.ExecuteMultiRowQuery(sql);

            foreach (var cb in c)
            {
                cb.Items.Clear();
            }

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                c[0].Items.Add(ds.Tables[0].Rows[i][location + "ID"].ToString());
                c[1].Items.Add(ds.Tables[0].Rows[i]["FirstName"].ToString());
                c[2].Items.Add(ds.Tables[0].Rows[i]["Surname"].ToString());
            }


            if (c[0].Items.Count > 1)
            {
                foreach (var cb in c)
                {
                    cb.SelectedIndex = -1;
                }
            }
            else
            {
                foreach (var cb in c)
                {
                    if (cb.Items.Count == 1)
                    {
                        cb.SelectedIndex = 0;
                    }
                    else
                    {
                        cb.SelectedIndex = -1;
                    }
                }
            }
            updating = false;
        }
    }
}
