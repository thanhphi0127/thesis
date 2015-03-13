using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace ServiceTowerHanoi
{
    [ServiceContract]
    interface ITest
    {
        [OperationContract]
        string Add(int x, int y);
    }
}
