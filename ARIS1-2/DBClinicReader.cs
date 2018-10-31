using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARIS1_2
{
    class DBClinicReader
    {
        public string[] GetInputData()
        {
            using (UserContext db = new UserContext())
            {
                var clinics = db.Clinics;
                lines = new string[clinics.Count()];


                int i = 0;
                foreach (Clinic u in clinics)
                {
                    lines[i] = u.ID.ToString();
                    lines[i] = 
                        i++;
                }
            }
            return lines;
        }
    }
}
