namespace GrindsBookingSystem
{
    partial class frmHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHome));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tutorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddTutor = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveTutor = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateTutor = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewTutor = new System.Windows.Forms.ToolStripMenuItem();
            this.AssignSubjects = new System.Windows.Forms.ToolStripMenuItem();
            this.subjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddSubject = new System.Windows.Forms.ToolStripMenuItem();
            this.studentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MakeBooking = new System.Windows.Forms.ToolStripMenuItem();
            this.CancelBooking = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.YearlyRevenue = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picHome = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.MidnightBlue;
            this.menuStrip1.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tutorsToolStripMenuItem,
            this.subjectsToolStripMenuItem,
            this.studentsToolStripMenuItem,
            this.scheduleToolStripMenuItem,
            this.bookingsToolStripMenuItem,
            this.adminToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tutorsToolStripMenuItem
            // 
            this.tutorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddTutor,
            this.RemoveTutor,
            this.UpdateTutor,
            this.ViewTutor,
            this.AssignSubjects});
            this.tutorsToolStripMenuItem.ForeColor = System.Drawing.Color.Goldenrod;
            this.tutorsToolStripMenuItem.Name = "tutorsToolStripMenuItem";
            this.tutorsToolStripMenuItem.Size = new System.Drawing.Size(82, 23);
            this.tutorsToolStripMenuItem.Text = "Tutors";
            // 
            // AddTutor
            // 
            this.AddTutor.ForeColor = System.Drawing.Color.Goldenrod;
            this.AddTutor.Name = "AddTutor";
            this.AddTutor.Size = new System.Drawing.Size(261, 24);
            this.AddTutor.Text = "Add Tutor";
            this.AddTutor.Click += new System.EventHandler(this.AddTutor_Click);
            // 
            // RemoveTutor
            // 
            this.RemoveTutor.ForeColor = System.Drawing.Color.Goldenrod;
            this.RemoveTutor.Name = "RemoveTutor";
            this.RemoveTutor.Size = new System.Drawing.Size(261, 24);
            this.RemoveTutor.Text = "Remove Tutor";
            this.RemoveTutor.Click += new System.EventHandler(this.RemoveTutor_Click);
            // 
            // UpdateTutor
            // 
            this.UpdateTutor.ForeColor = System.Drawing.Color.Goldenrod;
            this.UpdateTutor.Name = "UpdateTutor";
            this.UpdateTutor.Size = new System.Drawing.Size(261, 24);
            this.UpdateTutor.Text = "Update Tutor Details";
            this.UpdateTutor.Click += new System.EventHandler(this.UpdateTutor_Click);
            // 
            // ViewTutor
            // 
            this.ViewTutor.ForeColor = System.Drawing.Color.Goldenrod;
            this.ViewTutor.Name = "ViewTutor";
            this.ViewTutor.Size = new System.Drawing.Size(261, 24);
            this.ViewTutor.Text = "View Tutor Details";
            this.ViewTutor.Click += new System.EventHandler(this.ViewTutor_Click);
            // 
            // AssignSubjects
            // 
            this.AssignSubjects.ForeColor = System.Drawing.Color.Goldenrod;
            this.AssignSubjects.Name = "AssignSubjects";
            this.AssignSubjects.Size = new System.Drawing.Size(261, 24);
            this.AssignSubjects.Text = "Assign Subjects";
            this.AssignSubjects.Click += new System.EventHandler(this.AssignSubjects_Click);
            // 
            // subjectsToolStripMenuItem
            // 
            this.subjectsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddSubject});
            this.subjectsToolStripMenuItem.ForeColor = System.Drawing.Color.Goldenrod;
            this.subjectsToolStripMenuItem.Name = "subjectsToolStripMenuItem";
            this.subjectsToolStripMenuItem.Size = new System.Drawing.Size(98, 23);
            this.subjectsToolStripMenuItem.Text = "Subjects";
            // 
            // AddSubject
            // 
            this.AddSubject.ForeColor = System.Drawing.Color.Goldenrod;
            this.AddSubject.Name = "AddSubject";
            this.AddSubject.Size = new System.Drawing.Size(180, 24);
            this.AddSubject.Text = "Add Subject";
            this.AddSubject.Click += new System.EventHandler(this.AddSubject_Click);
            // 
            // studentsToolStripMenuItem
            // 
            this.studentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddStudent,
            this.RemoveStudent,
            this.UpdateStudent,
            this.ViewStudent});
            this.studentsToolStripMenuItem.ForeColor = System.Drawing.Color.Goldenrod;
            this.studentsToolStripMenuItem.Name = "studentsToolStripMenuItem";
            this.studentsToolStripMenuItem.Size = new System.Drawing.Size(100, 23);
            this.studentsToolStripMenuItem.Text = "Students";
            // 
            // AddStudent
            // 
            this.AddStudent.ForeColor = System.Drawing.Color.Goldenrod;
            this.AddStudent.Name = "AddStudent";
            this.AddStudent.Size = new System.Drawing.Size(279, 24);
            this.AddStudent.Text = "Add Student";
            this.AddStudent.Click += new System.EventHandler(this.AddStudent_Click);
            // 
            // RemoveStudent
            // 
            this.RemoveStudent.ForeColor = System.Drawing.Color.Goldenrod;
            this.RemoveStudent.Name = "RemoveStudent";
            this.RemoveStudent.Size = new System.Drawing.Size(279, 24);
            this.RemoveStudent.Text = "Remove Student";
            this.RemoveStudent.Click += new System.EventHandler(this.RemoveStudent_Click);
            // 
            // UpdateStudent
            // 
            this.UpdateStudent.ForeColor = System.Drawing.Color.Goldenrod;
            this.UpdateStudent.Name = "UpdateStudent";
            this.UpdateStudent.Size = new System.Drawing.Size(279, 24);
            this.UpdateStudent.Text = "Update Student Details";
            this.UpdateStudent.Click += new System.EventHandler(this.UpdateStudent_Click);
            // 
            // ViewStudent
            // 
            this.ViewStudent.ForeColor = System.Drawing.Color.Goldenrod;
            this.ViewStudent.Name = "ViewStudent";
            this.ViewStudent.Size = new System.Drawing.Size(279, 24);
            this.ViewStudent.Text = "View Student Details";
            this.ViewStudent.Click += new System.EventHandler(this.ViewStudent_Click);
            // 
            // scheduleToolStripMenuItem
            // 
            this.scheduleToolStripMenuItem.ForeColor = System.Drawing.Color.Goldenrod;
            this.scheduleToolStripMenuItem.Name = "scheduleToolStripMenuItem";
            this.scheduleToolStripMenuItem.Size = new System.Drawing.Size(99, 23);
            this.scheduleToolStripMenuItem.Text = "Schedule";
            this.scheduleToolStripMenuItem.Click += new System.EventHandler(this.scheduleToolStripMenuItem_Click);
            // 
            // bookingsToolStripMenuItem
            // 
            this.bookingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MakeBooking,
            this.CancelBooking});
            this.bookingsToolStripMenuItem.ForeColor = System.Drawing.Color.Goldenrod;
            this.bookingsToolStripMenuItem.Name = "bookingsToolStripMenuItem";
            this.bookingsToolStripMenuItem.Size = new System.Drawing.Size(100, 23);
            this.bookingsToolStripMenuItem.Text = "Bookings";
            // 
            // MakeBooking
            // 
            this.MakeBooking.ForeColor = System.Drawing.Color.Goldenrod;
            this.MakeBooking.Name = "MakeBooking";
            this.MakeBooking.Size = new System.Drawing.Size(224, 24);
            this.MakeBooking.Text = "Make Booking";
            this.MakeBooking.Click += new System.EventHandler(this.MakeBooking_Click);
            // 
            // CancelBooking
            // 
            this.CancelBooking.ForeColor = System.Drawing.Color.Goldenrod;
            this.CancelBooking.Name = "CancelBooking";
            this.CancelBooking.Size = new System.Drawing.Size(224, 24);
            this.CancelBooking.Text = "Manage Bookings";
            this.CancelBooking.Click += new System.EventHandler(this.CancelBooking_Click);
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.BackColor = System.Drawing.Color.MidnightBlue;
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.YearlyRevenue});
            this.adminToolStripMenuItem.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminToolStripMenuItem.ForeColor = System.Drawing.Color.Goldenrod;
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(71, 23);
            this.adminToolStripMenuItem.Text = "Admin";
            // 
            // YearlyRevenue
            // 
            this.YearlyRevenue.ForeColor = System.Drawing.Color.Goldenrod;
            this.YearlyRevenue.Name = "YearlyRevenue";
            this.YearlyRevenue.Size = new System.Drawing.Size(180, 24);
            this.YearlyRevenue.Text = "Statistics";
            this.YearlyRevenue.Click += new System.EventHandler(this.YearlyRevenue_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.Goldenrod;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(56, 23);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // picHome
            // 
            this.picHome.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picHome.BackgroundImage")));
            this.picHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picHome.Cursor = System.Windows.Forms.Cursors.Default;
            this.picHome.Location = new System.Drawing.Point(0, 27);
            this.picHome.Name = "picHome";
            this.picHome.Size = new System.Drawing.Size(800, 425);
            this.picHome.TabIndex = 1;
            this.picHome.TabStop = false;
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.picHome);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmHome";
            this.Text = "Top Mark Tutors - Home";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem studentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddStudent;
        private System.Windows.Forms.ToolStripMenuItem RemoveStudent;
        private System.Windows.Forms.ToolStripMenuItem UpdateStudent;
        private System.Windows.Forms.ToolStripMenuItem ViewStudent;
        private System.Windows.Forms.ToolStripMenuItem tutorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddTutor;
        private System.Windows.Forms.ToolStripMenuItem RemoveTutor;
        private System.Windows.Forms.ToolStripMenuItem UpdateTutor;
        private System.Windows.Forms.ToolStripMenuItem ViewTutor;
        private System.Windows.Forms.ToolStripMenuItem scheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MakeBooking;
        private System.Windows.Forms.ToolStripMenuItem CancelBooking;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.PictureBox picHome;
        private System.Windows.Forms.ToolStripMenuItem YearlyRevenue;
        private System.Windows.Forms.ToolStripMenuItem subjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddSubject;
        private System.Windows.Forms.ToolStripMenuItem AssignSubjects;
    }
}

