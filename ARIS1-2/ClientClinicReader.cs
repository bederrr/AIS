using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARIS1_2
{
    class ClientClinicReader : IClinicReader
    {
        string[] line;

        public ClientClinicReader(string line)
        {
            int a = line.IndexOf(';');
            this.line[0] = line.Substring(a+1);
        }

        public string[] GetInputData()
        {
            return line;
        }
    }
}
