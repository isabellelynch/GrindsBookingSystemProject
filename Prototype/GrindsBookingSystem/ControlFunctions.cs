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
                sql = "SELECT * FROM People p JOIN Tutors t ON p.PersonID = t.TutorID WHERE t.TutorID = p.PersonID";
                ds = Database.ExecuteMultiRowQuery(sql);
            }
            else if (location == "Students")
            {
                sql = "SELECT * FROM People p JOIN Students s ON p.PersonID = s.StudentID WHERE s.StudentID = p.PersonID";
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
            DeselectAll(cb);
        }

        /*public static void RateCodes(ComboBox c)
        {
            c.Items.Clear();

            String sql = "SELECT RateCode, Description FROM TutorRates ORDER BY RateCode";

            DataSet ds = Database.ExecuteMultiRowQuery(sql);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                c.Items.Add(ds.Tables[0].Rows[i][0] + " - " + ds.Tables[0].Rows[i][1]);
            }
            c.SelectedIndex = -1;
        }

        public static void Subjects(ComboBox c)
        {
            c.Items.Clear();

            String sql = "SELECT SubjectCode, Description FROM Subjects ORDER BY SubjectCode";
            DataSet ds = Database.ExecuteMultiRowQuery(sql);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                c.Items.Add(ds.Tables[0].Rows[i][0] + " - " + ds.Tables[0].Rows[i][1]);
            }
            c.SelectedIndex = -1;
        }*/

        public static void ApplyFilters(String value, String column, String location, params ComboBox[] cb)
        {
            String sql = "";
            DataSet ds = null;

            if(location == "Tutors")
            {
                sql = "SELECT * FROM People p JOIN Tutors t ON p.PersonID = t.TutorID WHERE " + column + " = " + value;
                ds = Database.ExecuteMultiRowQuery(sql);
            }
            else if(location == "Students")
            {
                sql = "SELECT * FROM People p JOIN Students s ON p.PersonID = s.StudentID WHERE " + column + " = " + value;
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

        public static void FilterDGV()
        {

        }

        public static void ClearCombos(params ComboBox[] cb)
        {
            foreach (ComboBox c in cb)
            {
                c.Items.Clear();
                c.Text = "";
            }
        }
        
        public static void ClearTextBoxes(params TextBox[] tb)
        {
            foreach(TextBox t in tb)
            {
                t.Text = "";
            }
        }

        public static void DeselectAll(params ComboBox[] cb)
        {
            foreach(ComboBox c in cb)
            {
                c.SelectedIndex = -1;
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