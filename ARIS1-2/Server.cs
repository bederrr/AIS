using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ARIS1_2
{
    class Server
    {
        Storage storage;
        UdpClient receiver = new UdpClient(8001); // UdpClient для получения данных
        UdpClient sender = new UdpClient(); // создаем UdpClient для отправки сообщений
        IPEndPoint remoteIp = null; // адрес входящего подключения
//        string format = " {0,-2} | {1,-15} | {2,-30} | {3,-5} | {4,-7} | {5,-11} | {6,-14} | {7,-4}\n";

        public Server(Storage storage)
        {
            this.storage = storage;
        }

        string FormatMessage(Clinic clinic)
        {
            string message = "";
//            message += String.Format("{0,-2} | {1,-15} | {2,-30} | {3,-5} | {4,-7} | {5,-11} | {6,-14} | {7,-4}\n", "ID", "Название", "Адрес", "Звезд", "Номеров", "Телефон", "ФИО директора", "Бронирование");
            foreach (var hotel in hotels)
            {
                message += String.Format("{0, 2} | {1, 13} | {2, 4} | {3, 10} | {4, 4} | {5, 2} | {6, 4}\n",
                hotel.Id, hotel.Name, hotel.Address, hotel.NumberOfStars, hotel.NumberOfRooms, hotel.PhoneNumber, hotel.DirectorFIO,
                hotel.Booking == true ? "Есть" : "Нет");
            }
            return message;
        }

        private void SendMessage(string outmessage)
        {
            try
            {
                while (true)
                {
                    byte[] data = Encoding.Unicode.GetBytes(outmessage);
                    this.sender.Send(data, data.Length, "localhost", 8002); // отправка
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sender.Close();
            }
        }

        private void ReceiveMessage()
        {
            try
            {
                while (true)
                {
                    byte[] data = this.receiver.Receive(ref this.remoteIp); // получаем данные
                    Action(Encoding.Unicode.GetString(data));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Action(string msg)
        {
            int index = -1;
            if (int.TryParse(msg, out index))
            {
                if (index > storage.clinics.Count && index <= 0)
                    SendMessage("Индекс за пределами массива");
                else SendMessage(storage.clinics[index - 1]);
            }

            else switch (msg.ToLower())
                {
                    case "a":
                        break;
                    case "d":
                        break;
                    case "s":
                        break;
                }
        }

        public void Work()
        {
            try
            {
                Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
                receiveThread.Start();

//                receiver.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
