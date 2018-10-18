using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ARIS1_2
{
    public class DBManager
    {
        public void StartDBManage()
        {
            using (UserContext db = new UserContext())
            {
                // создаем два объекта User
                Clinic clinic1 = new Clinic { city = "First", cost = 10, doctors_count = 1, specialization = "Cats", year = 1991, ready = true };
                Clinic clinic2 = new Clinic { city = "First", cost = 20, doctors_count = 2, specialization = "Dogs", year = 1992, ready = false };

                // добавляем их в бд
                db.Clinics.Add(clinic1);
                db.Clinics.Add(clinic2);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var clinics = db.Clinics;
                Console.WriteLine("Список объектов:");
                foreach (Clinic u in clinics)
                {
                    Console.WriteLine("{0}.{1} - {2}", u.ID, u.city, u.cost);
                }
            }
            Console.Read();
        }
    }
}
