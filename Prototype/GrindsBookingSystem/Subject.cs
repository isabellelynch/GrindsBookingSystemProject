

using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace GrindsBookingSystem
{
    internal class Subject:InterfaceCRUD
    {
        public int SubjectID { get; private set; }
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

        public void SetID(int id)
        {
            SubjectID = id;
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
            Subject s = GetSubject(this.SubjectID.ToString());

            return s.ToString();
        }

        public static Subject GetSubject(string id)
        {
            string sql = "SELECT * FROM Subjects WHERE SubjectID = '" + id + "'";

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);

            dr.Read();

            Subject s = new Subject(dr.GetString(1), dr.GetString(2), dr.GetString(3));

            dr.Close();

            return s;
        }

        public static string GetSubjectID(string cat, string level, string description)
        {
            string sql = "SELECT SubjectID " +
                         "FROM Subjects " +
                         "WHERE SubjectCategory = '" + cat + "'" +
                         " AND SubjectLevel = '" + level + "'" +
                         " AND Description = '" + description + "'";

            string s = "";

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);

            s = dr.GetInt32(0).ToString();

            dr.Close();

            return s;
        }

        public override string ToString()
        {
            return "Subject : " + this.Description +
                "\nSubject ID : " + this.SubjectID +
                "\nLevel : " + this.Level +
                "\nCertificate : " + this.Category;
        }

        public void Update() { }

        public void Delete() { }

        public static string GetSubjectDetails(string subID)
        {
            Subject s = GetSubject(subID);
            return s.Level + ", " + s.Category + " - " + s.Description;
        }
        
        public static DataTable GetSubjectDescriptions()
        {
            string sql = "SELECT DISTINCT Description FROM Subjects";
            DataSet ds = Database.ExecuteMultiRowQuery(sql);
            return ds.Tables[0];
        }
    }
}
