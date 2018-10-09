using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARIS1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileClinicReader filerearer = new FileClinicReader();
            filerearer.FileReader(@"file.csv");
        }
    }
}
