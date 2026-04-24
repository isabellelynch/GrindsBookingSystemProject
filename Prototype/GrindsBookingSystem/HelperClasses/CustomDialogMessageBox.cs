using System;
using System.Drawing;
using System.Windows.Forms;

public class CustomDialogMessageBox : Form
{
    private Label lblMessage;
    private Button btnYes;
    private Button btnNo;

    public DialogResult Result { get; private set; }

    public CustomDialogMessageBox(string message, string title)
    { 
        Text = title;
        Size = new Size(420, 180);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        BackColor = Color.AliceBlue;
        ForeColor = Color.MidnightBlue;
        MaximizeBox = false;
        MinimizeBox = false;
        

        lblMessage = new Label()
        {
            Text = message,
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Arial", 12, FontStyle.Bold),
            ForeColor = Color.MidnightBlue
        };

        btnYes = new Button()
        {
            Text = "Yes",
            Width = 120,
            Height = 40,
            BackColor = Color.MidnightBlue,
            ForeColor = Color.AliceBlue,
            FlatStyle = FlatStyle.Flat
        };

        btnYes.FlatAppearance.BorderSize = 0;
        btnYes.Click += (s, e) =>
        {
            Result = DialogResult.Yes;
            Close();
        };

        btnNo = new Button()
        {
            Text = "No",
            Width = 120,
            Height = 40,
            BackColor = Color.MidnightBlue,
            ForeColor = Color.AliceBlue,
            FlatStyle = FlatStyle.Flat
        };

        btnNo.FlatAppearance.BorderSize = 0;
        btnNo.Click += (s, e) =>
        {
            Result = DialogResult.No;
            Close();
        };

        Panel panel = new Panel()
        {
            Dock = DockStyle.Bottom,
            Height = 60,
            BackColor = Color.AliceBlue
        };

        panel.Controls.Add(btnNo);
        panel.Controls.Add(btnYes);

        panel.Resize += (s, e) =>
        {
            int spacing = 10;

            int totalWidth = btnYes.Width + btnNo.Width + spacing;

            int startX = (panel.Width / 2) - (totalWidth / 2);

            btnYes.Location = new Point(startX, 10);
            btnNo.Location = new Point(startX + btnYes.Width + spacing, 10);
        };


        Controls.Add(lblMessage);
        Controls.Add(panel);
    }

    public static DialogResult Show(string message, string title = "Confirm")
    {
        using (var box = new CustomDialogMessageBox(message, title))
        {
            box.ShowDialog();
            return box.Result;
        }
    }
}