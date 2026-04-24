namespace GrindsBookingSystem
{
    partial class frmManageBookings
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
        new private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboStudentID = new System.Windows.Forms.ComboBox();
            this.cboSName = new System.Windows.Forms.ComboBox();
            this.cboName = new System.Windows.Forms.ComboBox();
            this.btnCancelBooking = new System.Windows.Forms.Button();
            this.grpCancelBooking = new System.Windows.Forms.GroupBox();
            this.dgvCancelBooking = new System.Windows.Forms.DataGridView();
            this.btnShowBookings = new System.Windows.Forms.Button();
            this.grpCancelBooking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCancelBooking)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Student ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(104, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "First Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(104, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Surname";
            // 
            // cboStudentID
            // 
            this.cboStudentID.FormattingEnabled = true;
            this.cboStudentID.Location = new System.Drawing.Point(217, 46);
            this.cboStudentID.Name = "cboStudentID";
            this.cboStudentID.Size = new System.Drawing.Size(121, 21);
            this.cboStudentID.TabIndex = 7;
            // 
            // cboSName
            // 
            this.cboSName.FormattingEnabled = true;
            this.cboSName.Location = new System.Drawing.Point(217, 110);
            this.cboSName.Name = "cboSName";
            this.cboSName.Size = new System.Drawing.Size(121, 21);
            this.cboSName.TabIndex = 8;
            // 
            // cboName
            // 
            this.cboName.FormattingEnabled = true;
            this.cboName.Location = new System.Drawing.Point(217, 78);
            this.cboName.Name = "cboName";
            this.cboName.Size = new System.Drawing.Size(121, 21);
            this.cboName.TabIndex = 9;
            // 
            // btnCancelBooking
            // 
            this.btnCancelBooking.Location = new System.Drawing.Point(199, 206);
            this.btnCancelBooking.Name = "btnCancelBooking";
            this.btnCancelBooking.Size = new System.Drawing.Size(138, 23);
            this.btnCancelBooking.TabIndex = 31;
            this.btnCancelBooking.Text = "Cancel Booking";
            this.btnCancelBooking.UseVisualStyleBackColor = true;
            this.btnCancelBooking.Click += new System.EventHandler(this.btnCancelBooking_Click);
            // 
            // grpCancelBooking
            // 
            this.grpCancelBooking.Controls.Add(this.dgvCancelBooking);
            this.grpCancelBooking.Controls.Add(this.btnCancelBooking);
            this.grpCancelBooking.Location = new System.Drawing.Point(9, 165);
            this.grpCancelBooking.Name = "grpCancelBooking";
            this.grpCancelBooking.Size = new System.Drawing.Size(501, 235);
            this.grpCancelBooking.TabIndex = 32;
            this.grpCancelBooking.TabStop = false;
            // 
            // dgvCancelBooking
            // 
            this.dgvCancelBooking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCancelBooking.Location = new System.Drawing.Point(6, 19);
            this.dgvCancelBooking.Name = "dgvCancelBooking";
            this.dgvCancelBooking.Size = new System.Drawing.Size(488, 181);
            this.dgvCancelBooking.TabIndex = 32;
            // 
            // btnShowBookings
            // 
            this.btnShowBookings.Location = new System.Drawing.Point(208, 137);
            this.btnShowBookings.Name = "btnShowBookings";
            this.btnShowBookings.Size = new System.Drawing.Size(138, 23);
            this.btnShowBookings.TabIndex = 32;
            this.btnShowBookings.Text = "Show Bookings";
            this.btnShowBookings.UseVisualStyleBackColor = true;
            this.btnShowBookings.Click += new System.EventHandler(this.btnShowBookings_Click);
            // 
            // frmManageBookings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 450);
            this.Controls.Add(this.btnShowBookings);
            this.Controls.Add(this.grpCancelBooking);
            this.Controls.Add(this.cboName);
            this.Controls.Add(this.cboSName);
            this.Controls.Add(this.cboStudentID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "frmManageBookings";
            this.Text = "Top Mark Tutors - Manage Bookings";
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cboStudentID, 0);
            this.Controls.SetChildIndex(this.cboSName, 0);
            this.Controls.SetChildIndex(this.cboName, 0);
            this.Controls.SetChildIndex(this.grpCancelBooking, 0);
            this.Controls.SetChildIndex(this.btnShowBookings, 0);
            this.grpCancelBooking.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCancelBooking)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboStudentID;
        private System.Windows.Forms.ComboBox cboSName;
        private System.Windows.Forms.ComboBox cboName;
        private System.Windows.Forms.Button btnCancelBooking;
        private System.Windows.Forms.GroupBox grpCancelBooking;
        private System.Windows.Forms.Button btnShowBookings;
        private System.Windows.Forms.DataGridView dgvCancelBooking;
    }
}