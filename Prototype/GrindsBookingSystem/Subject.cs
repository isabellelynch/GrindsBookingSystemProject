

using Oracle.ManagedDataAccess.Client;

namespace GrindsBookingSystem
{
    internal class Subject:InterfaceCRUD
    {
        public string Category { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public Subject() { }
        public Subject(string category, string level, string description)
        {
            Category = category;
            Level = level;
            Description = description;
        }

        public void Create() 
        {
            string sql = "INSERT INTO Subjects (SubjectLevel, SubjectCategory, Description) " +
                "VALUES ('" +
                Level + "','" +
                Category + "','" +
                Description + "')";

            Database.ExecuteNonQuery(sql);
        }
        public string Read() 
        {
            string sql = "SELECT * FROM Subjects";

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);

            if (dr.Read())
            {
                string sub = "Subject : " + dr.GetString(4) +
                "\nSubject ID : " + dr.GetString(0) +
                "\nLevel : " + dr.GetString(2) +
                "\nCertificate : " + dr.GetString(3);

                return sub;
            }

            return "No Subjects Found";
        }

        public void Update() { }

        public void Delete() { }
    }
}
