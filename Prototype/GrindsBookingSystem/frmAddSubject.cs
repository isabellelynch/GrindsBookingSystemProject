using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrindsBookingSystem
{
    public partial class frmAddSubject : BaseForm
    {
        public frmAddSubject()
        {
            InitializeComponent();
            Reset(this.Controls);

        }

        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            if (!radioJunior.Checked && !radioLeaving.Checked)
            {
                ErrorMessage("Please select Leaving or Junior Certificate to continue.");
                return;
            }
            else if (!radioHigher.Checked && !radioOrdinary.Checked)
            {
                ErrorMessage("Please select ordinary or Higher Level to continue.");
                return;
            }
            else if (string.IsNullOrEmpty(txtSubjectName.Text))
            {
                ErrorMessage("Please enter an appropriate Subject Name to continue");
                return;
            }
            else
            {
                string level = "HL";
                string cert = "LC";
                if (radioOrdinary.Checked)
                {
                    level = "OL";
                }
                if (radioJunior.Checked)
                {
                    cert = "JC";
                }

                Subject s = new Subject(cert, level, txtSubjectName.Text);
                try
                {
                    s.Create();
                    SuccessMessage("Subject Added Successfully.");
                }
                catch (Exception ex)
                {
                    ErrorMessage(ex.ToString());
                }
                
                Reset(this.Controls);

            }
        }
    }
}
