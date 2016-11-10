using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SensorBrodcaster
{
    class FakeDataService
    {
        private int port;
        private Random rand;

        public FakeDataService(int port)
        {
            this.port = port;
            rand = new Random(DateTime.Now.Millisecond);
        }

        public void Start()
        {
            Socket simpleSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            simpleSocket.EnableBroadcast = true;

            Socket jsonSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            jsonSocket.EnableBroadcast = true;

            Socket xmlSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            xmlSocket.EnableBroadcast = true;

            //Declaring an object named "data" of class type SensorData
            SensorData data;

            while (true)
            {
                // Constructing an object called "data" is a type Sensordata with random light&temp
                data = new SensorData(rand.Next(255), rand.Next(255));

                //Sending simple Plain data

                String buffer = String.Format("light: {0}\r\ntemp: {1}\r\ntimestamp: {2}\r\n", data.Light, data.Temp, data.Timestamp);

                Console.WriteLine(buffer);
                byte[] decodedBuffer = Encoding.ASCII.GetBytes(buffer);

                IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, port);
                simpleSocket.SendTo(decodedBuffer, endPoint);


                //Sending Json data

                //Serializing:
                String jsonBuffer = JsonConvert.SerializeObject(data);
                Console.WriteLine(jsonBuffer);

                byte[] decodedBufferJson = Encoding.ASCII.GetBytes(jsonBuffer);
                IPEndPoint endPoint2 = new IPEndPoint(IPAddress.Broadcast, port + 1);
                simpleSocket.SendTo(decodedBufferJson, endPoint2);




            }


        }
    }
}
