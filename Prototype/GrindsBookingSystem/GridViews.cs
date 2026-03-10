using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace GrindsBookingSystem
{
    internal class GridViews
    {
        public static void Schedule(DataGridView dgv, int cols)
        {
            ClearGridViewValues(dgv);
            ResetGridView(dgv);

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.MultiSelect = false;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkCyan;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv.GridColor = Color.Gray;
            dgv.ScrollBars = ScrollBars.None;

            dgv.Columns.Add("Time", "Time");

            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };

            foreach (var day in days)
            {
                dgv.Columns.Add(day, day);
            }

            for (int hour = 9; hour <= 17; hour++)
            {
                int rowIndex = dgv.Rows.Add();
                dgv.Rows[rowIndex].Cells[0].Value = $"{hour:00}:00";
            }

            dgv.Columns[0].DefaultCellStyle.Format = "0000";
            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[0].FillWeight = 1;

            for (int i = 1; i < cols; i++)
            {
                dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv.Columns[i].FillWeight = 2;
            }
        }

        public static void Default(DataGridView dgv, int cols)
        {
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;

            dgv.Columns[0].DefaultCellStyle.Format = "0000";
            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[0].FillWeight = 1;

            for (int i = 1; i < cols; i++)
            {
                dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv.Columns[i].FillWeight = 2;
            }
        }

        public static void ClearGridViewValues(DataGridView dgv)
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
        }

        public static void ResetGridView(DataGridView dgv)
        {
            dgv.Columns.Clear();
            dgv.Rows.Clear();
        }

        public static void FillSchedule(DataGridView dgv, string rooms)
        {
            ClearGridViewValues(dgv);

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
