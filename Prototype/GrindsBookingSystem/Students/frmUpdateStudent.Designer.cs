namespace GrindsBookingSystem
{
    partial class frmUpdateStudent
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboStudentID = new System.Windows.Forms.ComboBox();
            this.cboFirstName = new System.Windows.Forms.ComboBox();
            this.cboSurname = new System.Windows.Forms.ComboBox();
            this.grpStudentDetails = new System.Windows.Forms.GroupBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUpdateStudent = new System.Windows.Forms.Button();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFindStudent = new System.Windows.Forms.Button();
            this.grpStudentDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "First Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Last Name";
            // 
            // cboStudentID
            // 
            this.cboStudentID.FormattingEnabled = true;
            this.cboStudentID.Location = new System.Drawing.Point(354, 32);
            this.cboStudentID.Name = "cboStudentID";
            this.cboStudentID.Size = new System.Drawing.Size(121, 21);
            this.cboStudentID.TabIndex = 3;
            // 
            // cboFirstName
            // 
            this.cboFirstName.FormattingEnabled = true;
            this.cboFirstName.Location = new System.Drawing.Point(354, 77);
            this.cboFirstName.Name = "cboFirstName";
            this.cboFirstName.Size = new System.Drawing.Size(121, 21);
            this.cboFirstName.TabIndex = 4;
            // 
            // cboSurname
            // 
            this.cboSurname.FormattingEnabled = true;
            this.cboSurname.Location = new System.Drawing.Point(354, 117);
            this.cboSurname.Name = "cboSurname";
            this.cboSurname.Size = new System.Drawing.Size(121, 21);
            this.cboSurname.TabIndex = 5;
            // 
            // grpStudentDetails
            // 
            this.grpStudentDetails.Controls.Add(this.txtLastName);
            this.grpStudentDetails.Controls.Add(this.txtFirstName);
            this.grpStudentDetails.Controls.Add(this.label7);
            this.grpStudentDetails.Controls.Add(this.label4);
            this.grpStudentDetails.Controls.Add(this.btnUpdateStudent);
            this.grpStudentDetails.Controls.Add(this.txtPhone);
            this.grpStudentDetails.Controls.Add(this.txtEmail);
            this.grpStudentDetails.Controls.Add(this.label6);
            this.grpStudentDetails.Controls.Add(this.label5);
            this.grpStudentDetails.Location = new System.Drawing.Point(181, 210);
            this.grpStudentDetails.Name = "grpStudentDetails";
            this.grpStudentDetails.Size = new System.Drawing.Size(429, 228);
            this.grpStudentDetails.TabIndex = 30;
            this.grpStudentDetails.TabStop = false;
            this.grpStudentDetails.Text = "Extra Details";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(211, 71);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(121, 20);
            this.txtLastName.TabIndex = 34;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(211, 29);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(121, 20);
            this.txtFirstName.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(69, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Last Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "First Name";
            // 
            // btnUpdateStudent
            // 
            this.btnUpdateStudent.Location = new System.Drawing.Point(139, 186);
            this.btnUpdateStudent.Name = "btnUpdateStudent";
            this.btnUpdateStudent.Size = new System.Drawing.Size(143, 23);
            this.btnUpdateStudent.TabIndex = 29;
            this.btnUpdateStudent.Text = "Update Student Details";
            this.btnUpdateStudent.UseVisualStyleBackColor = true;
            this.btnUpdateStudent.Click += new System.EventHandler(this.btnUpdateStudent_Click);
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(211, 147);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(121, 20);
            this.txtPhone.TabIndex = 28;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(211, 106);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(121, 20);
            this.txtEmail.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(69, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Phone Number";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(69, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Email Address";
            // 
            // btnFindStudent
            // 
            this.btnFindStudent.Location = new System.Drawing.Point(345, 169);
            this.btnFindStudent.Name = "btnFindStudent";
            this.btnFindStudent.Size = new System.Drawing.Size(75, 23);
            this.btnFindStudent.TabIndex = 31;
            this.btnFindStudent.Text = "Find Student";
            this.btnFindStudent.UseVisualStyleBackColor = true;
            this.btnFindStudent.Click += new System.EventHandler(this.btnFindStudent_Click);
            // 
            // frmUpdateStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnFindStudent);
            this.Controls.Add(this.grpStudentDetails);
            this.Controls.Add(this.cboSurname);
            this.Controls.Add(this.cboFirstName);
            this.Controls.Add(this.cboStudentID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmUpdateStudent";
            this.Text = "Grinds Booking System - Update Student Details";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cboStudentID, 0);
            this.Controls.SetChildIndex(this.cboFirstName, 0);
            this.Controls.SetChildIndex(this.cboSurname, 0);
            this.Controls.SetChildIndex(this.grpStudentDetails, 0);
            this.Controls.SetChildIndex(this.btnFindStudent, 0);
            this.grpStudentDetails.ResumeLayout(false);
            this.grpStudentDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboStudentID;
        private System.Windows.Forms.ComboBox cboFirstName;
        private System.Windows.Forms.ComboBox cboSurname;
        private System.Windows.Forms.GroupBox grpStudentDetails;
        private System.Windows.Forms.Button btnUpdateStudent;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFindStudent;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
    }
}