using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace GrindsBookingSystem
{
    public partial class frmViewSchedule : BaseForm
    {
        public frmViewSchedule()
        {
            InitializeComponent();
            FormatGridView();
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

        private void FormatGridView()
        {
            dgvSchedule.Columns.Clear();
            dgvSchedule.Rows.Clear();

            //add headings
            dgvSchedule.Columns.Add("Time", "Time");

            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday"};
            
            dgvSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //header styling
            dgvSchedule.EnableHeadersVisualStyles = false;
            dgvSchedule.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgvSchedule.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSchedule.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

            foreach (var day in days)
            {
                dgvSchedule.Columns.Add(day, day);
            }

            for (int i = 1; i <= 5; i++)
            {
                dgvSchedule.Columns[i].Width = 120;
            }

            dgvSchedule.Columns[0].Width = 80;

            
            //add time fields
            for (int hour = 9; hour <= 17; hour++)
            {
                int rowIndex = dgvSchedule.Rows.Add();
                dgvSchedule.Rows[rowIndex].Cells[0].Value = $"{hour:00}:00";
            }

            dgvSchedule.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSchedule.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvSchedule.GridColor = Color.Gray;
            dgvSchedule.ScrollBars = ScrollBars.None;
        }

        public void btnAddClass_Click(object sender, EventArgs e)
        {
            int day = dgvSchedule.CurrentCell.ColumnIndex;
            int time = dgvSchedule.CurrentCell.RowIndex;
            string room = cboRooms.Text.Substring(0,1);

            if(room == null)
            {
                MessageBox.Show("A Room must be chosen before adding a class", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (day == 0 || time < 0)
            {
                MessageBox.Show("A Timeslot must be chosen before adding a class", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmAddClass f = new frmAddClass(day, time, room);
            
            f.Owner = this;
            f.Show();
            f.Focus();
            
        }

        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);
            ControlFunctions.FillRooms(cboRooms);
            cboRooms.SelectedIndexChanged -= FillSchedule;
            cboRooms.SelectedIndexChanged += FillSchedule;
        }

        private void FillSchedule(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvSchedule.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex != 0 && !row.IsNewRow)
                    {
                        cell.Value = "";
                    }
                }
            }
            List<Class> classList = Class.ClassList(cboRooms.Text.Substring(0,1), 2);

            foreach (Class c in classList)
            {
                int rowIndex = c.Time - 9;

                if (rowIndex < 0 || rowIndex >= dgvSchedule.Rows.Count) continue;

                int colIndex = ((int)c.Day + 6) % 7 + 1;

                Tutor t = Tutor.GetTutor(Convert.ToInt32(c.TutorID));

                dgvSchedule.Rows[rowIndex].Cells[colIndex].Value = t.Subject + " - " + t.FirstName + " " + t.Surname;
            }
        }

    }
}
    
