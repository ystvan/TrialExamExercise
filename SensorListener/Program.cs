using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace SensorListener
{
    class Program
    {
        private const int PORT = 7000;

        static void Main(string[] args)
        {
            UDPStreamReceiver client = new UDPStreamReceiver(PORT);
            client.Start();
            
        }
    }
}
