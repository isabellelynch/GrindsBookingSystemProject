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
            this.cboRooms = new System.Windows.Forms.ComboBox();
            this.labelRooms = new System.Windows.Forms.Label();
            this.btnAlterClass = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRemoveClass
            // 
            this.btnRemoveClass.Location = new System.Drawing.Point(514, 487);
            this.btnRemoveClass.Name = "btnRemoveClass";
            this.btnRemoveClass.Size = new System.Drawing.Size(115, 23);
            this.btnRemoveClass.TabIndex = 21;
            this.btnRemoveClass.Text = "Remove Class";
            this.btnRemoveClass.UseVisualStyleBackColor = true;
            this.btnRemoveClass.Click += new System.EventHandler(this.btnRemoveClass_Click);
            // 
            // btnAddClass
            // 
            this.btnAddClass.Location = new System.Drawing.Point(282, 487);
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
            this.dgvSchedule.Location = new System.Drawing.Point(71, 78);
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.Size = new System.Drawing.Size(998, 380);
            this.dgvSchedule.TabIndex = 19;
            // 
            // cboRooms
            // 
            this.cboRooms.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cboRooms.FormattingEnabled = true;
            this.cboRooms.Location = new System.Drawing.Point(453, 38);
            this.cboRooms.Name = "cboRooms";
            this.cboRooms.Size = new System.Drawing.Size(408, 28);
            this.cboRooms.TabIndex = 22;
            // 
            // labelRooms
            // 
            this.labelRooms.AutoSize = true;
            this.labelRooms.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelRooms.Location = new System.Drawing.Point(278, 46);
            this.labelRooms.Name = "labelRooms";
            this.labelRooms.Size = new System.Drawing.Size(114, 20);
            this.labelRooms.TabIndex = 23;
            this.labelRooms.Text = "Select a Room";
            // 
            // btnAlterClass
            // 
            this.btnAlterClass.Location = new System.Drawing.Point(746, 487);
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
            this.ClientSize = new System.Drawing.Size(1119, 544);
            this.Controls.Add(this.btnAlterClass);
            this.Controls.Add(this.labelRooms);
            this.Controls.Add(this.cboRooms);
            this.Controls.Add(this.btnRemoveClass);
            this.Controls.Add(this.btnAddClass);
            this.Controls.Add(this.dgvSchedule);
            this.Name = "frmViewSchedule";
            this.Text = "Top Mark Tutors - Schedule";
            this.Controls.SetChildIndex(this.dgvSchedule, 0);
            this.Controls.SetChildIndex(this.btnAddClass, 0);
            this.Controls.SetChildIndex(this.btnRemoveClass, 0);
            this.Controls.SetChildIndex(this.cboRooms, 0);
            this.Controls.SetChildIndex(this.labelRooms, 0);
            this.Controls.SetChildIndex(this.btnAlterClass, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvSchedule;
        private System.Windows.Forms.Button btnAddClass;
        private System.Windows.Forms.Button btnRemoveClass;
        private System.Windows.Forms.ComboBox cboRooms;
        private System.Windows.Forms.Label labelRooms;
        private System.Windows.Forms.Button btnAlterClass;
    }
}