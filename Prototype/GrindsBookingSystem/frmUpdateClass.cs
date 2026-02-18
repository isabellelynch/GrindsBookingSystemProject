using System;
using System.Data;
using System.Windows.Forms;

namespace GrindsBookingSystem
{
    public partial class frmUpdateClass : ClassBaseForm
    {
        public int day { get; set; }
        public int time { get; set; }
        public string room { get; set; }
        public frmUpdateClass(int day, int time, string room)
        {
            InitializeComponent();
            
            this.day = day;
            this.time = time;
            this.room = room;
            
            Reset(this.Controls);
        }

        private void frmUpdateClass_Load(object sender, EventArgs e)
        {
            SetClassDay(day, txtDay);
            SetClassTime(time, txtTime);
            SetAttendance(txtAttendance, room);
            SetRoom(cboRooms, room);
        }

        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);

            ControlFunctions.DisableBoxes(txtDay, txtTime, txtAttendance, cboRooms);

            ControlFunctions.FillRooms(cboRooms);

            DataSet ds = Tutor.RetrieveAll();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cboTutors.Items.Add(dr[1].ToString() + " " + dr[2].ToString() + " - " + dr[6].ToString());
            }


        }
    }
}
