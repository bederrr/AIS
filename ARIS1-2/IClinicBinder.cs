using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARIS1_2
{
    interface IClinicBinder
    {
        Clinic CreateClinic(string[] data);
//        Clinic CreateClinic(string data);
    }
}
