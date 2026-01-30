using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
    }
}