using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class Program
    {
        static string remoteAddress = "localhost"; // хост для отправки данных
        static int remotePort = 8001; // порт для отправки данных
        static int localPort = 8002; // локальный порт для прослушивания входящих подключений

        private static void SendMessage(string input)
        {
            UdpClient sender = new UdpClient(); // создаем UdpClient для отправки сообщений
            try
            {
                    byte[] data = Encoding.Unicode.GetBytes(input);
                    sender.Send(data, data.Length, remoteAddress, remotePort); // отправка                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void ReceiveMessage()
        {
            UdpClient receiver = new UdpClient(localPort); // UdpClient для получения данных
            IPEndPoint remoteIp = null; // адрес входящего подключения
            try
            {
                while (true)
                {
                    byte[] data = receiver.Receive(ref remoteIp); // получаем данные
                    string message = Encoding.Unicode.GetString(data);
                    Console.Write(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                receiver.Close();
            }
        }

        static void ClientAction()
        {
            Console.WriteLine("Для отображения всех записей введите A\n" +
                "Для выбора записи введите N\n" +
                "Для добавления новой записи нажмите F\n" +
                "Для сохранения текущего списка в файл нажмите S\n" +
                "Для выхода нажмите ESC\n");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                case ConsoleKey.A:
                    SendMessage("all");
                    ClientAction();
                    break;
                case ConsoleKey.N:
                    Console.WriteLine("\nОтправьте номер записи");
                    int index = Int32.Parse(Console.ReadLine());
                    SendMessage(index.ToString());
                    Console.WriteLine("\nДля удаления записи нажмите D");
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.D:
                            SendMessage("del;index");
                            break;
                        default:
                            Console.WriteLine("Error");
                            break;
                    }


                    ClientAction();
                    break;




            }
        } 

        static void Main(string[] args)
        {
            try
            {
                Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
                receiveThread.Start();
                ClientAction();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
