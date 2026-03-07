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
            this.RemoveSubject = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateSubject = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewSubjects = new System.Windows.Forms.ToolStripMenuItem();
            this.studentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MakeBooking = new System.Windows.Forms.ToolStripMenuItem();
            this.CancelBooking = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewBookings = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.YearlyRevenue = new System.Windows.Forms.ToolStripMenuItem();
            this.EarningsAnalysis = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picHome = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
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
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
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
            this.tutorsToolStripMenuItem.Name = "tutorsToolStripMenuItem";
            this.tutorsToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.tutorsToolStripMenuItem.Text = "Tutors";
            // 
            // AddTutor
            // 
            this.AddTutor.Name = "AddTutor";
            this.AddTutor.Size = new System.Drawing.Size(182, 22);
            this.AddTutor.Text = "Add Tutor";
            this.AddTutor.Click += new System.EventHandler(this.AddTutor_Click);
            // 
            // RemoveTutor
            // 
            this.RemoveTutor.Name = "RemoveTutor";
            this.RemoveTutor.Size = new System.Drawing.Size(182, 22);
            this.RemoveTutor.Text = "Remove Tutor";
            this.RemoveTutor.Click += new System.EventHandler(this.RemoveTutor_Click);
            // 
            // UpdateTutor
            // 
            this.UpdateTutor.Name = "UpdateTutor";
            this.UpdateTutor.Size = new System.Drawing.Size(182, 22);
            this.UpdateTutor.Text = "Update Tutor Details";
            this.UpdateTutor.Click += new System.EventHandler(this.UpdateTutor_Click);
            // 
            // ViewTutor
            // 
            this.ViewTutor.Name = "ViewTutor";
            this.ViewTutor.Size = new System.Drawing.Size(182, 22);
            this.ViewTutor.Text = "View Tutor Details";
            this.ViewTutor.Click += new System.EventHandler(this.ViewTutor_Click);
            // 
            // AssignSubjects
            // 
            this.AssignSubjects.Name = "AssignSubjects";
            this.AssignSubjects.Size = new System.Drawing.Size(182, 22);
            this.AssignSubjects.Text = "Assign Subjects";
            this.AssignSubjects.Click += new System.EventHandler(this.AssignSubjects_Click);
            // 
            // subjectsToolStripMenuItem
            // 
            this.subjectsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddSubject,
            this.RemoveSubject,
            this.UpdateSubject,
            this.ViewSubjects});
            this.subjectsToolStripMenuItem.Name = "subjectsToolStripMenuItem";
            this.subjectsToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.subjectsToolStripMenuItem.Text = "Subjects";
            // 
            // AddSubject
            // 
            this.AddSubject.Name = "AddSubject";
            this.AddSubject.Size = new System.Drawing.Size(180, 22);
            this.AddSubject.Text = "Add Subjecst";
            this.AddSubject.Click += new System.EventHandler(this.AddSubject_Click);
            // 
            // RemoveSubject
            // 
            this.RemoveSubject.Name = "RemoveSubject";
            this.RemoveSubject.Size = new System.Drawing.Size(180, 22);
            this.RemoveSubject.Text = "Remove Subject";
            // 
            // UpdateSubject
            // 
            this.UpdateSubject.Name = "UpdateSubject";
            this.UpdateSubject.Size = new System.Drawing.Size(180, 22);
            this.UpdateSubject.Text = "Update Subjects";
            // 
            // ViewSubjects
            // 
            this.ViewSubjects.Name = "ViewSubjects";
            this.ViewSubjects.Size = new System.Drawing.Size(180, 22);
            this.ViewSubjects.Text = "View Subjects";
            // 
            // studentsToolStripMenuItem
            // 
            this.studentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddStudent,
            this.RemoveStudent,
            this.UpdateStudent,
            this.ViewStudent});
            this.studentsToolStripMenuItem.Name = "studentsToolStripMenuItem";
            this.studentsToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.studentsToolStripMenuItem.Text = "Students";
            // 
            // AddStudent
            // 
            this.AddStudent.Name = "AddStudent";
            this.AddStudent.Size = new System.Drawing.Size(194, 22);
            this.AddStudent.Text = "Add Student";
            this.AddStudent.Click += new System.EventHandler(this.AddStudent_Click);
            // 
            // RemoveStudent
            // 
            this.RemoveStudent.Name = "RemoveStudent";
            this.RemoveStudent.Size = new System.Drawing.Size(194, 22);
            this.RemoveStudent.Text = "Remove Student";
            this.RemoveStudent.Click += new System.EventHandler(this.RemoveStudent_Click);
            // 
            // UpdateStudent
            // 
            this.UpdateStudent.Name = "UpdateStudent";
            this.UpdateStudent.Size = new System.Drawing.Size(194, 22);
            this.UpdateStudent.Text = "Update Student Details";
            this.UpdateStudent.Click += new System.EventHandler(this.UpdateStudent_Click);
            // 
            // ViewStudent
            // 
            this.ViewStudent.Name = "ViewStudent";
            this.ViewStudent.Size = new System.Drawing.Size(194, 22);
            this.ViewStudent.Text = "View Student Details";
            this.ViewStudent.Click += new System.EventHandler(this.ViewStudent_Click);
            // 
            // scheduleToolStripMenuItem
            // 
            this.scheduleToolStripMenuItem.Name = "scheduleToolStripMenuItem";
            this.scheduleToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.scheduleToolStripMenuItem.Text = "Schedule";
            this.scheduleToolStripMenuItem.Click += new System.EventHandler(this.scheduleToolStripMenuItem_Click);
            // 
            // bookingsToolStripMenuItem
            // 
            this.bookingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MakeBooking,
            this.CancelBooking,
            this.ViewBookings});
            this.bookingsToolStripMenuItem.Name = "bookingsToolStripMenuItem";
            this.bookingsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.bookingsToolStripMenuItem.Text = "Bookings";
            // 
            // MakeBooking
            // 
            this.MakeBooking.Name = "MakeBooking";
            this.MakeBooking.Size = new System.Drawing.Size(157, 22);
            this.MakeBooking.Text = "Make Booking";
            this.MakeBooking.Click += new System.EventHandler(this.MakeBooking_Click);
            // 
            // CancelBooking
            // 
            this.CancelBooking.Name = "CancelBooking";
            this.CancelBooking.Size = new System.Drawing.Size(157, 22);
            this.CancelBooking.Text = "Cancel Booking";
            this.CancelBooking.Click += new System.EventHandler(this.CancelBooking_Click);
            // 
            // ViewBookings
            // 
            this.ViewBookings.Name = "ViewBookings";
            this.ViewBookings.Size = new System.Drawing.Size(157, 22);
            this.ViewBookings.Text = "View Bookings";
            this.ViewBookings.Click += new System.EventHandler(this.ViewBookings_Click);
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.YearlyRevenue,
            this.EarningsAnalysis});
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.adminToolStripMenuItem.Text = "Admin";
            // 
            // YearlyRevenue
            // 
            this.YearlyRevenue.Name = "YearlyRevenue";
            this.YearlyRevenue.Size = new System.Drawing.Size(199, 22);
            this.YearlyRevenue.Text = "Yearly Revenue Analysis";
            this.YearlyRevenue.Click += new System.EventHandler(this.YearlyRevenue_Click);
            // 
            // EarningsAnalysis
            // 
            this.EarningsAnalysis.Name = "EarningsAnalysis";
            this.EarningsAnalysis.Size = new System.Drawing.Size(199, 22);
            this.EarningsAnalysis.Text = "Tutor Earnings Analysis";
            this.EarningsAnalysis.Click += new System.EventHandler(this.EarningsAnalysis_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // picHome
            // 
            this.picHome.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picHome.BackgroundImage")));
            this.picHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picHome.Location = new System.Drawing.Point(0, 27);
            this.picHome.Name = "picHome";
            this.picHome.Size = new System.Drawing.Size(800, 423);
            this.picHome.TabIndex = 1;
            this.picHome.TabStop = false;
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.picHome);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmHome";
            this.Text = "Home Page - Grinds Booking System";
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
        private System.Windows.Forms.ToolStripMenuItem ViewBookings;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.PictureBox picHome;
        private System.Windows.Forms.ToolStripMenuItem YearlyRevenue;
        private System.Windows.Forms.ToolStripMenuItem EarningsAnalysis;
        private System.Windows.Forms.ToolStripMenuItem subjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddSubject;
        private System.Windows.Forms.ToolStripMenuItem AssignSubjects;
        private System.Windows.Forms.ToolStripMenuItem RemoveSubject;
        private System.Windows.Forms.ToolStripMenuItem UpdateSubject;
        private System.Windows.Forms.ToolStripMenuItem ViewSubjects;
    }
}

