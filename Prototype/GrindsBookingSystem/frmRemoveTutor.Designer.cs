namespace GrindsBookingSystem
{
    partial class frmRemoveTutor
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
            this.cboTutorID = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboFirstName = new System.Windows.Forms.ComboBox();
            this.cboSurname = new System.Windows.Forms.ComboBox();
            this.btnRemoveTutor = new System.Windows.Forms.Button();
            this.btnResetFilters = new System.Windows.Forms.Button();
            this.dgvRemoveTutor = new System.Windows.Forms.DataGridView();;
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemoveTutor)).BeginInit();
            this.SuspendLayout();
            // 
    
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Tutor ID";
            // 
            // cboTutorID
            // 
            this.cboTutorID.FormattingEnabled = true;
            this.cboTutorID.Location = new System.Drawing.Point(369, 32);
            this.cboTutorID.Name = "cboTutorID";
            this.cboTutorID.Size = new System.Drawing.Size(121, 21);
            this.cboTutorID.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "First Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Surname";
            // 
            // cboFirstName
            // 
            this.cboFirstName.FormattingEnabled = true;
            this.cboFirstName.Location = new System.Drawing.Point(369, 62);
            this.cboFirstName.Name = "cboFirstName";
            this.cboFirstName.Size = new System.Drawing.Size(121, 21);
            this.cboFirstName.TabIndex = 20;
            // 
            // cboSurname
            // 
            this.cboSurname.FormattingEnabled = true;
            this.cboSurname.Location = new System.Drawing.Point(369, 92);
            this.cboSurname.Name = "cboSurname";
            this.cboSurname.Size = new System.Drawing.Size(121, 21);
            this.cboSurname.TabIndex = 21;
            // 
            // btnRemoveTutor
            // 
            this.btnRemoveTutor.Location = new System.Drawing.Point(417, 384);
            this.btnRemoveTutor.Name = "btnRemoveTutor";
            this.btnRemoveTutor.Size = new System.Drawing.Size(160, 25);
            this.btnRemoveTutor.TabIndex = 23;
            this.btnRemoveTutor.Text = "Remove Selected Tutor";
            this.btnRemoveTutor.UseVisualStyleBackColor = true;
            this.btnRemoveTutor.Click += new System.EventHandler(this.btnRemoveTutor_Click);
            // 
            // btnResetFilters
            // 
            this.btnResetFilters.Location = new System.Drawing.Point(234, 384);
            this.btnResetFilters.Name = "btnResetFilters";
            this.btnResetFilters.Size = new System.Drawing.Size(160, 25);
            this.btnResetFilters.TabIndex = 24;
            this.btnResetFilters.Text = "Reset Filters";
            this.btnResetFilters.UseVisualStyleBackColor = true;
            this.btnResetFilters.Click += new System.EventHandler(this.btnResetFilters_Click);
            // 
            // dgvRemoveTutor
            // 
            this.dgvRemoveTutor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRemoveTutor.Location = new System.Drawing.Point(214, 173);
            this.dgvRemoveTutor.Name = "dgvRemoveTutor";
            this.dgvRemoveTutor.Size = new System.Drawing.Size(390, 150);
            this.dgvRemoveTutor.TabIndex = 25;
            // 
            // frmRemoveTutor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvRemoveTutor);
            this.Controls.Add(this.btnResetFilters);
            this.Controls.Add(this.btnRemoveTutor);
            this.Controls.Add(this.cboSurname);
            this.Controls.Add(this.cboFirstName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboTutorID);
            this.Controls.Add(this.label1);
            this.Name = "frmRemoveTutor";
            this.Text = "Grinds Booking System - Remove Tutor";

            ((System.ComponentModel.ISupportInitialize)(this.dgvRemoveTutor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTutorID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboFirstName;
        private System.Windows.Forms.ComboBox cboSurname;
        private System.Windows.Forms.Button btnRemoveTutor;
        private System.Windows.Forms.Button btnResetFilters;
        private System.Windows.Forms.DataGridView dgvRemoveTutor;
    }
}