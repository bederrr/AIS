using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class ConsoleClonicReader : IClinicReader
    {
        public string GetInputData()
        {
            string outline = "add;";
            string temp;
            int count;

            Console.WriteLine("\nВведите город:\n");
            outline += Console.ReadLine(); outline += ";";

            do
            {
                Console.WriteLine("\nВведите год:\n");
                temp = Console.ReadLine();
            }
            while (!(int.TryParse(temp, out count)));
            outline += temp; outline += ";";

            Console.WriteLine("\nВведите специализацию:\n");
            outline += Console.ReadLine(); outline += ";";

            do
            {
                Console.WriteLine("\nВведите среднюю цену услуг:\n");
                temp = Console.ReadLine();
            }
            while (!(int.TryParse(temp, out count)));
            outline += temp; outline += ";";

            do
            {
                Console.WriteLine("\nВведите количество врачей:\n");
                temp = Console.ReadLine();
            }
            while (!(int.TryParse(temp, out count)));
            outline += temp; outline += ";";

            Console.WriteLine("\nВведите true или false для указания активности:\n");
            outline += Console.ReadLine();

            return outline;
        }
    }
}
