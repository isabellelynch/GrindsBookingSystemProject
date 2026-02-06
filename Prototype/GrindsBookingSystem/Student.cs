using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GrindsBookingSystem
{
    public class Student : Person
    {
        public Student(int id, String name, String sname, String email, String phone) : base(id, name, sname, email, phone)
        { 
            
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void AddStudent(Student s)
        {
            AddPerson(s);

            Debug.WriteLine(this);

            string sql = "INSERT INTO Students VALUES (" +
                base.PersonID;

            Database.ExecuteNonQuery(sql);
        }

        public static DataSet GetAllStudents()
        {
            String sql = "SELECT s.StudentID, p.FirstName, p.Surname FROM People p JOIN Students s ON s.StudentID = p.PersonID ORDER BY StudentID";
            return Database.ExecuteMultiRowQuery(sql);
        }
    }
}
