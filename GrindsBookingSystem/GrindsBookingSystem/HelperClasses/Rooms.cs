using Oracle.ManagedDataAccess.Client;

namespace GrindsBookingSystem
{
    internal class Rooms
    {
        public static string GetRoomCapacity(string room)
        {
            string capacity = "";

            string sql = "SELECT Capacity " +
                         "FROM Rooms " +
                         "WHERE RoomNo = :room";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":room", room);

            // Capacity is a number, so GetString() threw an InvalidCastException;
            // using also closes the reader, which was left open before
            using (OracleDataReader dr = Database.ExecuteSingleRowQuery(cmd))
            {
                if (dr.Read())
                {
                    capacity = dr.GetValue(0).ToString();
                }
            }

            return capacity;
        }

        public static string GetRoomDetails(string r)
        {
            string details = "";
            string sql = "SELECT RoomNo, Description " +
                         "FROM Rooms " +
                         "WHERE RoomNo = :room";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":room", r);

            OracleDataReader dr = Database.ExecuteSingleRowQuery(cmd);

            if (dr.Read())
            {
                details = dr.GetValue(0).ToString() + " - " + dr.GetString(1);
            }
            
            dr.Close();

            return details;

        }
    }
}
