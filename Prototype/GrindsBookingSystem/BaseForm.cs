using System.Windows.Forms;

namespace GrindsBookingSystem
{

    public class BaseForm : Form
    {
        protected MenuStrip menuStrip2;
        protected ToolStripMenuItem ExitButton;
        protected ToolStripMenuItem BackButton;
        protected ToolStripMenuItem RefreshButton;

        protected BaseForm() 
        {
            this.InitializeComponent();
        }
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
                else if (control is RadioButton rb)
                {
                    rb.Checked = false;
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
        public void ErrorMessage(string message)
        {
            MessageBox.Show(message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void SuccessMessage(string message)
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        protected void ExitButton_Click(object sender, System.EventArgs e)
        {
            Exit();
        }

        protected void BackButton_Click(object sender, System.EventArgs e)
        {
            GoHome();
        }

        protected void RefreshButton_Click(object sender, System.EventArgs e)
        {
            Reset(this.Controls);
        }

        protected void InitializeComponent()
        {
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.ExitButton = new System.Windows.Forms.ToolStripMenuItem();
            this.BackButton = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshButton = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitButton,
            this.BackButton,
            this.RefreshButton});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(206, 24);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // ExitButton
            // 
            this.ExitButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(37, 20);
            this.ExitButton.Text = "Exit";
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(44, 20);
            this.BackButton.Text = "Back";
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(58, 20);
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(206, 147);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip2;
            this.Name = "BaseForm";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        
    }
    
        
}




