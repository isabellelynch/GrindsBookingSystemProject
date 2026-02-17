using System;
using System.Windows.Forms;


namespace GrindsBookingSystem
{
    public partial class frmAddTutor : BaseForm
    {
        public frmAddTutor()
        {
            InitializeComponent();
            Reset(this.Controls);
        }
        private void btnAddTutor_Click(object sender, EventArgs e)
        {
            
            String rate = cboTutorRates.Text.Substring(0,3);
            
            String subject = cboTutorSubjects.Text.Substring(0,3);

            Tutor t = new Tutor(txtTutorName.Text, txtTutorSurname.Text, txtTutorEmail.Text, txtTutorPhone.Text, rate, subject);

            if(t.IsValid() == "Valid")
            {
                t.Create();

                DialogResult addAnother = MessageBox.Show("Tutor " + txtTutorName.Text + " " + txtTutorSurname.Text + " has been succesfully added to the system. Would you like to add another Tutor?",
                                                            "Success",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question);
                if (addAnother == DialogResult.Yes)
                {
                    Reset(this.Controls);
                }
                else
                {
                    GoHome();
                }
            }
            else
            {
                if(!Validation.ComboSelected(cboTutorRates) || !Validation.ComboSelected(cboTutorSubjects))
                {
                    MessageBox.Show("Tutor Rate and Subject must be selected, please try again.",
                        "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Invalid Entry, " + t.IsValid(), "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                    
            }
        }
        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);
            ControlFunctions.FillRatesAndSubjects(cboTutorRates, cboTutorSubjects);
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            GoHome();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Reset(this.Controls);
        }
    }
}