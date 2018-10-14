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
            string[] outline = new string[1];
            string temp;
            int count;

            Console.WriteLine("\nВведите город:\n");
            outline[0] = Console.ReadLine(); outline[0] += ";";

            do
            {
                Console.WriteLine("\nВведите год:\n");
                temp = Console.ReadLine();
            }
            while (!(int.TryParse(temp, out count)));
            outline[0] += temp; outline[0] += ";";

            Console.WriteLine("\nВведите специализацию:\n");
            outline[0] += Console.ReadLine(); outline[0] += ";";

            do
            {
                Console.WriteLine("\nВведите среднюю цену услуг:\n");
                temp = Console.ReadLine();
            }
            while (!(int.TryParse(temp, out count)));
            outline[0] += temp; outline[0] += ";";

            do
            {
                Console.WriteLine("\nВведите количество врачей:\n");
                temp = Console.ReadLine();
            }
            while (!(int.TryParse(temp, out count)));
            outline[0] += temp; outline[0] += ";";

            Console.WriteLine("\nВведите true или false для указания активности:\n");
            outline[0] += Console.ReadLine();

            return outline;
        }
    }
}
