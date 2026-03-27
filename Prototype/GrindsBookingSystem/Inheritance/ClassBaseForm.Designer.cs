namespace GrindsBookingSystem
{
    partial class ClassBaseForm
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
            this.cboDays = new System.Windows.Forms.ComboBox();
            this.cboTime = new System.Windows.Forms.ComboBox();
            this.btnClass = new System.Windows.Forms.Button();
            this.cboTutors = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboRooms = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAttendance = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboSubjects = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cboDays
            // 
            this.cboDays.FormattingEnabled = true;
            this.cboDays.Location = new System.Drawing.Point(189, 124);
            this.cboDays.Name = "cboDays";
            this.cboDays.Size = new System.Drawing.Size(200, 21);
            this.cboDays.TabIndex = 59;
            // 
            // cboTime
            // 
            this.cboTime.FormattingEnabled = true;
            this.cboTime.Location = new System.Drawing.Point(189, 65);
            this.cboTime.Name = "cboTime";
            this.cboTime.Size = new System.Drawing.Size(200, 21);
            this.cboTime.TabIndex = 58;
            // 
            // btnClass
            // 
            this.btnClass.Location = new System.Drawing.Point(157, 363);
            this.btnClass.Name = "btnClass";
            this.btnClass.Size = new System.Drawing.Size(98, 33);
            this.btnClass.TabIndex = 57;
            this.btnClass.UseVisualStyleBackColor = true;
            // 
            // cboTutors
            // 
            this.cboTutors.FormattingEnabled = true;
            this.cboTutors.Location = new System.Drawing.Point(189, 279);
            this.cboTutors.Name = "cboTutors";
            this.cboTutors.Size = new System.Drawing.Size(200, 21);
            this.cboTutors.TabIndex = 55;
            this.cboTutors.SelectedIndexChanged += new System.EventHandler(this.cboTutors_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 287);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "Tutor";
            // 
            // cboRooms
            // 
            this.cboRooms.FormattingEnabled = true;
            this.cboRooms.Location = new System.Drawing.Point(189, 240);
            this.cboRooms.Name = "cboRooms";
            this.cboRooms.Size = new System.Drawing.Size(200, 21);
            this.cboRooms.TabIndex = 53;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 52;
            this.label4.Text = "Room";
            // 
            // txtAttendance
            // 
            this.txtAttendance.Location = new System.Drawing.Point(189, 185);
            this.txtAttendance.Name = "txtAttendance";
            this.txtAttendance.Size = new System.Drawing.Size(200, 20);
            this.txtAttendance.TabIndex = 51;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "Attendance Limit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Day";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Time";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 322);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 60;
            this.label6.Text = "Tutor Subjects";
            // 
            // cboSubjects
            // 
            this.cboSubjects.FormattingEnabled = true;
            this.cboSubjects.Location = new System.Drawing.Point(189, 314);
            this.cboSubjects.Name = "cboSubjects";
            this.cboSubjects.Size = new System.Drawing.Size(200, 21);
            this.cboSubjects.TabIndex = 61;
            // 
            // ClassBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 450);
            this.Controls.Add(this.cboSubjects);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboDays);
            this.Controls.Add(this.cboTime);
            this.Controls.Add(this.btnClass);
            this.Controls.Add(this.cboTutors);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboRooms);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAttendance);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ClassBaseForm";
            this.Text = "ClassBaseForm";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtAttendance, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cboRooms, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.cboTutors, 0);
            this.Controls.SetChildIndex(this.btnClass, 0);
            this.Controls.SetChildIndex(this.cboTime, 0);
            this.Controls.SetChildIndex(this.cboDays, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.cboSubjects, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.ComboBox cboDays;
        protected System.Windows.Forms.ComboBox cboTime;
        protected System.Windows.Forms.Button btnClass;
        protected System.Windows.Forms.ComboBox cboTutors;
        protected System.Windows.Forms.ComboBox cboRooms;
        protected System.Windows.Forms.TextBox txtAttendance;
        private System.Windows.Forms.Label label6;
        protected System.Windows.Forms.ComboBox cboSubjects;
    }
}