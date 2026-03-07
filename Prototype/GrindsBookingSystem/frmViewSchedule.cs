using System;
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

            GridViews.Schedule(dgvSchedule, 6);
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
    
