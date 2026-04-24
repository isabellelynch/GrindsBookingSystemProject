using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace GrindsBookingSystem
{
    internal class Subject:InterfaceCRUD
    {
        public int SubjectID { get; private set; }
        public string Category { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public Subject() 
        {
            Category = "";
            Level = "";
            Description = "";
        }
        public Subject(string category, string level, string description)
        {
            Category = category;
            Level = level;
            Description = description;
        }

        public void SetID(int id)
        {
            SubjectID = id;
        }

        public void Create() 
        {
            string sql = "INSERT INTO Subjects (SubjectLevel, SubjectCategory, Description) " +
                         "VALUES (:l, :c, :d)";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":l", this.Level);
            cmd.Parameters.Add(":c", this.Category);
            cmd.Parameters.Add(":d", this.Description);

            Database.ExecuteNonQuery(cmd);
        }
        public string Read() 
        {
            Subject s = GetSubject(this.SubjectID.ToString());

            return s.ToString();
        }

        public static Subject GetSubject(string id)
        { 
            Subject s = new Subject();

            string sql = "SELECT * " +
                         "FROM Subjects " +
                         "WHERE SubjectID = :id";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":id", id);

            OracleDataReader dr = Database.ExecuteSingleRowQuery(cmd);

            if (dr.Read())
            {
                s = new Subject(dr.GetString(1), dr.GetString(2), dr.GetString(3));
            }
            dr.Close();
            return s;
        }

        public static string GetSubjectID(string level, string cat, string description)
        {
            string id = "";

            string sql = "SELECT SubjectID " +
                         "FROM Subjects " +
                         "WHERE SubjectCategory = :c " +
                         "AND SubjectLevel = :l " +
                         "AND Description = :d";
            
            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":c", cat);
            cmd.Parameters.Add(":l", level);
            cmd.Parameters.Add(":d", description);

            OracleDataReader dr = Database.ExecuteSingleRowQuery(cmd);

            if(dr.Read())
            {
                id = dr.GetInt32(0).ToString();
            }
            
            dr.Close();
            return id;
        }

        public override string ToString()
        {
            return "Subject : " + this.Description +
                   "\nSubject ID : " + this.SubjectID +
                   "\nLevel : " + this.Level +
                   "\nCertificate : " + this.Category;
        }

        public void Update() 
        {
            string sql = "Update Subjects " +
                         "SET SubjectCategory = :category AND " +
                         "SubjectLevel = :level AND " +
                         "Description = :description " + 
                         "WHERE SubjectID = :subject";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":level", this.Level);
            cmd.Parameters.Add(":category", this.Category);
            cmd.Parameters.Add(":description", this.Description);
            cmd.Parameters.Add(":subject", this.SubjectID);

            Database.ExecuteNonQuery(cmd);
        }

        public void Delete() 
        {
            string sql = "DELETE FROM Subjects " +
                         "WHERE SubjectID = :sub";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":sub", this.SubjectID);

            Database.ExecuteNonQuery(cmd);
        }

        public static string GetSubjectDetails(string subID)
        {
            Subject s = GetSubject(subID);
            return s.Level + ", " + s.Category + " - " + s.Description;
        }
        
        public static DataTable GetSubjectDescriptions()
        {
            var cmd = new OracleCommand("SELECT DISTINCT Description FROM Subjects");

            DataSet ds = Database.ExecuteMultiRowQuery(cmd);

            return ds.Tables[0];
        }

        public static void AddToTutorSubjectTable(string tutorID, string subjectID)
        {
            string sql = "INSERT INTO Tutor_Subjects (TutorID, SubjectID) " +
                          "VALUES (:t,:s)";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":t", tutorID);
            cmd.Parameters.Add(":s", subjectID);

            Database.ExecuteNonQuery(cmd);
        }

        public static string GetDescription(string id)
        {
            string sub = "";
            string sql = "SELECT Description " +
                         "FROM Subjects " +
                         "WHERE SubjectID = :id";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":id", id);

            OracleDataReader dr = Database.ExecuteSingleRowQuery(cmd);
            if (dr.Read())
            {
                sub = dr.GetString(0);
            }
            
            dr.Close();
            return sub;
        }

    }
}
