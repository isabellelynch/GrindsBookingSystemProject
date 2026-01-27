using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GrindsBookingSystem.frmHome;

namespace GrindsBookingSystem
{
    public class Schedule
    {
        public DateTime TimeandDate { get; set; }
        public int MaxAttendnace { get; set; }
        public int currentEnrollment { get; set; }
        public String RoomNo { get; set; }

        public int TutorID { get; set; }
        
    }
}
