using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace GrindsBookingSystem
{
    public partial class frmViewSchedule : BaseForm
    {
        public frmViewSchedule()
        {
            InitializeComponent();
        }

       

        private void btnBack_Click(object sender, EventArgs e)
        {
            GoHome();
        }

        private void btnAddGrind_Click(object sender, EventArgs e)
        {
            var form = new frmAddGrind();
            form.Owner = this;
            form.Show();
            this.Hide();
        }

        private void btnRemoveGrind_Click(object sender, EventArgs e)
        {
            var form = new frmRemoveGrind();
            form.Owner = this;
            form.Show();
            this.Hide();
        }


       /* public class ScheduleDateTimeComparer : IComparer
        {
            private bool ascending;

            public ScheduleDateTimeComparer(bool ascending)
            {
                this.ascending = ascending;
            }

            public int Compare(object x, object y)
            {
                ListViewItem item1 = x as ListViewItem;
                ListViewItem item2 = y as ListViewItem;

                DateTime date1 = DateTime.Parse(item1.SubItems[0].Text);
                DateTime date2 = DateTime.Parse(item2.SubItems[0].Text);

                TimeSpan time1 = TimeSpan.Parse(item1.SubItems[1].Text);
                TimeSpan time2 = TimeSpan.Parse(item2.SubItems[1].Text);

                DateTime dt1 = date1.Add(time1);
                DateTime dt2 = date2.Add(time2);

                return ascending ? dt1.CompareTo(dt2) : dt2.CompareTo(dt1);
            }
        }
       */
        private void btnExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void FormatGridView()
        {
            dgvSchedule.Columns.Clear();
            dgvSchedule.Columns.Add("Time", "Time");
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            foreach (var day in days)
            {
                dgvSchedule.Columns.Add(day, day);
            }

            dgvSchedule.Columns[0].Width = 80;

            for (int i = 1; i <= 7; i++)
            {
                dgvSchedule.Columns[i].Width = 120;
            }

            dgvSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvSchedule.EnableHeadersVisualStyles = false;
            dgvSchedule.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgvSchedule.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSchedule.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

            dgvSchedule.Rows.Clear();

            for (int hour = 8; hour <= 17; hour++)
            {
                int rowIndex = dgvSchedule.Rows.Add();
                dgvSchedule.Rows[rowIndex].Cells[0].Value = $"{hour:00}:00";
            }

            List<Class> classList = Class.ClassList(2);

            foreach (Class c in classList)
            {
                int rowIndex = c.Time - 9;
                if (rowIndex < 0 || rowIndex >= dgvSchedule.Rows.Count) continue;

                int colIndex = ((int)c.Day + 6) % 7 + 1;

                dgvSchedule.Rows[rowIndex].Cells[colIndex].Value = c.Subject;
            }

            dgvSchedule.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSchedule.RowHeadersVisible = false;
            dgvSchedule.AllowUserToAddRows = false;
            dgvSchedule.AllowUserToResizeRows = false;
            dgvSchedule.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvSchedule.GridColor = Color.Gray;
        }
    }
}
    
