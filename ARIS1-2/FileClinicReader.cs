using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ARIS1_2
{
    class FileClinicReader:IClinicReader
    {
        string[] lines;

        public string[] GetInputData()
        {
            return lines = File.ReadAllLines("@input.ru", System.Text.Encoding.Default); 
        }
    }
}
