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
                if (!char.IsLetter(c) && c != '\'' && c.ToString() != " ")
                {
                    return false;
                }
            }
            return true;
        }

        public static bool Email(String e)
        {
            // Email validation pattern inspired by RFC 5322.
            // Full RFC-compliant validation is complex and intentionally relaxed here
            // to balance correctness and usability.

            if (e.Length >= 255) { return false; }

            int index = e.IndexOf("@");

            if(index != e.LastIndexOf("@") || index == -1) { return false; }

            String local = e.Substring(0, index);
            
            if (local.Length == 0 || 
                local.Length > 64 || 
                local.Contains("..") || 
                local[0].Equals(".") || 
                local[local.Length-1].Equals("."))
            {
                return false;
            }


            String specialChars = "!#$%&'*+-/=?^_`{|}~.";
            foreach (char d in local)
            {
                if (!char.IsLetter(d) && !char.IsDigit(d) && !specialChars.Contains(d))
                {
                    return false;
                }
            }

            String domain = e.Substring(index + 1);

            if (domain.Length == 0 || 
                !domain.Contains(".") || 
                domain.Contains("_") || 
                domain.Contains(" ") ||
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

        public static bool IrishPhoneNumber(String p)
        {
            // Validates a simplified Irish mobile phone number format (08X-XXXXXXX).
            // Based on the Irish National Numbering Plan (ComReg, Ireland)
            // and ITU-T Recommendation E.164.
            // Note: This validation enforces a local-format pattern and does not
            // support international (+353) representations.

            String validThirdChars = "35679";

            if (p.Length != 11)
            {
                return false;
            }
            if (p[0] != '0' || p[1] != '8' || p[3] != '-' || !validThirdChars.Contains(p[2]))
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
    }
}
