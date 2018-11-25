using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;

namespace WPFLogger
{
    public class ViewModel
    {
        public ObservableCollection<LogClass> logs { get; set; }

        public ViewModel ()
        {
            logs = new ObservableCollection<LogClass>();

            Parse();
        }

        private void Parse()
        {
            string[] lines = File.ReadAllLines(@"C:\git\AIS\ARIS1-2\bin\Debug\logfile.txt", System.Text.Encoding.Default);

            LogClass temp = new LogClass();

            for (int i = 0; i < lines.Length; i++)
                logs.Add(Bind(lines[i]));
        }

        private LogClass Bind(string data)
        {
            if (data.Length < 7)
                return null;

            string[] temp = data.Split('|');

            return new LogClass
            {
                time = temp[0],
                action = temp[3]
            };
        }
    }
}
