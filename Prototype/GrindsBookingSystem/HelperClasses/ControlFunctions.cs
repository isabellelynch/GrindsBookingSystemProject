using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GrindsBookingSystem
{
    internal class ControlFunctions
    {

        public static void FillBoxes(String location, params ComboBox[] cb)
        {
            ClearCombos(cb);

            DataSet ds = null;

            if (location == "Tutors")
            {
                ds = Tutor.RetrieveAll();
            }
            else if (location == "Students")
            {
                ds = Student.RetrieveAll();
            }
            if (ds == null) { return; }

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                for (int j = 0; j < cb.Length; j++) 
                { 
                    cb[j].Items.Add(ds.Tables[0].Rows[i][j].ToString());
                }
            }

            DeselectAll(cb);

        }

        public static void FillRooms(ComboBox c)
        {
            c.Items.Clear();

            string sql = "SELECT RoomNo, Description FROM Rooms";

            DataSet ds = Database.ExecuteMultiRowQuery(sql);

            foreach (DataRow r in ds.Tables[0].Rows)
            {
                c.Items.Add(r[0].ToString() + " - " + r[1].ToString());
            }

            c.SelectedIndex = -1;
        }

        public static void FillRates(ComboBox cb)
        {
            ClearCombos(cb);

            String sql = "SELECT RateCode, Description FROM TutorRates ORDER BY RateCode";

            DataSet ds = Database.ExecuteMultiRowQuery(sql);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cb.Items.Add(ds.Tables[0].Rows[i][0] + " - " + ds.Tables[0].Rows[i][1]);
            }
            
            DeselectAll(cb);
        }

        public static void ApplyFilters(String value, String column, String location, params ComboBox[] cb)
        {
            String sql = "";
            DataSet ds = null;

            if(location == "Tutors")
            {
                sql = "SELECT * FROM Tutors WHERE " + column + " = " + value + " AND Status = 'A'";
                ds = Database.ExecuteMultiRowQuery(sql);
            }
            else if(location == "Students")
            {
                sql = "SELECT * FROM Students WHERE " + column + " = " + value + " AND Status = 'A'";
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

        public static void Filters(string location, ComboBox send, ComboBox cbo1, ComboBox cbo2, ComboBox cbo3)
        {
            if (send == cbo1)
            {
                ApplyFilters("'" + cbo1.Text + "'", location + "ID", location + "s", cbo1, cbo2, cbo3);
            }
            else if (send == cbo2)
            {
                ApplyFilters("'" + cbo2.Text + "'", "FirstName", location + "s", cbo1, cbo2, cbo3);
            }
            else if (send == cbo3)
            {
                ApplyFilters("'" + cbo3.Text + "'", "Surname", location + "s", cbo1, cbo2, cbo3);
            }
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

        public static void DisableBoxes(params Control[] cb)
        {
            foreach (Control c in cb)
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
        public static void ReadOnly(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                if (c is TextBox t)
                {
                    t.ReadOnly = true;
                }
                if (c.HasChildren)
                {
                    Control.ControlCollection cons = c.Controls;
                    ReadOnly(cons);
                }
            }
        }
    }
}