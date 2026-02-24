using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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

        public Class(int day, int time, string id, int enroll, string room, string sem)
        {
            Day = day;
            Time = time;
            TutorID = id;
            CurrentEnrollment = enroll;
            RoomNo = room;
            Semester = sem;
        }

        public void Create()
        {
            string sql = "INSERT INTO Classes (Day, Time, TutorID, CurrentEnrollment, RoomNo, SemesterNo)" +
                "VALUES (" + 
                Day + "," + 
                Time + "," +
                TutorID + "," +
                CurrentEnrollment + ",'" +
                RoomNo + "','" + 
                Semester + "')";
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
            return "";
        }

        public void Update() 
        {
            string sql = "UPDATE Classes SET Day = " + this.Day + ", Time = " + this.Time + ", TutorID = " + this.TutorID
                + ", RoomNo = '" + this.RoomNo + "' WHERE TutorID = " + this.TutorID;
            try
            {
                Database.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                    r[5].ToString()
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

       

    }
}
