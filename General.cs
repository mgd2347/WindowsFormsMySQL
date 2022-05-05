using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WindowsFormsMySQL
{
    class General
    {
        public static string RemoveSpaces(string msg)
        {
            msg = msg.Trim();
            msg = Regex.Replace(msg, @"\s+", " ");
            return msg;
        }

        public static bool CeckDate(string date)
        {
            try
            {
                DateTime dt = DateTime.Parse(date);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
