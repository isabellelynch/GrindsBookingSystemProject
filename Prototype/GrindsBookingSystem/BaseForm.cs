using System.Windows.Forms;

namespace GrindsBookingSystem
{

    public class BaseForm : Form
    {
        public BaseForm() { }
        protected void GoHome()
        {
            if (this.Owner != null)
            {
                this.Owner.Show();
            }

            this.Close();
        }

        protected virtual void Reset(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is TextBox txt)
                {
                    txt.Text = "";
                }
                else if (control is ComboBox cb)
                {
                    cb.Items.Clear();
                    cb.SelectedIndex = -1;
                    cb.Text = "";
                }
                if (control.HasChildren)
                {
                    Reset(control.Controls);
                }
            }
        }

        protected void Exit()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit ?",
                                                    "Please Confirm",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
    
        
}




