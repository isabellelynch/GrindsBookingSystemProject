using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace GrindsBookingSystem
{
    public partial class frmViewSchedule : BaseForm
    {
        int day;
        int time;
        string room;

        public frmViewSchedule()
        {
            InitializeComponent();
            Reset(this.Controls);
        }

        public void btnAddClass_Click(object sender, EventArgs e)
        {
            DataGridViewCell c = dgvSchedule.CurrentCell;

            string msg = CheckSelected(c, btnAddClass);

            if (msg != "")
            {
                ErrorMessage(msg);
                return;
            }

            day = c.ColumnIndex;
            time = c.RowIndex + 9;
            room = cboRooms.Text.Substring(0, 1);

            frmAddClass f = new frmAddClass(day, time, room);
            f.FormClosing += FillSchedule;
            f.ShowDialog();

            Reset(this.Controls);
        }

        private string CheckSelected(DataGridViewCell c, Button btn)
        {
            day = c.ColumnIndex;
            time = c.RowIndex;
            room = cboRooms.Text;

            string msg = "";
            if(btn == btnAddClass)
            {
                if (room == "")
                {
                    msg = "A room must be chosen before adding a new class";
                }
                else if (day == 0 || day > 5 || time < 0 || time > 8)
                {
                    msg = "An appropriate timeslot must be chosen before continuing";
                }
                else if(c.Value == null)
                {
                    return msg;
                }
                else if (c.Value.ToString().Length > 0)
                {
                    msg = "An empty timeslot must be chosen before adding a new class";
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

            GridViews.Schedule(dgvSchedule);
        }

        private void FillSchedule(object sender, EventArgs e)
        {
            GridViews.FillSchedule(dgvSchedule, cboRooms.Text.Substring(0, 1));
        }

        private void btnAlterClass_Click(object sender, EventArgs e)
        {
            DataGridViewCell c = dgvSchedule.CurrentCell;

            string msg = CheckSelected(c, btnRemoveClass);
            if (msg != "")
            {
                ErrorMessage(msg);
                return;
            }

            day = c.ColumnIndex;
            time = c.RowIndex + 9;
            room = cboRooms.Text.Substring(0, 1);

            try
            {
                int ClassID = Class.GetClassID(day, time, room);
                Class c2 = Class.GetClass(ClassID);

                frmUpdateClass f = new frmUpdateClass(c2);
                f.FormClosing += FillSchedule;
                f.ShowDialog();
            }
            catch(Exception ex)
            {
                ErrorMessage(ex.Message);
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
                ErrorMessage(msg);
                return;
            }
            int ClassID = Class.GetClassID(c.ColumnIndex, c.RowIndex + 9, cboRooms.Text.Substring(0, 1));
            Class c2 = Class.GetClass(ClassID);

            frmRemoveClass f = new frmRemoveClass(c2);
            f.FormClosing += FillSchedule;
            f.ShowDialog();

            Reset(this.Controls);

        }
    }
}
    
