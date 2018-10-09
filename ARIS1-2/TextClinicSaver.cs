using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARIS1_2
{
    class TextClinicSaver : IClinicSaver
    {
        public void Save(Clinic clinic, string fileName)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(fileName, true))
            {
                writer.WriteLine(clinic.Model);
                writer.WriteLine(clinic.Price);
            }
        }
    }
}
