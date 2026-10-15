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
            string rate = "";

            if(cboTutorRates.Text.Length > 0)
            {
                rate = cboTutorRates.Text.Substring(0, 3);
            }
            

            Tutor t = new Tutor(txtTutorName.Text, txtTutorSurname.Text, txtTutorEmail.Text, txtTutorPhone.Text, rate);

            if(t.IsValid() == "Valid")
            {
                if (Tutor.DoesTutorExist(t.Email) == false) 
                {
                    try
                    {
                        t.Create();

                        SuccessMessage("Tutor " + txtTutorName.Text + " " + txtTutorSurname.Text + " has been successfully added to the system.");

                        DialogResult addAnother = CustomDialogMessageBox.Show("Would you like to add another Tutor?",
                                                                              "Please Confirm");
                        if (addAnother == DialogResult.Yes)
                        {
                            Reset(this.Controls);
                        }
                        else
                        {
                            GoHome();
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage(ex.Message);
                    }   
                }
                else
                {
                    ErrorMessage("Tutor with the email " + t.Email + " already exists on the system.");
                }
                
            }
            else
            {
                ErrorMessage("Invalid Entry, " + t.IsValid());
            }
        }
        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);
            ControlFunctions.FillRates(cboTutorRates);
        }
    }
}