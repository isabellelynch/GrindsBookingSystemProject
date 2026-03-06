namespace GrindsBookingSystem
{
    partial class frmUpdateTutor
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
            this.cboTutorID = new System.Windows.Forms.ComboBox();
            this.cboNames = new System.Windows.Forms.ComboBox();
            this.cboSurnames = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboRates = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.grpTutorDetails = new System.Windows.Forms.GroupBox();
            this.btnUpdateTutor = new System.Windows.Forms.Button();
            this.btnFindTutor = new System.Windows.Forms.Button();
            this.grpTutorDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Tutor ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "First Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Last Name";
            // 
            // cboTutorID
            // 
            this.cboTutorID.FormattingEnabled = true;
            this.cboTutorID.Location = new System.Drawing.Point(392, 32);
            this.cboTutorID.Name = "cboTutorID";
            this.cboTutorID.Size = new System.Drawing.Size(121, 21);
            this.cboTutorID.TabIndex = 20;
            // 
            // cboNames
            // 
            this.cboNames.FormattingEnabled = true;
            this.cboNames.Location = new System.Drawing.Point(392, 77);
            this.cboNames.Name = "cboNames";
            this.cboNames.Size = new System.Drawing.Size(121, 21);
            this.cboNames.TabIndex = 21;
            // 
            // cboSurnames
            // 
            this.cboSurnames.FormattingEnabled = true;
            this.cboSurnames.Location = new System.Drawing.Point(392, 117);
            this.cboSurnames.Name = "cboSurnames";
            this.cboSurnames.Size = new System.Drawing.Size(121, 21);
            this.cboSurnames.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Tutor Rate Code";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(69, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Email Address";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(69, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Phone Number";
            // 
            // cboRates
            // 
            this.cboRates.FormattingEnabled = true;
            this.cboRates.Location = new System.Drawing.Point(211, 33);
            this.cboRates.Name = "cboRates";
            this.cboRates.Size = new System.Drawing.Size(121, 21);
            this.cboRates.TabIndex = 26;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(211, 85);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(121, 20);
            this.txtEmail.TabIndex = 27;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(211, 128);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(121, 20);
            this.txtPhone.TabIndex = 28;
            // 
            // grpTutorDetails
            // 
            this.grpTutorDetails.Controls.Add(this.btnUpdateTutor);
            this.grpTutorDetails.Controls.Add(this.txtPhone);
            this.grpTutorDetails.Controls.Add(this.txtEmail);
            this.grpTutorDetails.Controls.Add(this.cboRates);
            this.grpTutorDetails.Controls.Add(this.label6);
            this.grpTutorDetails.Controls.Add(this.label5);
            this.grpTutorDetails.Controls.Add(this.label4);
            this.grpTutorDetails.Location = new System.Drawing.Point(181, 201);
            this.grpTutorDetails.Name = "grpTutorDetails";
            this.grpTutorDetails.Size = new System.Drawing.Size(429, 212);
            this.grpTutorDetails.TabIndex = 29;
            this.grpTutorDetails.TabStop = false;
            this.grpTutorDetails.Text = "Extra Details";
            // 
            // btnUpdateTutor
            // 
            this.btnUpdateTutor.Location = new System.Drawing.Point(125, 169);
            this.btnUpdateTutor.Name = "btnUpdateTutor";
            this.btnUpdateTutor.Size = new System.Drawing.Size(143, 23);
            this.btnUpdateTutor.TabIndex = 29;
            this.btnUpdateTutor.Text = "Update Tutor Details";
            this.btnUpdateTutor.UseVisualStyleBackColor = true;
            this.btnUpdateTutor.Click += new System.EventHandler(this.btnUpdateTutor_Click);
            // 
            // btnFindTutor
            // 
            this.btnFindTutor.Location = new System.Drawing.Point(334, 172);
            this.btnFindTutor.Name = "btnFindTutor";
            this.btnFindTutor.Size = new System.Drawing.Size(75, 23);
            this.btnFindTutor.TabIndex = 30;
            this.btnFindTutor.Text = "Find Tutor";
            this.btnFindTutor.UseVisualStyleBackColor = true;
            this.btnFindTutor.Click += new System.EventHandler(this.btnFindTutor_Click);
            // 
            // frmUpdateTutor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnFindTutor);
            this.Controls.Add(this.grpTutorDetails);
            this.Controls.Add(this.cboSurnames);
            this.Controls.Add(this.cboNames);
            this.Controls.Add(this.cboTutorID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmUpdateTutor";
            this.Text = "Grinds Booking System - Update Tutor Details";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cboTutorID, 0);
            this.Controls.SetChildIndex(this.cboNames, 0);
            this.Controls.SetChildIndex(this.cboSurnames, 0);
            this.Controls.SetChildIndex(this.grpTutorDetails, 0);
            this.Controls.SetChildIndex(this.btnFindTutor, 0);
            this.grpTutorDetails.ResumeLayout(false);
            this.grpTutorDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboTutorID;
        private System.Windows.Forms.ComboBox cboNames;
        private System.Windows.Forms.ComboBox cboSurnames;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboRates;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.GroupBox grpTutorDetails;
        private System.Windows.Forms.Button btnUpdateTutor;
        private System.Windows.Forms.Button btnFindTutor;
    }
}