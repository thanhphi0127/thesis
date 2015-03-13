using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ServiceHanoi
{
    [ServiceContract]
    public interface IServices
    {
        [OperationContract]
        int GetData(int a, int b);
    }
}
