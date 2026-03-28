namespace GrindsBookingSystem
{
    partial class frmAssignSubjects
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
            this.cboSurname = new System.Windows.Forms.ComboBox();
            this.cboFirstName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTutorID = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSubjects = new System.Windows.Forms.DataGridView();
            this.grpSubjects = new System.Windows.Forms.GroupBox();
            this.grpCertificate = new System.Windows.Forms.GroupBox();
            this.radioLeaving = new System.Windows.Forms.RadioButton();
            this.radioJunior = new System.Windows.Forms.RadioButton();
            this.grpLevel = new System.Windows.Forms.GroupBox();
            this.radioOrdinary = new System.Windows.Forms.RadioButton();
            this.radioHigher = new System.Windows.Forms.RadioButton();
            this.btnAssignSubject = new System.Windows.Forms.Button();
            this.oracleCommand1 = new Oracle.ManagedDataAccess.Client.OracleCommand();
            this.btnSelectTutor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).BeginInit();
            this.grpSubjects.SuspendLayout();
            this.grpCertificate.SuspendLayout();
            this.grpLevel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboSurname
            // 
            this.cboSurname.FormattingEnabled = true;
            this.cboSurname.Location = new System.Drawing.Point(377, 94);
            this.cboSurname.Name = "cboSurname";
            this.cboSurname.Size = new System.Drawing.Size(121, 21);
            this.cboSurname.TabIndex = 27;
            // 
            // cboFirstName
            // 
            this.cboFirstName.FormattingEnabled = true;
            this.cboFirstName.Location = new System.Drawing.Point(377, 64);
            this.cboFirstName.Name = "cboFirstName";
            this.cboFirstName.Size = new System.Drawing.Size(121, 21);
            this.cboFirstName.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(258, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Surname";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(258, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "First Name";
            // 
            // cboTutorID
            // 
            this.cboTutorID.FormattingEnabled = true;
            this.cboTutorID.Location = new System.Drawing.Point(377, 34);
            this.cboTutorID.Name = "cboTutorID";
            this.cboTutorID.Size = new System.Drawing.Size(121, 21);
            this.cboTutorID.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(258, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Tutor ID";
            // 
            // dgvSubjects
            // 
            this.dgvSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubjects.Location = new System.Drawing.Point(18, 25);
            this.dgvSubjects.Name = "dgvSubjects";
            this.dgvSubjects.Size = new System.Drawing.Size(336, 167);
            this.dgvSubjects.TabIndex = 28;
            // 
            // grpSubjects
            // 
            this.grpSubjects.Controls.Add(this.grpCertificate);
            this.grpSubjects.Controls.Add(this.grpLevel);
            this.grpSubjects.Controls.Add(this.btnAssignSubject);
            this.grpSubjects.Controls.Add(this.dgvSubjects);
            this.grpSubjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.grpSubjects.Location = new System.Drawing.Point(38, 159);
            this.grpSubjects.Name = "grpSubjects";
            this.grpSubjects.Size = new System.Drawing.Size(739, 268);
            this.grpSubjects.TabIndex = 29;
            this.grpSubjects.TabStop = false;
            this.grpSubjects.Text = "Subjects";
            // 
            // grpCertificate
            // 
            this.grpCertificate.Controls.Add(this.radioLeaving);
            this.grpCertificate.Controls.Add(this.radioJunior);
            this.grpCertificate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.grpCertificate.Location = new System.Drawing.Point(410, 19);
            this.grpCertificate.Name = "grpCertificate";
            this.grpCertificate.Size = new System.Drawing.Size(323, 61);
            this.grpCertificate.TabIndex = 37;
            this.grpCertificate.TabStop = false;
            this.grpCertificate.Text = "Certificate ";
            // 
            // radioLeaving
            // 
            this.radioLeaving.AutoSize = true;
            this.radioLeaving.Location = new System.Drawing.Point(159, 25);
            this.radioLeaving.Name = "radioLeaving";
            this.radioLeaving.Size = new System.Drawing.Size(158, 24);
            this.radioLeaving.TabIndex = 31;
            this.radioLeaving.TabStop = true;
            this.radioLeaving.Text = "Leaving Certificate";
            this.radioLeaving.UseVisualStyleBackColor = true;
            // 
            // radioJunior
            // 
            this.radioJunior.AutoSize = true;
            this.radioJunior.Location = new System.Drawing.Point(6, 25);
            this.radioJunior.Name = "radioJunior";
            this.radioJunior.Size = new System.Drawing.Size(146, 24);
            this.radioJunior.TabIndex = 30;
            this.radioJunior.TabStop = true;
            this.radioJunior.Text = "Junior Certificate";
            this.radioJunior.UseVisualStyleBackColor = true;
            // 
            // grpLevel
            // 
            this.grpLevel.Controls.Add(this.radioOrdinary);
            this.grpLevel.Controls.Add(this.radioHigher);
            this.grpLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.grpLevel.Location = new System.Drawing.Point(410, 133);
            this.grpLevel.Name = "grpLevel";
            this.grpLevel.Size = new System.Drawing.Size(323, 59);
            this.grpLevel.TabIndex = 36;
            this.grpLevel.TabStop = false;
            this.grpLevel.Text = "Level";
            // 
            // radioOrdinary
            // 
            this.radioOrdinary.AutoSize = true;
            this.radioOrdinary.Location = new System.Drawing.Point(6, 29);
            this.radioOrdinary.Name = "radioOrdinary";
            this.radioOrdinary.Size = new System.Drawing.Size(127, 24);
            this.radioOrdinary.TabIndex = 32;
            this.radioOrdinary.TabStop = true;
            this.radioOrdinary.Text = "Ordinary Level";
            this.radioOrdinary.UseVisualStyleBackColor = true;
            // 
            // radioHigher
            // 
            this.radioHigher.AutoSize = true;
            this.radioHigher.Location = new System.Drawing.Point(176, 29);
            this.radioHigher.Name = "radioHigher";
            this.radioHigher.Size = new System.Drawing.Size(115, 24);
            this.radioHigher.TabIndex = 33;
            this.radioHigher.TabStop = true;
            this.radioHigher.Text = "Higher Level";
            this.radioHigher.UseVisualStyleBackColor = true;
            // 
            // btnAssignSubject
            // 
            this.btnAssignSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnAssignSubject.Location = new System.Drawing.Point(324, 221);
            this.btnAssignSubject.Name = "btnAssignSubject";
            this.btnAssignSubject.Size = new System.Drawing.Size(114, 30);
            this.btnAssignSubject.TabIndex = 29;
            this.btnAssignSubject.Text = "Submit";
            this.btnAssignSubject.UseVisualStyleBackColor = true;
            this.btnAssignSubject.Click += new System.EventHandler(this.btnAssignSubject_Click);
            // 
            // btnSelectTutor
            // 
            this.btnSelectTutor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnSelectTutor.Location = new System.Drawing.Point(334, 132);
            this.btnSelectTutor.Name = "btnSelectTutor";
            this.btnSelectTutor.Size = new System.Drawing.Size(114, 21);
            this.btnSelectTutor.TabIndex = 38;
            this.btnSelectTutor.Text = "Select Tutor";
            this.btnSelectTutor.UseVisualStyleBackColor = true;
            this.btnSelectTutor.Click += new System.EventHandler(this.btnSelectTutor_Click);
            // 
            // frmAssignSubjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSelectTutor);
            this.Controls.Add(this.grpSubjects);
            this.Controls.Add(this.cboSurname);
            this.Controls.Add(this.cboFirstName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboTutorID);
            this.Controls.Add(this.label1);
            this.Name = "frmAssignSubjects";
            this.Text = "frmAssignSubjects";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cboTutorID, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cboFirstName, 0);
            this.Controls.SetChildIndex(this.cboSurname, 0);
            this.Controls.SetChildIndex(this.grpSubjects, 0);
            this.Controls.SetChildIndex(this.btnSelectTutor, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).EndInit();
            this.grpSubjects.ResumeLayout(false);
            this.grpCertificate.ResumeLayout(false);
            this.grpCertificate.PerformLayout();
            this.grpLevel.ResumeLayout(false);
            this.grpLevel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSurname;
        private System.Windows.Forms.ComboBox cboFirstName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTutorID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSubjects;
        private System.Windows.Forms.GroupBox grpSubjects;
        private System.Windows.Forms.RadioButton radioHigher;
        private System.Windows.Forms.RadioButton radioOrdinary;
        private System.Windows.Forms.RadioButton radioLeaving;
        private System.Windows.Forms.RadioButton radioJunior;
        private System.Windows.Forms.Button btnAssignSubject;
        private System.Windows.Forms.GroupBox grpCertificate;
        private System.Windows.Forms.GroupBox grpLevel;
        private Oracle.ManagedDataAccess.Client.OracleCommand oracleCommand1;
        private System.Windows.Forms.Button btnSelectTutor;
    }
}