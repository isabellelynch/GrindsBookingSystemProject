using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Security.Policy;
using System.Windows.Forms;

namespace GrindsBookingSystem
{
    public class Class
    {
        public int Day { get; set; }
        public int Time { get; set; }
        public string TutorID { get; set; }
        public int CurrentEnrollment {  get; set; }
        public string RoomNo { get; set; }
        public int Semester {  get; set; }

        public Class(int day, int time, string id, int enroll, string room, int sem)
        {
            Day = day;
            Time = time;
            TutorID = id;
            CurrentEnrollment = enroll;
            RoomNo = room;
            Semester = sem;
        }

        public static List<Class> ClassList(String room, int sem)
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
                    2
                );

                list.Add(c);
            }
            return list;
        }

       

    }
}
