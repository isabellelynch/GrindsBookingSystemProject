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
            if (string.IsNullOrWhiteSpace(n)) {  return false; }

            foreach (char c in n)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool Email(String e)
        {
            if (e.Contains("@"))
            {
                int counter = 0;
                foreach (char c in e)
                {
                    if (c.Equals("@"))
                    {
                        counter++;
                    }
                    if (counter > 1)
                    {
                        return false;
                    }
                }

                int index = e.IndexOf("@");
                String local = e.Substring(0, index);
                String specialChars = "!#$%&'*+-/=?^_`{|}~.";
                String domain = e.Substring(index + 1);

                if (e.Length >= 255) { return false; }

                if (local.Length == 0 || local.Length > 64)
                {
                    return false;
                }

                if (local.Contains("..") || local[0].Equals(".") || local[local.Length-1].Equals("."))
                {
                    return false;
                }

                foreach (char d in local)
                {
                    if (!char.IsLetter(d) && !char.IsDigit(d) && !specialChars.Contains(d))
                    {
                        return false;
                    }
                }

                if (domain.Length == 0)
                {
                    return false;
                }


                if (!domain.Contains(".") || domain.Contains("_") || domain.Contains(" ") ||
                    domain.Contains(".."))
                {
                    return false;
                }

                int labelLength = 0;
                foreach (char c in domain)
                {
                    if (c.Equals('.'))
                    {
                        if (labelLength == 0)
                        {
                            return false;
                        }
                        labelLength = 0;
                    }
                    else if (char.IsLetterOrDigit(c) || c.Equals('-'))
                    {
                        labelLength++;
                        if (labelLength > 63)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }

                if (labelLength == 0)
                {
                    return false;
                }

                return true;
            }
            
            return false;
        }

        public static bool IrishPhoneNumber(String p)
        {
            if(p.Length != 11)
            {
                return false;
            }
            if (!p[0].Equals("0") && !p[1].Equals("8") && !p[3].Equals("-"))
            {
                return false;
            }

            int counter = 0;
            foreach (char c in p)
            {
                if (char.IsDigit(c))
                {
                    counter++;
                }
            }
            if(counter != 10)
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
