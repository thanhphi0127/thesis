using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHanoi
{
    public class Services : IServices
    {
        int GetData(int a, int b)
        {
            return (a + b);
        }
    }
}
