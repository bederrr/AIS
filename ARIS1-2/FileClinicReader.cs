using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ARIS1_2
{
    class FileClinicReader
    {
        string[] lines;

        public string[] FileReader(string input)
        {
            if (input != null)
                return lines = File.ReadAllLines(input, System.Text.Encoding.Default);

            else throw new Exception("Ошибка загрузки файла");
        }
    }
}
