using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrindsBookingSystem
{
    internal class loadComboBoxes
    {

        public static void IDFirstnameSurname(List<ComboBox> c, String location)
        {
            foreach(ComboBox cb in c)
            {
                cb.Items.Clear();
            }

            String sql = "SELECT " + location + "ID, FirstName, Surname FROM " + location + "s";

            DataSet ds = Database.ExecuteMultiRowQuery(sql);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                c[0].Items.Add(ds.Tables[0].Rows[i][0].ToString());
                c[1].Items.Add(ds.Tables[0].Rows[i][1]);
                c[2].Items.Add(ds.Tables[0].Rows[i][2]);
            }

        }

        public static void RateCodes(ComboBox c)
        {
            c.Items.Clear();

            String sql = "SELECT RateCode, Description FROM TutorRates ORDER BY RateCode";

            DataSet ds = Database.ExecuteMultiRowQuery(sql);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                c.Items.Add(ds.Tables[0].Rows[i][0] + " - " + ds.Tables[0].Rows[i][1]);
            }
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
        }

        public static List<ComboBox> CreateComboList(ComboBox c1, ComboBox c2, ComboBox c3) { 
            List<ComboBox> list = new List<ComboBox>();
            list.Add(c1);
            list.Add(c2);
            list.Add(c3);
            return list;
        }

        public static void ApplyFilters(String value, String column, String location, List<ComboBox> c, ComboBox send)
        {
            String sql = "SELECT " + location + "ID, FirstName, Surname FROM " + location + "s WHERE " + column + " = " + value;

            DataSet ds = Database.ExecuteMultiRowQuery(sql);

            foreach (var cb in c)
            {
                cb.Items.Clear();
            }

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                c[0].Items.Add(ds.Tables[0].Rows[i][location + "ID"].ToString());
                c[1].Items.Add(ds.Tables[0].Rows[i]["FirstName"].ToString());
                c[2].Items.Add(ds.Tables[0].Rows[i]["Surname"].ToString());
            }


            if (c[0].Items.Count > 1)
            {
                foreach (var cb in c)
                {
                    cb.SelectedIndex = -1;
                }
            }
            else
            {
                foreach (var cb in c)
                {
                    if (cb.Items.Count == 1)
                    {
                        cb.SelectedIndex = 0;
                    }
                    else
                    {
                        cb.SelectedIndex = -1;
                    }
                }
            }
        }

    }
}