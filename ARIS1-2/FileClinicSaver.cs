using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ARIS1_2
{
    class FileClinicSaver : IClinicSaver
    {
        public void Save(Clinic[] clinics, string fileName)
        {
            string[] lines = new string[clinics.Count()];

            for (int i = 0; i < clinics.Count(); i++)
            {
                lines[i] += clinics[i].city;
                lines[i] += ";";

                lines[i] += clinics[i].year.ToString();
                lines[i] += ";";

                lines[i] += clinics[i].specialization;
                lines[i] += ";";

                lines[i] += clinics[i].cost.ToString();
                lines[i] += ";";

                lines[i] += clinics[i].doctors_count.ToString();
                lines[i] += ";";

                lines[i] += clinics[i].ready.ToString();
            }

            File.WriteAllLines(@"file.csv", lines, System.Text.Encoding.Default);
        }
        
    }
}
