using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARIS1_2
{
    class Utilites
    {
        public bool ToBoolean(string data)
        {
            if (data.ToLower() == "0")
                return false;

            return true;
        }

        public string ToString(bool b)
        {
            if (b == false)
                return "Не работает";

            return "Работает";
        }
    }
}
