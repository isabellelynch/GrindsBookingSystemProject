using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GrindsBookingSystem
{
    internal class ScheduleGridView
    {
        public static void Format(DataGridView dgv)
        {
            if (dgv.Disposing) { return; }

            dgv.Columns.Clear();
            dgv.Rows.Clear();


            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkCyan;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

            dgv.Columns.Add("Time", "Time");
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            foreach (var day in days)
            {
                dgv.Columns.Add(day, day);
            }

            for (int i = 1; i <= 5; i++)
            {
                dgv.Columns[i].Width = 120;
            }

            dgv.Columns[0].Width = 80;

            for (int hour = 9; hour <= 17; hour++)
            {
                int rowIndex = dgv.Rows.Add();
                dgv.Rows[rowIndex].Cells[0].Value = $"{hour:00}:00";
            }

            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv.GridColor = Color.Gray;
            dgv.ScrollBars = ScrollBars.None;
        }

        public static void Fill(DataGridView dgv, string rooms)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex != 0 && !row.IsNewRow)
                    {
                        cell.Value = "";
                    }
                }
            }

            List<Class> classList = Class.ClassList(rooms, Class.GetCurrentSemester());

            foreach (Class c in classList)
            {
                int rowIndex = c.Time - 9;

                if (rowIndex < 0 || rowIndex >= dgv.Rows.Count) continue;

                int colIndex = ((int)c.Day + 6) % 7 + 1;

                Tutor t = Tutor.GetTutor(Convert.ToInt32(c.TutorID));

                string sql = "SELECT Description FROM Subjects WHERE SubjectID = '" + c.SubjectID + "'";
                OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);
                dr.Read();
                string sub = dr.GetString(0);
                dr.Close();

                dgv.Rows[rowIndex].Cells[colIndex].Value = sub + " - " + t.FirstName + " " + t.Surname;
            }

        }
    }
}
