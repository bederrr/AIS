using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARIS1_2
{
    class GeneralClinicBinder : IClinicBinder
    {
 /*       public void CreateClinic(string[] data)
        {
            for (int i = 0; i < data.Length; i++)
                CreateClinic(data[i]);
            return
        }
        */

        public Clinic CreateClinic(string data)
        {
            if (data.Length == 6)
            {
                string[] temp = data.Split(';');

                int i = 0;
                Utilites utilites = new Utilites();

                return new Clinic { city = temp[i++],
                                    year = Int32.Parse(temp[i++]),
                                    specialization = temp[i++],
                                    cost = Int32.Parse(temp[i++]),
                                    doctors_count = Int32.Parse(temp[i++]),
                                    ready = utilites.ToBoolean(temp[i])
                                  };
            }
            else
            {
                throw new Exception("Ошибка привязчика модели. Недостаточно данных для создания модели");
            }
        }
    }
}
