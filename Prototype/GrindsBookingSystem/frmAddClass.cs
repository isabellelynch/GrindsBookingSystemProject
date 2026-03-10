using System;
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
         

        private void btnClass_Click(object sender, EventArgs e)
        {
            if (cboTutors.Text == "")
            {
                ErrorMessage("A Tutor must be chosen before adding a class");
                return;
            }
            
            string text = cboTutors.Text;
            int spaceIndex = text.IndexOf(" ");

            string id = spaceIndex > -1 ? text.Substring(0, spaceIndex) : text;

            int t = Convert.ToInt32(cboTime.Text.Substring(0, cboTime.Text.IndexOf(':')));

            Class c = new Class(Day, t, id, 0, Room, Class.GetCurrentSemester(), "1");

            try
            {
                c.Create();
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message);
                return;
            }

            SuccessMessage("Your Class has been sucessfully added to the Schedule");

            GoHome();
        }

        private void frmAddClass_Load(object sender, EventArgs e)
        {
            btnClass.Text = "Add Class";
        }
    }
}
