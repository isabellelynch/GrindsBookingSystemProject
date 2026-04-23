using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GrindsBookingSystem
{
    public class Class : InterfaceCRUD
    {
        public int ClassID { get; private set; }
        public int Day { get; set; }
        public int Time { get; set; }
        public string TutorID { get; set; }
        public int CurrentEnrollment { get; set; }
        public string RoomNo { get; set; }
        public string Semester { get; set; }
        public string SubjectID { get; set; }

        public Class(int day, int time, string id, int enroll, string room, string sem, string subjectID)
        {
            Day = day;
            Time = time;
            TutorID = id;
            CurrentEnrollment = enroll;
            RoomNo = room;
            Semester = sem;
            SubjectID = subjectID;
        }

        public void SetID(int id)
        {
            ClassID = id;
        }

        public void Create()
        {
            string sql = "INSERT INTO Classes (Day, Time, TutorID, CurrentEnrollment, RoomNo, SemesterNo, SubjectID)" +
                         "VALUES (:d, :t, :id, :ce, :r, :s, :sub)";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":d", this.Day);
            cmd.Parameters.Add(":t", this.Time);
            cmd.Parameters.Add(":id", this.TutorID);
            cmd.Parameters.Add(":ce", this.CurrentEnrollment);
            cmd.Parameters.Add(":r", this.RoomNo);
            cmd.Parameters.Add(":s", this.Semester);
            cmd.Parameters.Add(":sub", this.SubjectID);

            Database.ExecuteNonQuery(cmd);
        }
        public string Read()
        {
            Class c = GetClass(this.ClassID);
            return c.ToString();
        }

        public void Update()
        {
            string sql = "UPDATE Classes SET " +
                         "Day = :d," +
                         "Time = :t," +
                         "TutorID = :id," +
                         "CurrentEnrollment = :ce," +
                         "RoomNo = :r," +
                         "SemesterNo = :s," +
                         "SubjectID = :sub " +
                         " WHERE ClassID = :cid";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":d", this.Day);
            cmd.Parameters.Add(":t", this.Time);
            cmd.Parameters.Add(":id", this.TutorID);
            cmd.Parameters.Add(":ce", this.CurrentEnrollment);
            cmd.Parameters.Add(":r", this.RoomNo);
            cmd.Parameters.Add(":s", this.Semester);
            cmd.Parameters.Add(":sub", this.SubjectID);
            cmd.Parameters.Add(":cid", this.ClassID);

            Database.ExecuteNonQuery(cmd);
        }
        public void Delete()
        {
            string sql = "UPDATE Classes SET " +
                         "Status = :S " +
                         "WHERE ClassID = :ID";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":S", 'C');
            cmd.Parameters.Add(":ID", this.ClassID);

            Database.ExecuteNonQuery(cmd);
        }

        public static List<Class> ClassList(String room, string sem)
        {
            List<Class> list = new List<Class>();

            string sql = "SELECT * FROM Classes WHERE SemesterNo =  " + sem + " AND RoomNo = '" + room + "' AND Status = 'A'";

            DataSet ds = Database.ExecuteMultiRowQuery(sql);

            foreach (DataRow r in ds.Tables[0].Rows)
            {
                Class c = new Class
                (
                    Convert.ToInt32(r[1]),
                    Convert.ToInt32(r[2]),
                    r[3].ToString(),
                    Convert.ToInt32(r[4]),
                    r[5].ToString(),
                    r[6].ToString(),
                    r[7].ToString()
                );

                list.Add(c);
            }
            return list;
        }

        public static string GetCurrentSemester()
        {
            string sem = DateTime.Now.Year.ToString();

            sem = sem.Substring(sem.Length - 2);

            int month = DateTime.Now.Month;

            if (month <= 6)
            {
                sem = sem + "1";
            }
            else
            {
                sem = sem + "2";
            }

            return sem;
        }

        public static Class GetClass(int id)
        {
            string sql = "SELECT * FROM Classes WHERE ClassID = " + id + " AND Status = 'A'";

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);

            if (dr.Read())
            {
                Class c2 = new Class(dr.GetInt32(1), dr.GetInt32(2), dr.GetString(3), dr.GetInt32(4), dr.GetString(5), dr.GetString(6), dr.GetString(7));

                dr.Close();

                return c2;
            }
            else
            {
                return null;
            }
        }

        public static int GetClassID(int day, int time, string room)
        {
            int id = 0;
            string sql = "SELECT ClassID FROM Classes " +
                         "WHERE Day = " + day + " " +
                         "AND Time = " + time + " " +
                         "AND RoomNo = '" + room + "' " +
                         "AND SemesterNo = '" + GetCurrentSemester() + "' " +
                         "AND Status = 'A'";

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);

            if (dr.Read())
            {
                id = dr.GetInt32(0);
                dr.Close();
            }
            return id;

        }

        

        public string GetClassSubject()
        {
            string sql = "SELECT Description " +
                         "FROM Subjects " +
                         "WHERE SubjectID = " + this.SubjectID;
            string sub = "";
            try
            {
                OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);
                if (dr.Read())
                {
                    sub = dr.GetString(0);
                    dr.Close(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return sub;
        }

        public bool IsClassFull()
        {
            bool full = false;

            string sql = "SELECT Capacity " +
                         "FROM Rooms " +
                         "WHERE RoomNo = " + this.RoomNo;

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);
            if (dr.Read())
            {
                int max = dr.GetInt32(0);
                int current = this.CurrentEnrollment;

                if (current == max)
                {
                    full = true;
                    dr.Close();
                }
            }
            return full;

        }

       

        
    }
}
