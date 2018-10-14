using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARIS1_2
{
    interface IClinicSaver
    {
        void Save(List<Clinic> clinics, string fileName);
    }
}
