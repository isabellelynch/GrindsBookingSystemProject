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

            OracleDataReader dr = Database.ExecuteSingleRowQuery(cmd);

            if (dr != null && dr.Read())
            {
                capacity = dr.GetString(0);
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
                details = dr.GetString(0) + " - " + dr.GetString(1);
            }
            
            dr.Close();

            return details;

        }
    }
}
