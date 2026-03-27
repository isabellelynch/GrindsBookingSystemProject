namespace GrindsBookingSystem
{
    partial class frmShowBookings
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
            this.btnShowBookings = new System.Windows.Forms.Button();
            this.grpCancelBooking = new System.Windows.Forms.GroupBox();
            this.lvBookings = new System.Windows.Forms.ListView();
            this.cboFirstName = new System.Windows.Forms.ComboBox();
            this.cboSurname = new System.Windows.Forms.ComboBox();
            this.cboStudentID = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpCancelBooking.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnShowBookings
            // 
            this.btnShowBookings.Location = new System.Drawing.Point(334, 139);
            this.btnShowBookings.Name = "btnShowBookings";
            this.btnShowBookings.Size = new System.Drawing.Size(138, 23);
            this.btnShowBookings.TabIndex = 39;
            this.btnShowBookings.Text = "Show Bookings";
            this.btnShowBookings.UseVisualStyleBackColor = true;
            this.btnShowBookings.Click += new System.EventHandler(this.btnShowBookings_Click);
            // 
            // grpCancelBooking
            // 
            this.grpCancelBooking.Controls.Add(this.lvBookings);
            this.grpCancelBooking.Location = new System.Drawing.Point(35, 167);
            this.grpCancelBooking.Name = "grpCancelBooking";
            this.grpCancelBooking.Size = new System.Drawing.Size(730, 235);
            this.grpCancelBooking.TabIndex = 40;
            this.grpCancelBooking.TabStop = false;
            // 
            // lvBookings
            // 
            this.lvBookings.HideSelection = false;
            this.lvBookings.Location = new System.Drawing.Point(84, 25);
            this.lvBookings.Name = "lvBookings";
            this.lvBookings.Size = new System.Drawing.Size(552, 194);
            this.lvBookings.TabIndex = 0;
            this.lvBookings.UseCompatibleStateImageBehavior = false;
            // 
            // cboFirstName
            // 
            this.cboFirstName.FormattingEnabled = true;
            this.cboFirstName.Location = new System.Drawing.Point(343, 80);
            this.cboFirstName.Name = "cboFirstName";
            this.cboFirstName.Size = new System.Drawing.Size(121, 21);
            this.cboFirstName.TabIndex = 38;
            // 
            // cboSurname
            // 
            this.cboSurname.FormattingEnabled = true;
            this.cboSurname.Location = new System.Drawing.Point(343, 112);
            this.cboSurname.Name = "cboSurname";
            this.cboSurname.Size = new System.Drawing.Size(121, 21);
            this.cboSurname.TabIndex = 37;
            // 
            // cboStudentID
            // 
            this.cboStudentID.FormattingEnabled = true;
            this.cboStudentID.Location = new System.Drawing.Point(343, 48);
            this.cboStudentID.Name = "cboStudentID";
            this.cboStudentID.Size = new System.Drawing.Size(121, 21);
            this.cboStudentID.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(230, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Surname";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Student ID";
            // 
            // frmShowBookings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnShowBookings);
            this.Controls.Add(this.grpCancelBooking);
            this.Controls.Add(this.cboFirstName);
            this.Controls.Add(this.cboSurname);
            this.Controls.Add(this.cboStudentID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "frmShowBookings";
            this.Text = "frmShowBookings";
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cboStudentID, 0);
            this.Controls.SetChildIndex(this.cboSurname, 0);
            this.Controls.SetChildIndex(this.cboFirstName, 0);
            this.Controls.SetChildIndex(this.grpCancelBooking, 0);
            this.Controls.SetChildIndex(this.btnShowBookings, 0);
            this.grpCancelBooking.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShowBookings;
        private System.Windows.Forms.GroupBox grpCancelBooking;
        private System.Windows.Forms.ListView lvBookings;
        private System.Windows.Forms.ComboBox cboFirstName;
        private System.Windows.Forms.ComboBox cboSurname;
        private System.Windows.Forms.ComboBox cboStudentID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}