using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GrindsBookingSystem
{
    public class Class:InterfaceCRUD
    {
        public int Day { get; set; }
        public int Time { get; set; }
        public string TutorID { get; set; }
        public int CurrentEnrollment {  get; set; }
        public string RoomNo { get; set; }
        public string Semester {  get; set; }
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

        public void Create()
        {
            string sql = "INSERT INTO Classes (Day, Time, TutorID, CurrentEnrollment, RoomNo, SemesterNo, SubjectID)" +
                "VALUES (" + 
                Day + "," + 
                Time + "," +
                TutorID + "," +
                CurrentEnrollment + ",'" +
                RoomNo + "','" +
                Semester + "','" +
                SubjectID + "')";
            try
            {
                Database.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string Read()
        {
            Class c = GetClass(this.Day, this.Time, this.RoomNo);
            return c.ToString();
        }

        public void Update() 
        {
            this.Create();
        }
        public void Delete() 
        {
            string sql = "DELETE FROM Classes WHERE Day = " + Day +
                " AND Time = " + Time + " AND TutorID = " + TutorID;

            Database.ExecuteNonQuery(sql);
        }
        
        public static List<Class> ClassList(String room, string sem)
        {
            List<Class> list = new List<Class>();

            string sql = "SELECT * FROM Classes WHERE SemesterNo =  " + sem + " AND RoomNo = '" + room + "'";

            DataSet ds = Database.ExecuteMultiRowQuery(sql);

            foreach (DataRow r in ds.Tables[0].Rows)
            {
                Class c = new Class
                (
                    Convert.ToInt32(r[0]),
                    Convert.ToInt32(r[1]),
                    r[2].ToString(),
                    Convert.ToInt32(r[3]),
                    r[4].ToString(),
                    r[5].ToString(),
                    r[6].ToString()
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

        public static Class GetClass(int day, int time, string room)
        {
            string sql2 = "SELECT * FROM Classes WHERE Day = " + day + " AND Time = " + time + " AND RoomNo = '" + room + "'";

            OracleDataReader dr2 = Database.ExecuteSingleRowQuery(sql2);

            dr2.Read();

            Class c2 = new Class(dr2.GetInt32(0), dr2.GetInt32(1), dr2.GetString(2), dr2.GetInt32(3), dr2.GetString(4), dr2.GetString(5), dr2.GetString(6));

            dr2.Close();

            return c2;
        }



    }
}
