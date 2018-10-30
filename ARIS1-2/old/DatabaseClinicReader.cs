using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ARIS1_2
{ }
//{
//    //public class DatabaseClinicReader : IClinicReader
//    {
///*        public DatabaseClinicReader(List<Clinic> data)
//        {
//            using (UserContext db = new UserContext())
//            {
//                    db.Clinics.Add(data[i]);

//                db.SaveChanges();
//                Console.WriteLine("Объекты успешно сохранены");

//                // получаем объекты из бд и выводим на консоль
//                var clinics = db.Clinics;
//                Console.WriteLine("Список объектов:");
//                foreach (Clinic u in clinics)
//                {
//                    Console.WriteLine("{0}.{1} - {2}", u.ID, u.city, u.cost);
//                }
//            }
//        }
//        */
//        //public string[] GetInputData()
//        //{
//        //    using (UserContext db = new UserContext())
//        //    {
//        //        var clinics = db.Clinics;

//        //        string[] line = new string[clinics.Count()];
//        //        int i = 0;

//        //        foreach (Clinic u in clinics)
//        //        {
//        //            line[i] = u.ID.ToString() + ";" + u.city + ";" + u.year.ToString() + ";" + u.specialization + ";" + u.cost.ToString() + ";" + u.doctors_count.ToString();
//        //            if (u.ready)
//        //                line[i] += ";true";
//        //            else line[i] += ";false";
//        //            i++;
//        //        }
//        //        return line;
//        //    }
//        //}
//    }
//}
