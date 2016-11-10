using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TrialExam2Tutor
{
    public class SensorService : ISensorService
    {
        private SensorModel db = new SensorModel();

        public void StoreData(SensorData data)
        {
            db.SensorDatas.Add(data);
            db.SaveChanges();
        }

        public List<SensorData> GetAllDatas()
        {
            return db.SensorDatas.ToList();
        }

        public List<SensorData> GetDataFrom(string FromTimestamp)
        {
            return db.SensorDatas.Where(s => s.TimeStamp.CompareTo(FromTimestamp) > 0).ToList();
        }

        public List<SensorData> GetDataFromTo(string FromTimestamp, string ToTimestamp)
        {
            return
                db.SensorDatas.Where(
                    s => s.TimeStamp.CompareTo(FromTimestamp) > 0 && s.TimeStamp.CompareTo(ToTimestamp) < 0).ToList();
        }
    }
}
