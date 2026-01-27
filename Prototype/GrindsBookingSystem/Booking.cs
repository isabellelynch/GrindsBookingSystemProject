using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindsBookingSystem
{
    public class Booking
    {
        public int bookingRef { get; set; }
        public int StudentID { get; set; }
        public DateTime DateOfBooking { get; set; }
        public DateTime GrindTime { get; set; }
        public int TutorID { get; set; }
        public int Amount { get; set; }

        public Booking() : this(0, 0, DateTime.Today, DateTime.Today, 0, 0) { }

        public Booking(int refNo, int student, DateTime booking, DateTime grindTime, int tutor, int amount)
        {
            bookingRef = refNo;
            StudentID = student;
            DateOfBooking = booking;
            GrindTime = grindTime;
            TutorID = tutor;
            Amount = amount;

        }

    }
}
