using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;

namespace GrindsBookingSystem
{
    public partial class ClassBaseForm : BaseForm
    {
        
        public ClassBaseForm()
        {
        }


        public void SetClassDay(int day, TextBox t)
        {
            string s = "";

            switch (day)
            {
                case 1:
                    s = "Monday";
                    break;
                case 2:
                    s = "Tuesday";
                    break;
                case 3:
                    s = "Wednesday";
                    break;
                case 4:
                    s = "Thursday";
                    break;
                case 5:
                    s = "Friday";
                    break;
                default:
                    s = "";
                    break;
            }

            t.Text = s;
        }

        public void SetRoom(ComboBox cb, string room)
        {
            cb.Text = room;
        }

        public void SetClassTime(int time, TextBox t)
        {
            int t2 = time + 9;
            t.Text = t.ToString() + ":00";
        }

        public void SetAttendance(TextBox t, string room)
        {
            string sql = "SELECT Capacity FROM Rooms WHERE RoomNo = '" + room + "'";

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);

            if (dr.Read())
            {
                int cap = dr.GetInt32(0);
                t.Text = cap.ToString();
            }

            dr.Close();
        }
    }
}
