using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUI
{
    public class validate
    {
        public static bool valtext(string ten)
        {
            return ten.Trim().Length > 0;
        }
        public static bool valint(string ten)
        {
            return Convert.ToInt32(ten) > 0;
        }
    }
}
