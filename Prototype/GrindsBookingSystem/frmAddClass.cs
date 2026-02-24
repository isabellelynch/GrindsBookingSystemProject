using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;


namespace GrindsBookingSystem
{
    public partial class frmAddClass : ClassBaseForm
    {
        public frmAddClass()
        {
            InitializeComponent();
        }

        public frmAddClass(int day, int time, string room) : base(day, time, room)
        {
            InitializeComponent();
            Reset(this.Controls);
        }
        
        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);

            ControlFunctions.DisableBoxes(cboDays, cboTime, txtAttendance, cboRooms);

            ControlFunctions.FillRooms(cboRooms);

            DataSet ds = Tutor.RetrieveAll();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cboTutors.Items.Add(dr[1].ToString() + " " + dr[2].ToString() + " - " + dr[6].ToString());
            }

            
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
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

         

        private void btnClass_Click(object sender, EventArgs e)
        {
            string details = cboTutors.Text;

            if (details == "")
            {
                MessageBox.Show("A Tutor must be chosen before adding a class", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] parts = details.Split('-');
            string[] nameParts = parts[0].Split(' ');


            string sql = "SELECT TutorID FROM Tutors WHERE FirstName = '" + nameParts[0].Trim() +
                "' AND Surname = '" + nameParts[1].Trim() + "' AND SubjectCode = '" + parts[1].Trim() + "'";
            try
            {
                OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);

                if (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    int t = Convert.ToInt32(cboTime.Text.Substring(0, cboTime.Text.IndexOf(':')));

                    Class c = new Class(Day, t, id.ToString(), 0, Room, Class.GetCurrentSemester());

                    c.Create();
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Your Class has been sucessfully added to the Schedule", "Class Added",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void frmAddClass_Load(object sender, EventArgs e)
        {
            btnClass.Text = "Add Class";
        }
    }
}
