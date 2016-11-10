using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorBrodcaster
{
    public class SensorData
    {
        private int light;
        private int temp;
        private String timestamp;

        public int Light
        {
            get { return light; }
            set { light = value; }
        }

        public int Temp
        {
            get { return temp; }
            set { temp = value; }
        }

        public string Timestamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }

        public SensorData()
        {
            
        }

        public SensorData(int light, int temp)
        {
            this.light = light;
            this.temp = temp;
            this.timestamp = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
        }
    }
}
