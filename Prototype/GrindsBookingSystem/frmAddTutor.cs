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

                SuccessMessage("Tutor " + txtTutorName.Text + " " + txtTutorSurname.Text + " has been succesfully added to the system.");

                DialogResult addAnother = MessageBox.Show("Would you like to add another Tutor?",
                                                    "Please Confirm",
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
                    ErrorMessage("Tutor Rate and Subject must be selected, please try again.");
                    return;
                }
                else
                {
                    ErrorMessage("Invalid Entry, " + t.IsValid());
                }
                    
            }
        }
        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);
            ControlFunctions.FillRatesAndSubjects(cboTutorRates, cboTutorSubjects);
        }
    }
}