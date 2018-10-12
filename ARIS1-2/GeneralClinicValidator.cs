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
            if (String.IsNullOrEmpty(clinic.city) ||
                clinic.year <= 0 ||
                String.IsNullOrEmpty(clinic.specialization) ||
                clinic.cost < 0 ||
                clinic.doctors_count < 0)
                return false;

            return true;
        }
    }
}
