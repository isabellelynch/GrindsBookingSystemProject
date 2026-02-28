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
            Reset(this.Controls);
        }


        private void FormatGridView()
        {
            if (dgvSchedule.Disposing) { return; }

            dgvSchedule.Columns.Clear();
            dgvSchedule.Rows.Clear();
            
            
            dgvSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSchedule.EnableHeadersVisualStyles = false;
            dgvSchedule.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkCyan;
            dgvSchedule.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSchedule.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

            dgvSchedule.Columns.Add("Time", "Time");
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday"};
            foreach (var day in days)
            {
                dgvSchedule.Columns.Add(day, day);
            }

            for (int i = 1; i <= 5; i++)
            {
                dgvSchedule.Columns[i].Width = 120;
            }

            dgvSchedule.Columns[0].Width = 80;

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

            DataGridViewCell c = dgvSchedule.CurrentCell;

            string msg = CheckSelected(c, btnAddClass);
            if (msg != "")
            {
                MessageBox.Show(msg + " must be chosen before adding a class.", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmAddClass f = new frmAddClass(c.ColumnIndex, c.RowIndex+9, cboRooms.Text.Substring(0, 1));
            f.FormClosing += FillSchedule;
            f.ShowDialog();

            Reset(this.Controls);
        }

        private string CheckSelected(DataGridViewCell c, Button btn)
        {
            int day = c.ColumnIndex;
            int time = c.RowIndex;
            string room = cboRooms.Text;

            string msg = "";
            if(btn == btnAddClass)
            {
                if (room == "")
                {
                    msg = "A room" + msg;
                }
                else if (day == 0 || day > 5 || time < 0 || time > 8)
                {
                    msg = "An appropriate timeslot" + msg;
                }
                else if (c.Value.ToString() != "")
                {
                    msg = "An empty timeslot" + msg;
                }
            }
            else if(btn == btnRemoveClass)
            {
                if (day == 0 || day > 5 || time < 0 || time > 8 || c.Value.ToString() == "")
                {
                    msg = "A class must be chosen in order to remove it.";
                }
            }
            return msg;

        }

        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);

            ControlFunctions.FillRooms(cboRooms);

            cboRooms.SelectedIndexChanged -= FillSchedule;
            cboRooms.SelectedIndexChanged += FillSchedule;

            FormatGridView();
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
            List<Class> classList = Class.ClassList(cboRooms.Text.Substring(0,1), Class.GetCurrentSemester());

            foreach (Class c in classList)
            {
                int rowIndex = c.Time - 9;

                if (rowIndex < 0 || rowIndex >= dgvSchedule.Rows.Count) continue;

                int colIndex = ((int)c.Day + 6) % 7 + 1;

                Tutor t = Tutor.GetTutor(Convert.ToInt32(c.TutorID));

                dgvSchedule.Rows[rowIndex].Cells[colIndex].Value = t.Subject + " - " + t.FirstName + " " + t.Surname;
            }
        }

        private void btnAlterClass_Click(object sender, EventArgs e)
        {
            DataGridViewCell c = dgvSchedule.CurrentCell;

            string msg = CheckSelected(c, btnRemoveClass);
            if (msg != "")
            {
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Class c2 = Class.GetClass(c.ColumnIndex, c.RowIndex + 9, cboRooms.Text.Substring(0, 1));

                frmUpdateClass f = new frmUpdateClass(c2.Day, c2.Time, c2.RoomNo, c2);
                f.FormClosing += FillSchedule;
                f.ShowDialog();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            Reset(this.Controls);
        }

        private void btnRemoveClass_Click(object sender, EventArgs e)
        {
            DataGridViewCell c = dgvSchedule.CurrentCell;

            string msg = CheckSelected(c, btnRemoveClass);

            if (msg != "")
            {
                MessageBox.Show(msg ,"Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Class c2 = Class.GetClass(c.ColumnIndex, c.RowIndex + 9, cboRooms.Text.Substring(0,1));

            frmRemoveClass f = new frmRemoveClass(c2.Day, c2.Time, c2.RoomNo, c2);
            f.FormClosing += FillSchedule;
            f.ShowDialog();

            Reset(this.Controls);

        }
    }
}
    
