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

        public static void IDFirstnameSurname(ComboBox c1, ComboBox c2, ComboBox c3, String location)
        {
            c1.Items.Clear();
            c2.Items.Clear();
            c3.Items.Clear();

            String sql = "SELECT " + location + "ID, FirstName, Surname FROM " + location + "s";

            DataSet ds = Database.ExecuteMultiRowQuery(sql);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                c1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                c2.Items.Add(ds.Tables[0].Rows[i][1]);
                c3.Items.Add(ds.Tables[0].Rows[i][2]);
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
        
    }
}