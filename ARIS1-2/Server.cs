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
        Logger logger;

        public Server(Storage storage, Logger logger)
        {
            this.storage = storage;
            this.logger = logger;
        }

        string FormatMessage(int index)
        {
            string message = "item;" +

            storage.clinics[index].ID.ToString() + ";" +
            storage.clinics[index].city + ";" +
            storage.clinics[index].year.ToString() + ";" +
            storage.clinics[index].specialization + ";" +
            storage.clinics[index].cost.ToString() + ";" +
            storage.clinics[index].doctors_count.ToString() + ";";

            if (storage.clinics[index].ready)
                message += "true";
            else
                message += "false";

            return message;
        }

        private void SendMessage(string outmessage)
        {
            UdpClient sender = new UdpClient(); // создаем UdpClient для отправки сообщений
            try
            {
                byte[] data = Encoding.Unicode.GetBytes(outmessage);
                sender.Send(data, data.Length, "localhost", 8002); // отправка
                logger.Info("Сервер отправил данные: " + outmessage);
                Console.WriteLine("Отправлено " + outmessage);
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
                    string message = Encoding.Unicode.GetString(data);
                    logger.Info("Клиент прислал:" + message);
                    string[] temp = message.Split(';');

                    if (temp[0] == "go")
                        SendAll();

                    else if (temp[0] == "item")
                        AddClinic(message);

                    else if (temp[0] == "end")
                        storage.UploadDB();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                logger.Info("Ошибка" + ex.Message);
            }
            finally
            {
                receiver.Close();
            }
        }

        private void SendAll()
        {
            using (UserContext db = new UserContext())
            {
                var dbclinics = db.Clinics;
                foreach (Clinic u in dbclinics)
                {
                    string message = "item;" +
                               u.ID.ToString() + ";" +
                               u.city + ";" +
                               u.year.ToString() + ";" +
                               u.specialization + ";" +
                               u.cost.ToString() + ";" +
                               u.doctors_count.ToString() + ";";
                    if (u.ready)
                        message += "true";
                    else
                        message += "false";
                    SendMessage(message);
                    Console.WriteLine("запись " + u.ID + " отправлена");
                }
                SendMessage("end");
                storage.clinics.Clear();
            }
        }

        public void AddClinic(string datain)
        {
            try
            {
                    string[] temp = datain.Split(';');
                    Clinic tempclinic = new Clinic();

                    int i = 1;
                    storage.clinics.Add(new Clinic()
                    {
                        ID = Int32.Parse(temp[i++]),
                        city = temp[i++],
                        year = Int32.Parse(temp[i++]),
                        specialization = temp[i++],
                        cost = Int32.Parse(temp[i++]),
                        doctors_count = Int32.Parse(temp[i++]),
                        ready = temp[i].Equals("true") ? true : false
                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Work()
        {
            try
            {
                Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
                receiveThread.Start();

                SendMessage("ready");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
