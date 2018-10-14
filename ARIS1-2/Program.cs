using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARIS1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Storage store = new Storage(new FileClinicReader(),
                                        new GeneralClinicBinder(),
                                        new GeneralClinicValidator(),
                                        new FileClinicSaver()
                                       );
            store.LoadProcess();

//            ConsoleUI consoleui = new ConsoleUI(store);
//            consoleui.Process();

            Server server = new Server(store);
            server.Work();
        }
    }
}
