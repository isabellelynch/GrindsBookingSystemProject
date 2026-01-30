using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrindsBookingSystem
{
    internal class Validation
    {
        public static bool Name(String n)
        {
            if (!Regex.IsMatch(n, @"^[a-zA-Z\s]+$") || string.IsNullOrWhiteSpace(n))
            {
                return false;
            }
            return true;
        }

        public static bool Email(String e)
        {
            if (!Regex.IsMatch(e, @"^[^@\s]+@[^@\s]+\.[^@\s]+$") || string.IsNullOrWhiteSpace(e))
            {
                return false;
            }
            return true;
        }

        

        public static bool Phone(String p)
        {
            if (!Regex.IsMatch(p, @"\d{3}-\d{7}$") || string.IsNullOrWhiteSpace(p))
            {
                return false;
            }
            return true;
        }

        public static bool ComboSelected(ComboBox c)
        {
            if(c.SelectedIndex == -1)
            {
                return false;
            }
            return true;
        }
    }
}
