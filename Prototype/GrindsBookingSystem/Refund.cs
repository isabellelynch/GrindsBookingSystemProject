using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GrindsBookingSystem
{
    public class Refund
    {
        public int refundRef { get; set; }
        public int StudentID { get; set; }
        public int Amount { get; set; }

        public Refund() : this(0,0,0) { }

        public Refund(int refNo, int student, int amount)
        {
            refundRef = refNo;
            StudentID = student;
            Amount = amount;
        }
    }
}
