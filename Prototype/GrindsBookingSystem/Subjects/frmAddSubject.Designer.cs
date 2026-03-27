namespace GrindsBookingSystem
{
    partial class frmAddSubject
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
            this.grpCertificate = new System.Windows.Forms.GroupBox();
            this.radioLeaving = new System.Windows.Forms.RadioButton();
            this.radioJunior = new System.Windows.Forms.RadioButton();
            this.grpLevel = new System.Windows.Forms.GroupBox();
            this.radioOrdinary = new System.Windows.Forms.RadioButton();
            this.radioHigher = new System.Windows.Forms.RadioButton();
            this.txtSubjectName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddSubject = new System.Windows.Forms.Button();
            this.grpCertificate.SuspendLayout();
            this.grpLevel.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCertificate
            // 
            this.grpCertificate.Controls.Add(this.radioLeaving);
            this.grpCertificate.Controls.Add(this.radioJunior);
            this.grpCertificate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grpCertificate.Location = new System.Drawing.Point(84, 151);
            this.grpCertificate.Name = "grpCertificate";
            this.grpCertificate.Size = new System.Drawing.Size(323, 61);
            this.grpCertificate.TabIndex = 38;
            this.grpCertificate.TabStop = false;
            this.grpCertificate.Text = "Certificate ";
            // 
            // radioLeaving
            // 
            this.radioLeaving.AutoSize = true;
            this.radioLeaving.Location = new System.Drawing.Point(159, 25);
            this.radioLeaving.Name = "radioLeaving";
            this.radioLeaving.Size = new System.Drawing.Size(143, 21);
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
            this.radioJunior.Size = new System.Drawing.Size(132, 21);
            this.radioJunior.TabIndex = 30;
            this.radioJunior.TabStop = true;
            this.radioJunior.Text = "Junior Certificate";
            this.radioJunior.UseVisualStyleBackColor = true;
            // 
            // grpLevel
            // 
            this.grpLevel.Controls.Add(this.radioOrdinary);
            this.grpLevel.Controls.Add(this.radioHigher);
            this.grpLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grpLevel.Location = new System.Drawing.Point(84, 256);
            this.grpLevel.Name = "grpLevel";
            this.grpLevel.Size = new System.Drawing.Size(323, 59);
            this.grpLevel.TabIndex = 37;
            this.grpLevel.TabStop = false;
            this.grpLevel.Text = "Level";
            // 
            // radioOrdinary
            // 
            this.radioOrdinary.AutoSize = true;
            this.radioOrdinary.Location = new System.Drawing.Point(6, 29);
            this.radioOrdinary.Name = "radioOrdinary";
            this.radioOrdinary.Size = new System.Drawing.Size(119, 21);
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
            this.radioHigher.Size = new System.Drawing.Size(106, 21);
            this.radioHigher.TabIndex = 33;
            this.radioHigher.TabStop = true;
            this.radioHigher.Text = "Higher Level";
            this.radioHigher.UseVisualStyleBackColor = true;
            // 
            // txtSubjectName
            // 
            this.txtSubjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtSubjectName.Location = new System.Drawing.Point(150, 93);
            this.txtSubjectName.Name = "txtSubjectName";
            this.txtSubjectName.Size = new System.Drawing.Size(164, 23);
            this.txtSubjectName.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(184, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 39;
            this.label1.Text = "Subject Name";
            // 
            // btnAddSubject
            // 
            this.btnAddSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnAddSubject.Location = new System.Drawing.Point(159, 362);
            this.btnAddSubject.Name = "btnAddSubject";
            this.btnAddSubject.Size = new System.Drawing.Size(130, 23);
            this.btnAddSubject.TabIndex = 41;
            this.btnAddSubject.Text = "Add Subject";
            this.btnAddSubject.UseVisualStyleBackColor = true;
            this.btnAddSubject.Click += new System.EventHandler(this.btnAddSubject_Click);
            // 
            // frmAddSubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 450);
            this.Controls.Add(this.btnAddSubject);
            this.Controls.Add(this.txtSubjectName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpLevel);
            this.Controls.Add(this.grpCertificate);
            this.Name = "frmAddSubject";
            this.Text = "frmAddSubject";
            this.Controls.SetChildIndex(this.grpCertificate, 0);
            this.Controls.SetChildIndex(this.grpLevel, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtSubjectName, 0);
            this.Controls.SetChildIndex(this.btnAddSubject, 0);
            this.grpCertificate.ResumeLayout(false);
            this.grpCertificate.PerformLayout();
            this.grpLevel.ResumeLayout(false);
            this.grpLevel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCertificate;
        private System.Windows.Forms.RadioButton radioLeaving;
        private System.Windows.Forms.RadioButton radioJunior;
        private System.Windows.Forms.GroupBox grpLevel;
        private System.Windows.Forms.RadioButton radioOrdinary;
        private System.Windows.Forms.RadioButton radioHigher;
        private System.Windows.Forms.TextBox txtSubjectName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddSubject;
    }
}