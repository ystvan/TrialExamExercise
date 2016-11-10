using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SensorListener
{
    class UDPStreamReceiver
    {
        private int port;

        //In the constructor we can change the port number later, for the sake of flexibility
        public UDPStreamReceiver(int port)
        {
            this.port = port;
        }

        public void Start()
        {
            //We have to listen on the same port number to get the broadcast msgs

            UdpClient simpleSocket = new UdpClient(7000);

            //Listening to all IP's in our network, the port number does not matter, it will be overriden above
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

            // Getting into the loop:

            while (true)
            {
                //Define the "predicted" max size of data to be received "4000" is more than enough
                byte[] databuffer = new byte[4000];

                //Listening on the socket with ref ip => can be overriden!
                databuffer = simpleSocket.Receive(ref remoteEndPoint);

                String encodedText = Encoding.ASCII.GetString(databuffer);
                Console.WriteLine("MSG: " + encodedText);

                int light;
                int temp;
                String timestamp;

                TextReader reader = new StringReader(encodedText);
                String str1 = reader.ReadLine();
                String str2 = reader.ReadLine();
                String str3 = reader.ReadLine();

                light = Convert.ToInt32(str1.Split(' ')[1]);
                temp = Convert.ToInt32(str2.Split(' ')[1]);
                timestamp = str3.Split(' ')[1];

                Console.WriteLine($"light={light}\ntemperature={temp}\ntimestamp={timestamp}");
            }

            

        }
    }
}
