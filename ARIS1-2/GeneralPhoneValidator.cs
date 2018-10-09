using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARIS1_2
{/// <summary>
/// //////////////////////////////////////////////
/// </summary>
    class GeneralClinicValidator : IClinicValidator
    {
        public bool IsValid(Clinic clinic)
        {
            if (String.IsNullOrEmpty(clinic.Model) || clinic.Price <= 0)
                return false;

            return true;
        }
    }
}
