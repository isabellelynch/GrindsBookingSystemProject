

using Oracle.ManagedDataAccess.Client;

namespace GrindsBookingSystem
{
    internal class Subject:InterfaceCRUD
    {
        public string Code { get; set; }
        public string Category { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public Subject() { }
        public Subject(string code, string category, string level, string description)
        {
            Code = code;
            Category = category;
            Level = level;
            Description = description;
        }

        public void Create() 
        {
            string sql = "INSERT INTO Subjects (SubjectCode, SubjectLevel, SubjectCategory, Description) " +
                "VALUES ('" +
                Code + "','" + 
                Level + "','" +
                Category + "','" +
                Description + "')";

            Database.ExecuteNonQuery(sql);
        }
        public string Read() 
        {
            string sql = "SELECT * FROM Subjects WHERE " +
                "SubjectCode = '" + Code + "' AND " +
                "SubjectLevel = '" + Level + "' AND " +
                "SubjectCategory = '" + Category + "'";

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);

            if (dr.Read())
            {
                string sub = "Subject : " + dr.GetString(4) +
                "\nSubject ID : " + dr.GetString(0) +
                "\nLevel : " + dr.GetString(2) +
                "\nCertificate : " + dr.GetString(3) +
                "\nSubject Code : " + dr.GetString(1);

                return sub;
            }

            return "Subject Not Found";
        }

        public void Update() { }

        public void Delete() { }
    }
}
