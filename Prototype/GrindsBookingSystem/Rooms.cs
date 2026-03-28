using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrindsBookingSystem
{
    internal class Rooms
    {
        public static int GetRoomCapacity(string roomNo)
        {
            string sql = "SELECT Capacity FROM Rooms WHERE RoomNo = '" + roomNo + "'";

            int capacity = 0;

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);

            if (dr.Read())
            {
                capacity = dr.GetInt32(0);
            }

            dr.Close();

            return capacity;
        }

        public static string GetRoomDetails(string r)
        {
            string sql = "SELECT RoomNo, Description FROM Rooms WHERE RoomNo = '" + r + "'";


            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);

            dr.Read();

            string details = dr.GetString(0) + " - " + dr.GetString(1);

            dr.Close();

            return details;

        }
    }
}
