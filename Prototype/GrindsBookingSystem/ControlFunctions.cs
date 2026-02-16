using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrindsBookingSystem
{
    internal class ControlFunctions
    {

        public static void FillBoxes(String location, params ComboBox[] cb)
        {
            ClearCombos(cb);

            String sql = "";
            DataSet ds = null;

            if (location == "Tutors")
            {
                sql = "SELECT * FROM Tutors WHERE Status = 'A'";
                ds = Database.ExecuteMultiRowQuery(sql);
            }
            else if (location == "Students")
            {
                sql = "SELECT * FROM Students WHERE Status = 'A'";
                ds = Database.ExecuteMultiRowQuery(sql);
            }
            if (string.IsNullOrEmpty(sql) || ds == null) { return; }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                for (int j = 0; j < cb.Length; j++) 
                { 
                    cb[j].Items.Add(ds.Tables[0].Rows[i][j].ToString());
                }
            }

            DeselectAll(cb);

        }

        public static void FillSingleBox(ComboBox cb, params String[] s)
        {
            foreach(String item in s)
            {
                cb.Items.Add(item);
            }
        }

        public static void FillRatesAndSubjects(ComboBox cb, ComboBox cb1)
        {
            ClearCombos(cb);
            String sql = "SELECT RateCode, Description FROM TutorRates ORDER BY RateCode";
            DataSet ds = Database.ExecuteMultiRowQuery(sql);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cb.Items.Add(ds.Tables[0].Rows[i][0] + " - " + ds.Tables[0].Rows[i][1]);
            }
            
            sql = "SELECT SubjectCode, Description FROM Subjects ORDER BY SubjectCode";
            ds = Database.ExecuteMultiRowQuery(sql);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cb1.Items.Add(ds.Tables[0].Rows[i][0] + " - " + ds.Tables[0].Rows[i][1]);
            }
            DeselectAll(cb, cb1);
        }


        public static void ApplyFilters(String value, String column, String location, params ComboBox[] cb)
        {
            String sql = "";
            DataSet ds = null;

            if(location == "Tutors")
            {
                sql = "SELECT * FROM Tutors WHERE " + column + " = " + value + "AND Status = 'A'";
                ds = Database.ExecuteMultiRowQuery(sql);
            }
            else if(location == "Students")
            {
                sql = "SELECT * FROM Students WHERE " + column + " = " + value + "AND Status = 'A'";
                ds = Database.ExecuteMultiRowQuery(sql);
            }

            if (string.IsNullOrEmpty(sql) || ds == null) { return; }

            ClearCombos(cb);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                for (int j = 0; j < cb.Length; j++)
                {
                    cb[j].Items.Add(ds.Tables[0].Rows[i][j].ToString());
                }
            }

            DeselectAll(cb);

            if (cb[0].Items.Count == 1)
            {
                foreach (var c in cb)
                {
                    c.SelectedIndex = 0;
                }
            }
            else
            {
                foreach (var c in cb)
                {
                    if (c.Items.Count == 1)
                    {
                        c.SelectedIndex = 0;
                    }
                    else
                    {
                        c.SelectedIndex = -1;
                    }
                }
            }
        }

        public static void formatGridView(DataGridView grid)
        {
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;

            grid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grid.Columns[0].DefaultCellStyle.Format = "0000";
            grid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            grid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        public static void DeselectAll(params ComboBox[] cb)
        {
            foreach(ComboBox c in cb)
            {
                c.SelectedIndex = -1;
            }
        }

        public static void ClearCombos(params ComboBox[] cb)
        {
            foreach(ComboBox c in cb)
            {
                c.Items.Clear();
                c.SelectedIndex = -1;
                c.Text = "";
            }
        }

        public static void EnableBoxes(params ComboBox[] cb)
        {
            foreach(ComboBox c in cb)
            {
                c.Enabled = true;
            }
        }

        public static void DisableBoxes(params ComboBox[] cb)
        {
            foreach (ComboBox c in cb)
            {
                c.Enabled = false;
            }
        }

        public static List<ComboBox> CreateComboList(params ComboBox[] cb)
        {
            List<ComboBox> list = new List<ComboBox>();
            foreach(ComboBox c in cb)
            {
                list.Add(c);
            }
            return list;
        }

    }
}