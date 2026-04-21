using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace GrindsBookingSystem
{
    class Database
    {
        public const string connectionString = "Data Source = studentoracle:1521/orcl; User Id = t00264026; Password = Qfkqedm!uqy9;";

        public static OracleConnection OpenConnection()
        {
            OracleConnection conn = new OracleConnection(Database.connectionString);
            conn.Open();
            return conn;
        }

        public static DataSet ExecuteMultiRowQuery(string query)
        {
            OracleConnection conn = OpenConnection();
            OracleCommand cmd = new OracleCommand(query, conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }


        public static OracleDataReader ExecuteSingleRowQuery(string query)
        {
            OracleConnection conn = OpenConnection();
            OracleCommand cmd = new OracleCommand(query, conn);
            OracleDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        public static void ExecuteNonQuery(string query)
        {
            OracleConnection conn = OpenConnection();
            OracleCommand cmd = new OracleCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void ExecuteNonQueryCommand(OracleCommand cmd)
        {
            using (OracleConnection conn = OpenConnection())
            {
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
