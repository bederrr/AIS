using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using NLog;

namespace ARIS1_2
{
    class Server
    {
        Storage storage;

        Logger logger = LogManager.GetCurrentClassLogger();

        public Server(Storage storage)
        {
            this.storage = storage;
        }

        string FormatMessage(int index)
        {
            string message = "";
               return message += String.Format("{0, 2} | {1, 13} | {2, 4} | {3, 10} | {4, 4} | {5, 2} | {6, 4}\n",
                    index,
                    storage.clinics[--index].city,
                    storage.clinics[index].year,
                    storage.clinics[index].specialization,
                    storage.clinics[index].cost,
                    storage.clinics[index].doctors_count,
                    storage.clinics[index].ready == (true) ? "Работает" : "Не работает");
        }

        private void SendMessage(string outmessage)
        {
            UdpClient sender = new UdpClient(); // создаем UdpClient для отправки сообщений
            try
            {                
                    byte[] data = Encoding.Unicode.GetBytes(outmessage);
                    sender.Send(data, data.Length, "localhost", 8002); // отправка
                logger.Info("Сервер отправил данные: " + outmessage);
                    //Console.WriteLine("Отправлено");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ReceiveMessage()
        {
            UdpClient receiver = new UdpClient(8001); // UdpClient для получения данных
            IPEndPoint remoteIp = null; // адрес входящего подключения
            try
            {
                while (true)
                {
                    byte[] data = receiver.Receive(ref remoteIp); // получаем данные
                    logger.Info("Клиент прислал:" + Encoding.Unicode.GetString(data));
                    Action(Encoding.Unicode.GetString(data));
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

        private void Action(string line)
        {
            string[] command = line.Split(';');

            int index = -1;
            if (int.TryParse(command[0], out index))
            {
                if (index > storage.clinics.Count || index <= 0)
                    SendMessage("Индекс за пределами массива");
                else SendMessage(FormatMessage(index));
            }

            else switch (command[0].ToLower())
                {
                    case "add":
                        storage.Reader = new ClientClinicReader(line);
                        storage.LoadProcess();
                        break;

                    case "all":
                        for (int i = 1; i <= storage.clinics.Count; i++)
                            SendMessage(FormatMessage(i));
                        break;

                    case "del":
                        int num = Int32.Parse(command[1]);
                        if (num > 0 && num <= storage.clinics.Count)
                        {
                            storage.clinics.RemoveAt(num - 1);
                            SendMessage("Номер удален\n");
                        }
                        break;
                        
                    case "sav":
                        storage.UploadProcess();
                        SendMessage("Запись успешно завершена\n");
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
