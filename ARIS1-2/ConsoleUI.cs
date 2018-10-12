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
            Console.Clear();

            Utilites utilites = new Utilites();

            for (int i = 0; i < storage.clinics.Count; i++)
            
                Console.WriteLine("{0, 2}|{1, 13}|{2, 4}|{3, 10}|{4, 4}|{5, 2}|{6, 4}",
                                  i+1,
                                  storage.clinics[i].city,
                                  storage.clinics[i].year,
                                  storage.clinics[i].specialization,
                                  storage.clinics[i].cost,
                                  storage.clinics[i].doctors_count,
                                  utilites.ToString(storage.clinics[i].ready));
            
        }

        public void Process()
        {
            PrintLines();
            Console.WriteLine("\nДля удаления записи нажмите D\n" +
                              "Для добавления записи введите A\n" +
                              "Для выхода из программы нажмите ESC\n" +
                              "Для сохранения списка в файл нажмите S");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                case ConsoleKey.A:
                    AddItemMenu();
                    MainMenu();
                    break;
                case ConsoleKey.N:
                    EditItemMenu();
                    break;
                case ConsoleKey.S:
                    SaveFile();
                    break;
            }
        }
    }
}
