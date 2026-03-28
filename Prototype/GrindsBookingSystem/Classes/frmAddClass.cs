using System;
using System.Windows.Forms;


namespace GrindsBookingSystem
{
    public partial class frmAddClass : ClassBaseForm
    {
        private int Day {  get; set; }
        private int Time { get; set; }
        private string Room {  get; set; }
        public frmAddClass(int day, int time, string room)
        {
            InitializeComponent();

            Day = day;
            Time = time;
            Room = room;

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

            string tutorID = spaceIndex > -1 ? text.Substring(0, spaceIndex) : text;

            string sub = cboSubjects.Text;

            string cat = sub.Substring(0, 2);
            string level = sub.Substring(3, 2);
            string description = sub.Substring(5);

            string subID = Subject.GetSubjectID(cat, level, description);

            Class c = new Class(Day, Time, tutorID, 0, Room, Class.GetCurrentSemester(), subID);

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
            SetClassDay(Day);
            SetClassTime(Time);
            SetAttendance(Room);
            SetRoom(Room);
        }
    }
}
