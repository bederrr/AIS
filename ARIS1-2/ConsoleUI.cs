using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARIS1_2
{
    class ConsoleUI
    {
        ConsoleUI(List<Clinic> clinics)
        {

        }

        public void PrintLines(VetClinic clinic)
        {
            string temp;
            temp = ("{0, 2}|{1, 13}|{2, 4}|{3, 10}|{4, 4}|{5, 2}|{6, 4}",
                    clinic.id,
                    clinic.city,
                    clinic.year,
                    clinic.specialization,
                    clinic.cost,
                    clinic.doctors_count,
                    ToStr(clinic.ready));
        }

        public void PrintLines()
        {
            Console.Clear();
            for (int i = 0; i < clinics.Count; i++)
            {
                PrintLines(clinics[i]);
            }
        }

        public void Process()
        {
            
        }
    }
}
