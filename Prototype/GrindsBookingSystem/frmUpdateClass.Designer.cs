namespace GrindsBookingSystem
{
    partial class frmUpdateClass
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
            this.btnRemoveClass = new System.Windows.Forms.Button();
            this.cboTutors = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboRooms = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAttendance = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mnuViewStudentDetails = new System.Windows.Forms.MenuStrip();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBack = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUpdateClass = new System.Windows.Forms.Button();
            this.cboTime = new System.Windows.Forms.ComboBox();
            this.cboDays = new System.Windows.Forms.ComboBox();
            this.mnuViewStudentDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRemoveClass
            // 
            this.btnRemoveClass.Location = new System.Drawing.Point(98, 377);
            this.btnRemoveClass.Name = "btnRemoveClass";
            this.btnRemoveClass.Size = new System.Drawing.Size(100, 33);
            this.btnRemoveClass.TabIndex = 41;
            this.btnRemoveClass.Text = "Remove Class";
            this.btnRemoveClass.UseVisualStyleBackColor = true;
            this.btnRemoveClass.Click += new System.EventHandler(this.btnRemoveClass_Click);
            // 
            // cboTutors
            // 
            this.cboTutors.FormattingEnabled = true;
            this.cboTutors.Location = new System.Drawing.Point(188, 315);
            this.cboTutors.Name = "cboTutors";
            this.cboTutors.Size = new System.Drawing.Size(200, 21);
            this.cboTutors.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 323);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Tutor";
            // 
            // cboRooms
            // 
            this.cboRooms.FormattingEnabled = true;
            this.cboRooms.Location = new System.Drawing.Point(188, 261);
            this.cboRooms.Name = "cboRooms";
            this.cboRooms.Size = new System.Drawing.Size(200, 21);
            this.cboRooms.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Room";
            // 
            // txtAttendance
            // 
            this.txtAttendance.Location = new System.Drawing.Point(188, 206);
            this.txtAttendance.Name = "txtAttendance";
            this.txtAttendance.Size = new System.Drawing.Size(200, 20);
            this.txtAttendance.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Attendance Limit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Day";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Time";
            // 
            // mnuViewStudentDetails
            // 
            this.mnuViewStudentDetails.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.btnBack,
            this.btnRefresh});
            this.mnuViewStudentDetails.Location = new System.Drawing.Point(0, 0);
            this.mnuViewStudentDetails.Name = "mnuViewStudentDetails";
            this.mnuViewStudentDetails.Size = new System.Drawing.Size(430, 24);
            this.mnuViewStudentDetails.TabIndex = 32;
            this.mnuViewStudentDetails.Text = "menuStrip1";
            // 
            // btnExit
            // 
            this.btnExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(37, 20);
            this.btnExit.Text = "Exit";
            // 
            // btnBack
            // 
            this.btnBack.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(44, 20);
            this.btnBack.Text = "Back";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(58, 20);
            this.btnRefresh.Text = "Refresh";
            // 
            // btnUpdateClass
            // 
            this.btnUpdateClass.Location = new System.Drawing.Point(233, 377);
            this.btnUpdateClass.Name = "btnUpdateClass";
            this.btnUpdateClass.Size = new System.Drawing.Size(98, 33);
            this.btnUpdateClass.TabIndex = 44;
            this.btnUpdateClass.Text = "Update Class";
            this.btnUpdateClass.UseVisualStyleBackColor = true;
            this.btnUpdateClass.Click += new System.EventHandler(this.btnUpdateClass_Click);
            // 
            // cboTime
            // 
            this.cboTime.FormattingEnabled = true;
            this.cboTime.Location = new System.Drawing.Point(188, 86);
            this.cboTime.Name = "cboTime";
            this.cboTime.Size = new System.Drawing.Size(200, 21);
            this.cboTime.TabIndex = 45;
            // 
            // cboDays
            // 
            this.cboDays.FormattingEnabled = true;
            this.cboDays.Location = new System.Drawing.Point(188, 145);
            this.cboDays.Name = "cboDays";
            this.cboDays.Size = new System.Drawing.Size(200, 21);
            this.cboDays.TabIndex = 46;
            // 
            // frmUpdateClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 450);
            this.Controls.Add(this.cboDays);
            this.Controls.Add(this.cboTime);
            this.Controls.Add(this.btnUpdateClass);
            this.Controls.Add(this.btnRemoveClass);
            this.Controls.Add(this.cboTutors);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboRooms);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAttendance);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mnuViewStudentDetails);
            this.Name = "frmUpdateClass";
            this.Text = "frmUpdateClass";
            this.Load += new System.EventHandler(this.frmUpdateClass_Load);
            this.mnuViewStudentDetails.ResumeLayout(false);
            this.mnuViewStudentDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRemoveClass;
        private System.Windows.Forms.ComboBox cboTutors;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboRooms;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAttendance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip mnuViewStudentDetails;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
        private System.Windows.Forms.ToolStripMenuItem btnBack;
        private System.Windows.Forms.ToolStripMenuItem btnRefresh;
        private System.Windows.Forms.Button btnUpdateClass;
        private System.Windows.Forms.ComboBox cboTime;
        private System.Windows.Forms.ComboBox cboDays;
    }
}