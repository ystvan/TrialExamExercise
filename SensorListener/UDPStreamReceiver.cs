using System;
using System.Collections.Generic;
using System.Linq;
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
            
        }
    }
}
