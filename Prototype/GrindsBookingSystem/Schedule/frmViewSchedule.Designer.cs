namespace GrindsBookingSystem
{
    partial class frmViewSchedule
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
            this.btnRemoveClass = new System.Windows.Forms.Button();
            this.btnAddClass = new System.Windows.Forms.Button();
            this.dgvSchedule = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();

            this.cboRooms = new System.Windows.Forms.ComboBox();
            this.labelRooms = new System.Windows.Forms.Label();
            this.btnAlterClass = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();

            this.SuspendLayout();
            // 
            // btnRemoveClass
            // 
            this.btnRemoveClass.Location = new System.Drawing.Point(338, 388);
            this.btnRemoveClass.Name = "btnRemoveClass";
            this.btnRemoveClass.Size = new System.Drawing.Size(115, 23);
            this.btnRemoveClass.TabIndex = 21;
            this.btnRemoveClass.Text = "Remove Class";
            this.btnRemoveClass.UseVisualStyleBackColor = true;
            this.btnRemoveClass.Click += new System.EventHandler(this.btnRemoveClass_Click);
            // 
            // btnAddClass
            // 
            this.btnAddClass.Location = new System.Drawing.Point(167, 388);
            this.btnAddClass.Name = "btnAddClass";
            this.btnAddClass.Size = new System.Drawing.Size(110, 23);
            this.btnAddClass.TabIndex = 20;
            this.btnAddClass.Text = "Add Class";
            this.btnAddClass.UseVisualStyleBackColor = true;
            this.btnAddClass.Click += new System.EventHandler(this.btnAddClass_Click);
            // 
            // dgvSchedule
            // 
            this.dgvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedule.Location = new System.Drawing.Point(12, 112);
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.Size = new System.Drawing.Size(765, 242);
            this.dgvSchedule.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(161, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(433, 31);
            this.label1.TabIndex = 16;
            this.label1.Text = "Grinds Booking System - Schedule";
            // 
          
            // 
            // cboRooms
            // 
            this.cboRooms.FormattingEnabled = true;
            this.cboRooms.Location = new System.Drawing.Point(497, 72);
            this.cboRooms.Name = "cboRooms";
            this.cboRooms.Size = new System.Drawing.Size(121, 21);
            this.cboRooms.TabIndex = 22;
            // 
            // labelRooms
            // 
            this.labelRooms.AutoSize = true;
            this.labelRooms.Location = new System.Drawing.Point(164, 75);
            this.labelRooms.Name = "labelRooms";
            this.labelRooms.Size = new System.Drawing.Size(327, 13);
            this.labelRooms.TabIndex = 23;
            this.labelRooms.Text = "Please select the room that you would like to view the schedule for :";
            // 
            // btnAlterClass
            // 
            this.btnAlterClass.Location = new System.Drawing.Point(503, 388);
            this.btnAlterClass.Name = "btnAlterClass";
            this.btnAlterClass.Size = new System.Drawing.Size(115, 23);
            this.btnAlterClass.TabIndex = 24;
            this.btnAlterClass.Text = "Alter Class";
            this.btnAlterClass.UseVisualStyleBackColor = true;
            this.btnAlterClass.Click += new System.EventHandler(this.btnAlterClass_Click);
            // 
            // frmViewSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAlterClass);
            this.Controls.Add(this.labelRooms);
            this.Controls.Add(this.cboRooms);
            this.Controls.Add(this.btnRemoveClass);
            this.Controls.Add(this.btnAddClass);
            this.Controls.Add(this.dgvSchedule);
            this.Controls.Add(this.label1);

            this.Name = "frmViewSchedule";
            this.Text = "Grinds Booking System - Schedule";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSchedule;
        private System.Windows.Forms.Button btnAddClass;
        private System.Windows.Forms.Button btnRemoveClass;
        private System.Windows.Forms.ComboBox cboRooms;
        private System.Windows.Forms.Label labelRooms;
        private System.Windows.Forms.Button btnAlterClass;
    }
}