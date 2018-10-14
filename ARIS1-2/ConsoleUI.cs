using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARIS1_2
{
    class ConsoleUI
    {
        Storage storage;

        public ConsoleUI(Storage storage)
        {
            this.storage = storage;
        }
        
        void PrintLines()
        {
            for (int i = 0; i < storage.clinics.Count; i++)
            
                Console.WriteLine("{0, 2}|{1, 13}|{2, 4}|{3, 10}|{4, 4}|{5, 2}|{6, 4}",
                                  i+1,
                                  storage.clinics[i].city,
                                  storage.clinics[i].year,
                                  storage.clinics[i].specialization,
                                  storage.clinics[i].cost,
                                  storage.clinics[i].doctors_count,
                                  storage.clinics[i].ready == (true) ? "Работает" : "Не работает");
            
        }

        void AddItemMenu()
        {
            storage.Reader = new ConsoleClinicReader();

            string[] data = storage.Reader.GetInputData();

            Clinic tempclinic = new Clinic();

            for (int i = 0; i < data.Length; i++)
            {
                tempclinic = storage.Binder.CreateClinic(data[i]);

                if (storage.Validator.IsValid(tempclinic))
                {
                    storage.clinics.Add(tempclinic);                //Saver.Save(tempclinics[i], "output.txt");
                    Console.WriteLine("Данные из строки " + (i + 1) + " успешно добавлены в коллекцию");
                }
                else
                {
                    Console.WriteLine("Строка " + (i + 1) + " содержит некорректные данные");
                }
            }
        }

        void DeleteItemMenu()
        {
            Console.WriteLine("\nВведите id клиники, которую нужно удалить из списка");
            int index = Int32.Parse(Console.ReadLine());

            if (index > 0 && index <= storage.clinics.Count)
                storage.clinics.RemoveAt(index - 1);

            else
                Console.WriteLine("Введеный номер за пределами списка");            
        }

        public void Process()
        {
            PrintLines();
            Console.WriteLine("\nДля удаления записи нажмите D\n" +
                              "Для добавления записи введите A\n" +
                              "Для выхода из программы нажмите ESC\n" +
                              "Для сохранения списка в файл и выхода нажмите S");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                case ConsoleKey.A:
                    AddItemMenu();
                    Process();
                    break;
                case ConsoleKey.D:
                    DeleteItemMenu();
                    Process();
                    break;
                case ConsoleKey.S:
                    storage.UploadProcess();
                    break;
            }
        }
    }
}
