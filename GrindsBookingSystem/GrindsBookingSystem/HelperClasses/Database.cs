using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Data;

namespace GrindsBookingSystem
{
    class Database
    {
        // The Oracle login is no longer typed into the code. It is read from the appSettings in
        // App.config, which pulls in secrets.config (a local file that Git ignores).
        // Copy secrets.example.config to secrets.config and fill in your own user id and password.
        public static string connectionString
        {
            get
            {
                string dataSource = ConfigurationManager.AppSettings["OracleDataSource"];
                string userId = ConfigurationManager.AppSettings["OracleUserId"];
                string password = ConfigurationManager.AppSettings["OraclePassword"];

                if (string.IsNullOrWhiteSpace(dataSource))
                {
                    dataSource = "studentoracle:1521/orcl";
                }

                if (string.IsNullOrWhiteSpace(userId))
                {
                    throw new ConfigurationErrorsException(
                        "No Oracle login found. Copy secrets.example.config to secrets.config " +
                        "(in the GrindsBookingSystem project folder), add your Oracle user id and password, then rebuild.");
                }

                return "Data Source = " + dataSource + "; User Id = " + userId + "; Password = " + password + ";";
            }
        }

        public static OracleConnection OpenConnection()
        {
            OracleConnection conn = new OracleConnection(Database.connectionString);
            conn.Open();
            return conn;
        }

        public static DataSet ExecuteMultiRowQuery(OracleCommand cmd)
        {
            using (OracleConnection conn = OpenConnection())
            {
                cmd.Connection = conn;

                using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }
        public static OracleDataReader ExecuteSingleRowQuery(OracleCommand cmd)
        {
            OracleConnection conn = OpenConnection();
            cmd.Connection = conn;

            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public static void ExecuteNonQuery(OracleCommand cmd)
        {
            using (OracleConnection conn = OpenConnection())
            {
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
