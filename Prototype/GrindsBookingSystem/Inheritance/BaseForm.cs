using GrindsBookingSystem.HelperClasses;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using ComboBox = System.Windows.Forms.ComboBox;
using TextBox = System.Windows.Forms.TextBox;
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
                    txt.Clear();
                }
                else if (control is ComboBox cb)
                {
                    cb.Items.Clear();
                    cb.SelectedIndex = -1;
                    cb.Text = "";
                }
                else if (control is RadioButton rb)
                {
                    rb.AutoCheck = false;
                    rb.Checked = false;
                    rb.AutoCheck = true;
                }

                if (control.HasChildren)
                {
                    Reset(control.Controls);
                }
            }
        }

        protected void Style(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Button btn)
                {
                    btn.BackColor = Color.MidnightBlue;
                    btn.ForeColor = Color.AliceBlue;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Font = new Font("Arial", 12);
                    btn.AutoSize = true;
                    btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                    btn.Padding = new Padding(5);
                    MakeRounded(btn, 15);
                }
                if(c is ComboBox cb)
                {
                    cb.BackColor = Color.White;
                    cb.ForeColor = Color.MidnightBlue;
                    cb.FlatStyle = FlatStyle.Popup;
                }
                if(c is Label lb)
                {
                    lb.Font = new Font("Arial", 12);
                }
                if(c is GroupBox gp)
                {
                    gp.Font = new Font("Arial", 12);
                }
                if (c.HasChildren)
                    Style(c);
            }

            
        }
        protected void Exit()
        {
            DialogResult result = CustomDialogMessageBox.Show("Are you sure you want to exit ?");

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        public static void ErrorMessage(string message)
        {
            CustomMessageBox.ErrorMessage(message);
        }

        public static void SuccessMessage(string message)
        {
            CustomMessageBox.SuccessMessage(message);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.ExitButton = new System.Windows.Forms.ToolStripMenuItem();
            this.BackButton = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshButton = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.MidnightBlue;
            this.menuStrip2.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitButton,
            this.BackButton,
            this.RefreshButton});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(206, 27);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // ExitButton
            // 
            this.ExitButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ExitButton.ForeColor = System.Drawing.Color.Goldenrod;
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(56, 23);
            this.ExitButton.Text = "Exit";
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.BackButton.ForeColor = System.Drawing.Color.Goldenrod;
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(63, 23);
            this.BackButton.Text = "Back";
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.RefreshButton.ForeColor = System.Drawing.Color.Goldenrod;
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(91, 23);
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // BaseForm
            // 
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(206, 147);
            this.Controls.Add(this.menuStrip2);
            this.ForeColor = System.Drawing.Color.MidnightBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip2;
            this.Name = "BaseForm";
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void BaseForm_Load(object sender, System.EventArgs e)
        {
            Style(this);
        }

        //all styling and ui content
        //Microsoft (n.d.) Windows Forms Controls – Button Class (styling and properties). Available at: https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.button
        //Microsoft(n.d.) Windows Forms Visual Design Basics.Available at: https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/

        public static void MakeRounded(Button btn, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            int diameter = radius * 2;

            Rectangle rect = new Rectangle(0, 0, btn.Width, btn.Height);

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);

            path.CloseFigure();

            btn.Region = new Region(path);
        }
}
    
        
}




