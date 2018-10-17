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
        static IClinicReader reader;
        static string remoteAddress = "localhost"; // хост для отправки данных
        static int remotePort = 8001; // порт для отправки данных
        static int localPort = 8002; // локальный порт для прослушивания входящих подключений

        static void SendMessage(string input)
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

        static void ReceiveMessage()
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
            while (true)
            {
                //Console.Clear();
                Console.WriteLine("Для отображения всех записей отправьте all\n" +
                "Для отображения конкретной записи отправьте её номер\n" +
                "Для добавления новой записи отправьте add\n" +
                "Для сохранения текущего списка в файл отправьте save\n");


                string input = Console.ReadLine();

                int index = -1;
                if (int.TryParse(input, out index))
                {
                    SendMessage(input);
                    Console.WriteLine("Отправьте del, если вы хотите удалить элемент");
                    input = Console.ReadLine();
                    if (input.ToLower() == "del")
                        SendMessage("del;"+index.ToString());
                }

                else switch (input.ToLower())
                    {
                        case "all":
                            SendMessage(input.ToLower());
                            break;

                        case "add":
                            reader = new ConsoleClinicReader();
                            SendMessage(reader.GetInputData());

                            break;

                        case "save":
                            SendMessage("sav");
                            break;

                        default:
                            Console.WriteLine("Неверная команда");
                            break;
                    }
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
