using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace GrindsBookingSystem
{
    public class Student: Person, InterfaceCRUD
    {
        public Student(string name, string sname, string email, string phone) : 
            base(name, sname, email, phone)
        { 
            
        }

        public Student() : base() { }

        public override string ToString()
        {
            return base.ToString();
        }
        public void Create()
        {
            string sql = "INSERT INTO Students (FirstName, Surname, Email, PhoneNo, Status) " +
                         "VALUES (:FirstName, :Surname, :Email, :Phone, :Status)";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":FirstName", FirstName);
            cmd.Parameters.Add(":Surname", Surname);
            cmd.Parameters.Add(":Email", Email);
            cmd.Parameters.Add(":Phone", Phone);
            cmd.Parameters.Add(":Status", 'A');

            Database.ExecuteNonQuery(cmd);
        }
        
        public string Read()
        {
            Student s = GetStudent(Convert.ToInt32(this.PersonID));

            return s.ToString();
        }
        
        public void Update()
        {
            string sql = "UPDATE Students SET " +
                         "Email = :Email, " +
                         "PhoneNo = :PhoneNo " +
                         "WHERE StudentID = :ID";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":Email", Email);
            cmd.Parameters.Add(":PhoneNo", Phone);
            cmd.Parameters.Add(":ID", this.PersonID);

            Database.ExecuteNonQuery(cmd);
        }

        public void Delete() 
        {
            string sql = "UPDATE Students SET " +
                         "Status = :S " +
                         "WHERE StudentID = :ID";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":S", 'I');
            cmd.Parameters.Add(":ID", this.PersonID);

            Database.ExecuteNonQuery(cmd);
        }

        public static DataSet RetrieveAll()
        {
            string sql = "SELECT * " +
                         "FROM Students " +
                         "WHERE Status = :s " +
                         "ORDER BY StudentID";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":s", 'A');

            return Database.ExecuteMultiRowQuery(cmd);
        }


        public static Student GetStudent(int id)
        {
            Student s = new Student();

            string sql = "SELECT * " +
                         "FROM Students " +
                         "WHERE StudentID = :id";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":id", id);

            OracleDataReader dr = Database.ExecuteSingleRowQuery(cmd);

            if (dr.Read())
            {
                s = new Student(dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4));

                s.SetID(id.ToString());  
            }
            dr.Close();
            return s;
        }

        public String IsValid()
        {
            if (!Validation.Name(FirstName))
            {
                return "First Name not in the correct format.";
            }
            else if (!Validation.Name(Surname))
            {
                return "Surname not in the correct format.";
            }
            else if (!Validation.Email(Email))
            {
                return "Email not in the correct format.";
            }
            else if (!Validation.IrishPhoneNumber(Phone))
            {
                return "Phone Number not in the correct format, must be XXX-XXXXXXX.";
            }
           
            return "Valid";
        }

        public static DataSet GetStudentList(ComboBox cb)
        {
            string idList = "";

            foreach (var v in cb.Items)
            {
                if (cb.Items.IndexOf(v) == cb.Items.Count - 1)
                {
                    idList += v.ToString();
                    break;
                }
                idList += v.ToString() + ",";
            }

            string sql = $@"SELECT * 
                         FROM Students 
                         WHERE StudentID IN ({idList}) 
                         ORDER BY StudentID";

            var cmd = new OracleCommand(sql);
            
            cmd.Parameters.Add(":list", idList);

            return Database.ExecuteMultiRowQuery(cmd);
        }

        public static void FillStudentDataTable(DataGridView dgv, ComboBox cb)
        {
            DataTable dt = GetStudentList(cb).Tables[0];

            dt.Columns.RemoveAt(dt.Columns.Count - 1);

            dgv.DataSource = dt;
        }

        public static bool DoesStudentExist(string email)
        {
            string sql = "SELECT 1 " +
                         "FROM Students " +
                         "WHERE Email = :email";

            var cmd = new OracleCommand(sql);

            cmd.Parameters.Add(":email", email);

            OracleDataReader dr = Database.ExecuteSingleRowQuery(cmd);

            return dr.Read();
        }


    }
}
