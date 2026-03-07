namespace GrindsBookingSystem
{
    partial class frmRemoveStudent
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
            this.btnResetFilters = new System.Windows.Forms.Button();
            this.btnRemoveStudent = new System.Windows.Forms.Button();
            this.dgvRemoveStudent = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemoveStudent)).BeginInit();
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
            this.label2.Location = new System.Drawing.Point(250, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "First Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Surname";
            // 
            // cboStudentID
            // 
            this.cboStudentID.FormattingEnabled = true;
            this.cboStudentID.Location = new System.Drawing.Point(352, 32);
            this.cboStudentID.Name = "cboStudentID";
            this.cboStudentID.Size = new System.Drawing.Size(121, 21);
            this.cboStudentID.TabIndex = 16;
            // 
            // cboFirstName
            // 
            this.cboFirstName.FormattingEnabled = true;
            this.cboFirstName.Location = new System.Drawing.Point(352, 62);
            this.cboFirstName.Name = "cboFirstName";
            this.cboFirstName.Size = new System.Drawing.Size(121, 21);
            this.cboFirstName.TabIndex = 17;
            // 
            // cboSurname
            // 
            this.cboSurname.FormattingEnabled = true;
            this.cboSurname.Location = new System.Drawing.Point(352, 92);
            this.cboSurname.Name = "cboSurname";
            this.cboSurname.Size = new System.Drawing.Size(121, 21);
            this.cboSurname.TabIndex = 18;
            // 
            // btnResetFilters
            // 
            this.btnResetFilters.Location = new System.Drawing.Point(253, 399);
            this.btnResetFilters.Name = "btnResetFilters";
            this.btnResetFilters.Size = new System.Drawing.Size(160, 25);
            this.btnResetFilters.TabIndex = 25;
            this.btnResetFilters.Text = "Reset Filters";
            this.btnResetFilters.UseVisualStyleBackColor = true;
            // 
            // btnRemoveStudent
            // 
            this.btnRemoveStudent.Location = new System.Drawing.Point(431, 399);
            this.btnRemoveStudent.Name = "btnRemoveStudent";
            this.btnRemoveStudent.Size = new System.Drawing.Size(160, 25);
            this.btnRemoveStudent.TabIndex = 26;
            this.btnRemoveStudent.Text = "Remove Selected Student";
            this.btnRemoveStudent.UseVisualStyleBackColor = true;
            this.btnRemoveStudent.Click += new System.EventHandler(this.btnRemoveStudent_Click);
            // 
            // dgvRemoveStudent
            // 
            this.dgvRemoveStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRemoveStudent.Location = new System.Drawing.Point(122, 147);
            this.dgvRemoveStudent.Name = "dgvRemoveStudent";
            this.dgvRemoveStudent.Size = new System.Drawing.Size(580, 207);
            this.dgvRemoveStudent.TabIndex = 27;
            // 
            // frmRemoveStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvRemoveStudent);
            this.Controls.Add(this.btnRemoveStudent);
            this.Controls.Add(this.btnResetFilters);
            this.Controls.Add(this.cboSurname);
            this.Controls.Add(this.cboFirstName);
            this.Controls.Add(this.cboStudentID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmRemoveStudent";
            this.Text = "Grinds Booking System - Remove Student";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cboStudentID, 0);
            this.Controls.SetChildIndex(this.cboFirstName, 0);
            this.Controls.SetChildIndex(this.cboSurname, 0);
            this.Controls.SetChildIndex(this.btnResetFilters, 0);
            this.Controls.SetChildIndex(this.btnRemoveStudent, 0);
            this.Controls.SetChildIndex(this.dgvRemoveStudent, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemoveStudent)).EndInit();
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
        private System.Windows.Forms.Button btnResetFilters;
        private System.Windows.Forms.Button btnRemoveStudent;
        private System.Windows.Forms.DataGridView dgvRemoveStudent;
    }
}