namespace GrindsBookingSystem
{
    partial class frmAdmin
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
        private new void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.grpKPIs = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRevenue = new System.Windows.Forms.TextBox();
            this.txtTotalBookings = new System.Windows.Forms.TextBox();
            this.txtActiveTutors = new System.Windows.Forms.TextBox();
            this.txtActiveStudents = new System.Windows.Forms.TextBox();
            this.grpCharts = new System.Windows.Forms.GroupBox();
            this.cboCharts = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtWorstTutor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLeastBooked = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.grpKPIs.SuspendLayout();
            this.grpCharts.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Total Revenue";
            // 
            // grpKPIs
            // 
            this.grpKPIs.Controls.Add(this.label8);
            this.grpKPIs.Controls.Add(this.txtActiveStudents);
            this.grpKPIs.Controls.Add(this.txtActiveTutors);
            this.grpKPIs.Controls.Add(this.txtTotalBookings);
            this.grpKPIs.Controls.Add(this.txtRevenue);
            this.grpKPIs.Controls.Add(this.label4);
            this.grpKPIs.Controls.Add(this.label3);
            this.grpKPIs.Controls.Add(this.label2);
            this.grpKPIs.Controls.Add(this.label1);
            this.grpKPIs.Location = new System.Drawing.Point(12, 27);
            this.grpKPIs.Name = "grpKPIs";
            this.grpKPIs.Size = new System.Drawing.Size(535, 123);
            this.grpKPIs.TabIndex = 46;
            this.grpKPIs.TabStop = false;
            this.grpKPIs.Text = "Key Performance Indicators";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Active Tutors";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(269, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "Active Students";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "Total Bookings";
            // 
            // txtRevenue
            // 
            this.txtRevenue.Location = new System.Drawing.Point(122, 25);
            this.txtRevenue.Name = "txtRevenue";
            this.txtRevenue.Size = new System.Drawing.Size(100, 20);
            this.txtRevenue.TabIndex = 49;
            // 
            // txtTotalBookings
            // 
            this.txtTotalBookings.Location = new System.Drawing.Point(126, 71);
            this.txtTotalBookings.Name = "txtTotalBookings";
            this.txtTotalBookings.Size = new System.Drawing.Size(100, 20);
            this.txtTotalBookings.TabIndex = 50;
            // 
            // txtActiveTutors
            // 
            this.txtActiveTutors.Location = new System.Drawing.Point(381, 67);
            this.txtActiveTutors.Name = "txtActiveTutors";
            this.txtActiveTutors.Size = new System.Drawing.Size(100, 20);
            this.txtActiveTutors.TabIndex = 51;
            // 
            // txtActiveStudents
            // 
            this.txtActiveStudents.Location = new System.Drawing.Point(381, 25);
            this.txtActiveStudents.Name = "txtActiveStudents";
            this.txtActiveStudents.Size = new System.Drawing.Size(100, 20);
            this.txtActiveStudents.TabIndex = 52;
            // 
            // grpCharts
            // 
            this.grpCharts.Controls.Add(this.label5);
            this.grpCharts.Controls.Add(this.cboCharts);
            this.grpCharts.Location = new System.Drawing.Point(12, 167);
            this.grpCharts.Name = "grpCharts";
            this.grpCharts.Size = new System.Drawing.Size(535, 266);
            this.grpCharts.TabIndex = 47;
            this.grpCharts.TabStop = false;
            this.grpCharts.Text = "Charts";
            // 
            // cboCharts
            // 
            this.cboCharts.FormattingEnabled = true;
            this.cboCharts.Location = new System.Drawing.Point(106, 14);
            this.cboCharts.Name = "cboCharts";
            this.cboCharts.Size = new System.Drawing.Size(121, 21);
            this.cboCharts.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 49;
            this.label5.Text = "Choose chart data";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLeastBooked);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtWorstTutor);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(12, 450);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(535, 117);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Concerns";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 13);
            this.label6.TabIndex = 46;
            this.label6.Text = " Worst Performing Tutor";
            // 
            // txtWorstTutor
            // 
            this.txtWorstTutor.Location = new System.Drawing.Point(156, 22);
            this.txtWorstTutor.Name = "txtWorstTutor";
            this.txtWorstTutor.Size = new System.Drawing.Size(100, 20);
            this.txtWorstTutor.TabIndex = 50;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 51;
            this.label7.Text = "Least Booked Class";
            // 
            // txtLeastBooked
            // 
            this.txtLeastBooked.Location = new System.Drawing.Point(156, 58);
            this.txtLeastBooked.Name = "txtLeastBooked";
            this.txtLeastBooked.Size = new System.Drawing.Size(100, 20);
            this.txtLeastBooked.TabIndex = 52;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(226, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 53;
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 583);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpCharts);
            this.Controls.Add(this.grpKPIs);
            this.Name = "frmAdmin";
            this.Text = "frmAdmin";
            this.Load += new System.EventHandler(this.frmAdmin_Load);
            this.Controls.SetChildIndex(this.grpKPIs, 0);
            this.Controls.SetChildIndex(this.grpCharts, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.grpKPIs.ResumeLayout(false);
            this.grpKPIs.PerformLayout();
            this.grpCharts.ResumeLayout(false);
            this.grpCharts.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpKPIs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtActiveStudents;
        private System.Windows.Forms.TextBox txtActiveTutors;
        private System.Windows.Forms.TextBox txtTotalBookings;
        private System.Windows.Forms.TextBox txtRevenue;
        private System.Windows.Forms.GroupBox grpCharts;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboCharts;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtLeastBooked;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtWorstTutor;
        private System.Windows.Forms.Label label6;
    }
}