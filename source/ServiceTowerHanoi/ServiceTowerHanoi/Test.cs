using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceTowerHanoi
{
    class Test : ITest
    {
        public string Add(int x, int y)
        {
            int total = x + y;
            return total.ToString();
        }
    }
}
