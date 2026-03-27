using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace GrindsBookingSystem
{
    internal class GridViews
    {
        public static void Default(DataGridView dgv, params string[] headings)
        { 
            ClearGridViewValues(dgv);
            if (headings.Length > 0)
            {
                foreach (var h in headings)
                {
                    dgv.Columns.Add(h, h);
                }
            }
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkCyan;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.GridColor = Color.Gray;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgv.ColumnHeadersDefaultCellStyle.BackColor;
            dgv.RowsDefaultCellStyle.SelectionBackColor = dgv.ColumnHeadersDefaultCellStyle.BackColor;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
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
            if(dgv.Rows.Count > 1)
            {
                dgv.Rows.Clear();
            }
            if(dgv.Columns.Count > 1) 
            { 
                dgv.Columns.Clear();
            }  
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

        public static void MakeBooking(DataGridView dgv)
        {
            ResetGridView(dgv);
            string[] h = {"Subject", "Day", "Time", "Room", "CurrentEnrollment", "Level", "Group"};
            Default(dgv, h);
        }

        public static void Schedule(DataGridView dgv)
        {
            ResetGridView(dgv);
            string[] h = { "Time", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            Default(dgv, h);

            for (int hour = 9; hour <= 17; hour++)
            {
                int rowIndex = dgv.Rows.Add();
                dgv.Rows[rowIndex].Cells[0].Value = $"{hour:00}:00";
            }

            dgv.Columns[0].DefaultCellStyle.Format = "0000";
            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[0].FillWeight = 1;

            for (int i = 1; i < 6; i++)
            {
                dgv.Columns[i].FillWeight = 2;
            }

            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv.ScrollBars = ScrollBars.None;
        }


    }
}
