namespace GrindsBookingSystem
{
    partial class frmAddBooking
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
            this.cboSurname = new System.Windows.Forms.ComboBox();
            this.cboFirstName = new System.Windows.Forms.ComboBox();
            this.cboStudentID = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnMakeBooking = new System.Windows.Forms.Button();
            this.grpMakeBooking = new System.Windows.Forms.GroupBox();
            this.filterLabel = new System.Windows.Forms.Label();
            this.cboSubjects = new System.Windows.Forms.ComboBox();
            this.dgvMakeBooking = new System.Windows.Forms.DataGridView();
            this.grpMakeBooking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMakeBooking)).BeginInit();
            this.SuspendLayout();
            // 
            // cboSurname
            // 
            this.cboSurname.FormattingEnabled = true;
            this.cboSurname.Location = new System.Drawing.Point(419, 93);
            this.cboSurname.Name = "cboSurname";
            this.cboSurname.Size = new System.Drawing.Size(121, 21);
            this.cboSurname.TabIndex = 28;
            // 
            // cboFirstName
            // 
            this.cboFirstName.FormattingEnabled = true;
            this.cboFirstName.Location = new System.Drawing.Point(419, 58);
            this.cboFirstName.Name = "cboFirstName";
            this.cboFirstName.Size = new System.Drawing.Size(121, 21);
            this.cboFirstName.TabIndex = 27;
            // 
            // cboStudentID
            // 
            this.cboStudentID.FormattingEnabled = true;
            this.cboStudentID.Location = new System.Drawing.Point(419, 27);
            this.cboStudentID.Name = "cboStudentID";
            this.cboStudentID.Size = new System.Drawing.Size(121, 21);
            this.cboStudentID.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(309, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Last Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "First Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(309, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Student ID";
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(357, 131);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(130, 23);
            this.btnContinue.TabIndex = 30;
            this.btnContinue.Text = "Continue to Booking";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnMakeBooking
            // 
            this.btnMakeBooking.Location = new System.Drawing.Point(232, 354);
            this.btnMakeBooking.Name = "btnMakeBooking";
            this.btnMakeBooking.Size = new System.Drawing.Size(182, 23);
            this.btnMakeBooking.TabIndex = 32;
            this.btnMakeBooking.Text = "Make Booking";
            this.btnMakeBooking.UseVisualStyleBackColor = true;
            // 
            // grpMakeBooking
            // 
            this.grpMakeBooking.Controls.Add(this.filterLabel);
            this.grpMakeBooking.Controls.Add(this.cboSubjects);
            this.grpMakeBooking.Controls.Add(this.dgvMakeBooking);
            this.grpMakeBooking.Controls.Add(this.btnMakeBooking);
            this.grpMakeBooking.Location = new System.Drawing.Point(100, 165);
            this.grpMakeBooking.Name = "grpMakeBooking";
            this.grpMakeBooking.Size = new System.Drawing.Size(659, 394);
            this.grpMakeBooking.TabIndex = 34;
            this.grpMakeBooking.TabStop = false;
            this.grpMakeBooking.Text = "Select Class to Book";
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.Location = new System.Drawing.Point(209, 16);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(43, 13);
            this.filterLabel.TabIndex = 40;
            this.filterLabel.Text = "Subject";
            // 
            // cboSubjects
            // 
            this.cboSubjects.FormattingEnabled = true;
            this.cboSubjects.Location = new System.Drawing.Point(319, 8);
            this.cboSubjects.Name = "cboSubjects";
            this.cboSubjects.Size = new System.Drawing.Size(121, 21);
            this.cboSubjects.TabIndex = 39;
            // 
            // dgvMakeBooking
            // 
            this.dgvMakeBooking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMakeBooking.Location = new System.Drawing.Point(23, 88);
            this.dgvMakeBooking.Name = "dgvMakeBooking";
            this.dgvMakeBooking.Size = new System.Drawing.Size(606, 260);
            this.dgvMakeBooking.TabIndex = 34;
            // 
            // frmAddBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 584);
            this.Controls.Add(this.grpMakeBooking);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.cboSurname);
            this.Controls.Add(this.cboFirstName);
            this.Controls.Add(this.cboStudentID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmAddBooking";
            this.Text = "frmAddBooking";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cboStudentID, 0);
            this.Controls.SetChildIndex(this.cboFirstName, 0);
            this.Controls.SetChildIndex(this.cboSurname, 0);
            this.Controls.SetChildIndex(this.btnContinue, 0);
            this.Controls.SetChildIndex(this.grpMakeBooking, 0);
            this.grpMakeBooking.ResumeLayout(false);
            this.grpMakeBooking.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMakeBooking)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSurname;
        private System.Windows.Forms.ComboBox cboFirstName;
        private System.Windows.Forms.ComboBox cboStudentID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnMakeBooking;
        private System.Windows.Forms.GroupBox grpMakeBooking;
        private System.Windows.Forms.DataGridView dgvMakeBooking;
        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.ComboBox cboSubjects;
    }
}