using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace SensorBrodcaster
{
    class FakeDataService
    {
        private int port;
        private Random rand;

        //In the constructor we can change the port number later, for the sake of flexibility
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

                // Sending XML

                //Serializing, see helper method further below:

                String xmlBuffer = SerializeObjectToXmlString(data);
                Console.WriteLine(xmlBuffer);
                byte[] decodedBufferXml = Encoding.ASCII.GetBytes(xmlBuffer);
                IPEndPoint endPoint3 = new IPEndPoint(IPAddress.Broadcast, port + 2);
                simpleSocket.SendTo(decodedBufferXml, endPoint3);

                // Put it to "sleep" before the loop goes over again:
                Thread.Sleep(5000);

            }


        }

        // Helper method for XML serialization
        public static string SerializeObjectToXmlString(SensorData toSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }
    }
}
