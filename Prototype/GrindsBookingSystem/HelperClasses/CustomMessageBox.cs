using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
namespace GrindsBookingSystem.HelperClasses
{
    public class CustomMessageBox: Form
    {
        private Label lblMessage;
        private Button btnOk;

        public CustomMessageBox(string message, string title)
        {
            Text = title;
            Size = new Size(420, 180);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            BackColor = Color.AliceBlue;
            ForeColor = Color.Goldenrod;
            MaximizeBox = false;
            MinimizeBox = false;

            lblMessage = new Label()
            {
                Text = message,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.MidnightBlue
            };

            btnOk = new Button()
            {
                Text = "OK",
                Height = 40,
                Dock = DockStyle.Bottom,
                BackColor = Color.MidnightBlue,
                ForeColor = Color.AliceBlue,
                FlatStyle = FlatStyle.Flat
            };

            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.Click += (s, e) => Close();


            lblMessage.Text = message;

            Controls.Add(lblMessage);
            Controls.Add(btnOk);
        }
        public static void ErrorMessage(string message, string title = "Error")
        {
            using (var box = new CustomMessageBox(message, title))
            {
                box.ShowDialog();
            }
        }
        public static void SuccessMessage(string message, string title = "Success")
        {
            using (var box = new CustomMessageBox(message, title))
            {
                box.ShowDialog();
            }
        }

        public static void Show(string message, string title = "Message")
        {
            using (var box = new CustomMessageBox(message, title))
            {
                box.ShowDialog();
            }
        }


        public static void ShowDetails(string message, string title = "Message")
        {
            using (var box = new CustomMessageBox(message, title))
            {
                box.Size = new Size(420, 220);
                box.lblMessage.TextAlign = ContentAlignment.MiddleLeft;
                box.ShowDialog();
            }
        }
    }
}
