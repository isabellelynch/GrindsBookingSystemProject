using System.Windows.Forms;

namespace GrindsBookingSystem
{
    public partial class frmRemoveClass : ClassBaseForm
    {
        public Class c1;
        public frmRemoveClass()
        {
            InitializeComponent();
        }

        public frmRemoveClass(int day, int time, string room, Class c) : base(day, time, room)
        {
            InitializeComponent();
            c1 = c;
            Reset(this.Controls);
        }

        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);
            SetTutor(cboTutors, c1.TutorID);
            ControlFunctions.DisableBoxes(cboTutors);
        }

        private void frmRemoveClass_Load(object sender, System.EventArgs e)
        {
            btnClass.Text = "Remove Class";
        }

        private void btnClass_Click(object sender, System.EventArgs e)
        {
            c1.Delete();
            GoHome();
        }
    }
}
