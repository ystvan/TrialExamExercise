using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SensorBrodcaster
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "UDP Server";
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Red;
            FakeDataService server = new FakeDataService(7000);
            server.Start();

            Console.ReadLine();
        }
    }
}
