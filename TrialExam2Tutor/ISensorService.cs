using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TrialExam2Tutor
{
    [ServiceContract]
    public interface ISensorService
    {
        [OperationContract]
        void StoreData(SensorData data);

        [OperationContract]
        List<SensorData> GetAllDatas();

        [OperationContract]
        List<SensorData> GetDataFrom(string FromTimestamp);

        [OperationContract]
        List<SensorData> GetDataFromTo(string FromTimestamp, string ToTimestamp);




    }
}
