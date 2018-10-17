using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARIS1_2
{
    class ClientClinicReader : IClinicReader
    {
        private string[] line = new string[1];
        
        public ClientClinicReader(string input)
        {
            this.line[0] = input.Substring(4);
        }

        public string[] GetInputData()
        {
            return line;
        }
    }
}


