using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARIS1_2
{
    class ConsoleUI
    {
        IClinicReader _reader;
        IClinicBinder _binder;
        IClinicValidator _validator;

        void PrintALL()
        {
            Console.Clear();
            using (ClinicContext db = new ClinicContext())
            {
                var clinics = db.Clinics;
                foreach (Clinic u in clinics)
                {
                    Console.WriteLine("{0, 2}|{1, 13}|{2, 4}|{3, 10}|{4, 4}|{5, 2}|{6, 4}",
                        u.ID,
                        u.city,
                        u.year,
                        u.specialization,
                        u.cost,
                        u.doctors_count,
                        u.ready == (true) ? "Работает" : "Не работает");
                }
            }
        }           

        void AddItemMenu()
        {
            _reader = new ConsoleClinicReader();
            _binder = new GeneralClinicBinder();
            _validator = new GeneralClinicValidator();

            string data = _reader.GetInputData();

            Clinic tempitem = new Clinic();

            tempitem = _binder.CreateClinic(data);

            if (_validator.IsValid(tempitem))
            {
                using (ClinicContext db = new ClinicContext())
                {
                    var clinics = db.Clinics;

                    db.Clinics.Add(tempitem);
                    db.SaveChanges();
                    Console.WriteLine("Объект успешно сохранен");
                }
            }
            return;
        }       

        void DeleteItemMenu()
        {
            Console.WriteLine("\nВведите id клиники, которую нужно удалить из списка");
            int index = Int32.Parse(Console.ReadLine());

            using (ClinicContext db = new ClinicContext())
            {
                var clinic = db.Clinics.FirstOrDefault(o => o.ID == index);
                if (clinic != null)
                {
                    db.Clinics.Remove(clinic);
                    db.SaveChanges();
                }
                else Console.WriteLine("Записи с таким ID не существует");
                return;
            }
        }   

        void PrintItem()
        {
            Console.WriteLine("\nВведите ID для отображения");

            int index = Int32.Parse(Console.ReadLine());

            using (ClinicContext db = new ClinicContext())
            {
                var clinic = db.Clinics.FirstOrDefault(o => o.ID == index);
                if (clinic != null)
                {
                    Console.WriteLine("{0, 2}|{1, 13}|{2, 4}|{3, 10}|{4, 4}|{5, 2}|{6, 4}",
                        clinic.ID,
                        clinic.city,
                        clinic.year,
                        clinic.specialization,
                        clinic.cost,
                        clinic.doctors_count,
                        clinic.ready == (true) ? "Работает" : "Не работает" + "\nДля возврата нажмите любую клавишу");
                    Console.ReadKey();
                }
                else Console.WriteLine("Записи с таким ID не существует");

            }
        }

        public void Process()
        {
            PrintALL();
            Console.WriteLine("\nДля выбора записи нажмите N\n" +
                              "Для удаления записи нажмите D\n" +
                              "Для добавления записи введите A\n" +
                              "Для выхода из программы нажмите ESC");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                case ConsoleKey.N:
                    PrintItem();
                    Process();
                    break;
                case ConsoleKey.A:
                    AddItemMenu();
                    Process();
                    break;
                case ConsoleKey.D:
                    DeleteItemMenu();
                    Process();
                    break;
            }
        }
    }
}
