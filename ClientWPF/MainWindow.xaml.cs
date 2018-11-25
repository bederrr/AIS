using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace ClientWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string remoteAddress = "localhost"; // хост для отправки данных
        static int remotePort = 8001; // порт для отправки данных
        static int localPort = 8002; // локальный порт для прослушивания входящих подключений
        bool ready = false;
        static ViewModel VM;

        static void SendMessage(string input)
        {
            UdpClient sender = new UdpClient(); // создаем UdpClient для отправки сообщений
            try
            {
                byte[] data = Encoding.Unicode.GetBytes(input);
                sender.Send(data, data.Length, remoteAddress, remotePort); // отправка               
                Console.WriteLine("отправлено " + input);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void SendAll()
        {
            foreach (Clinic u in VM.clinics)
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
            }
            SendMessage("end");
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

                    string[] temp = message.Split(';');

                    if (temp[0] == "item")
                    {
                        VM.AddClinic(message);
                    }
                    else if (temp[0] == "end")
                    {
                        VM.ischange = false;
                    }
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

        public MainWindow()
        {
            InitializeComponent();

            VM = new ViewModel();
            VM.clinics.CollectionChanged += VM.Clinic_CollectionChanged;

            DataContext = VM;

            try
            {
                Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ButtonDownload_Click(object sender, RoutedEventArgs e)
        {
            if (!ready)
            {
                SendMessage("go");
                ready = true;
                ButtonDownload.IsEnabled = false;
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (!VM.ischange)
                return;

            SendAll();

        }
    }
}
