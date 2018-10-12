using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARIS1_2
{
    class ConsoleClinicReader : IClinicReader
    {
        public string[] GetInputData()
        {
            string templine = "";
            string str;
            int temp;

            Console.WriteLine("\nВведите город:\n");
            templine += Console.ReadLine(); templine += ";";

            do
            {
                Console.WriteLine("\nВведите год:\n");
                str = Console.ReadLine();
            }
            while (!(int.TryParse(str, out temp)));
            templine += str; templine += ";";

            Console.WriteLine("\nВведите специализацию:\n");
            templine += Console.ReadLine(); templine += ";";

            do
            {
                Console.WriteLine("\nВведите среднюю цену услуг:\n");
                str = Console.ReadLine();
            }
            while (!(int.TryParse(str, out temp)));
            templine += str; templine += ";";

            do
            {
                Console.WriteLine("\nВведите количество врачей:\n");
                str = Console.ReadLine();
            }
            while (!(int.TryParse(str, out temp)));
            templine += str; templine += ";";

            Console.WriteLine("\nВведите 0 или 1 для указания активности:\n");
            templine += Console.ReadLine();

            return templine;
        }
    }
}
