namespace GrindsBookingSystem
{
    partial class frmTutorReport
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartTutorEarnings = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartTutorEarnings)).BeginInit();
            this.SuspendLayout();
            // 
            // chartTutorEarnings
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTutorEarnings.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTutorEarnings.Legends.Add(legend1);
            this.chartTutorEarnings.Location = new System.Drawing.Point(27, 40);
            this.chartTutorEarnings.Name = "chartTutorEarnings";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartTutorEarnings.Series.Add(series1);
            this.chartTutorEarnings.Size = new System.Drawing.Size(999, 366);
            this.chartTutorEarnings.TabIndex = 45;
            this.chartTutorEarnings.Text = "Tutor Earnings Chart";
            // 
            // frmTutorReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 450);
            this.Controls.Add(this.chartTutorEarnings);
            this.Name = "frmTutorReport";
            this.Text = "frmTutorReport";
            this.Controls.SetChildIndex(this.chartTutorEarnings, 0);
            ((System.ComponentModel.ISupportInitialize)(this.chartTutorEarnings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTutorEarnings;
    }
}