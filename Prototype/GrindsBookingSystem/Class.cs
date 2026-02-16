using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Security.Policy;

namespace GrindsBookingSystem
{
    public class Class
    {
        public string Subject { get; set; }
        public int Day { get; set; }
        public int Time { get; set; }
        public string TutorID { get; set; }
        public int CurrentEnrollment {  get; set; }
        public string RoomNo { get; set; }
        public int Semester {  get; set; }

        public Class(string sub, int day, int time, string id, int enroll, string room, int sem)
        {
            Subject = sub;
            Day = day;
            Time = time;
            TutorID = id;
            CurrentEnrollment = enroll;
            RoomNo = room;
            Semester = sem;
        }

        public static List<Class> ClassList(int sem)
        {
            List<Class> list = new List<Class>();

            string sql = "SELECT * FROM Classes WHERE SemesterNo =  " + sem;

            DataSet ds = Database.ExecuteMultiRowQuery(sql);

            foreach (DataRow r in ds.Tables[0].Rows)
            {
                Class c = new Class
                (
                    r[0].ToString(),
                    Convert.ToInt32(r[1]),
                    Convert.ToInt32(r[2]),
                    r[3].ToString(),
                    Convert.ToInt32(r[4]),
                    r[5].ToString(),
                    Convert.ToInt32(r[6])
                );

                list.Add(c);
            }
            return list;
        }
        
    }
}
