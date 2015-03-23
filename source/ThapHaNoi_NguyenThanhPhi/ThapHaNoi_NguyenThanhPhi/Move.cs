using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThapHaNoi_NguyenThanhPhi
{
    public class Move
    {
        public readonly string From;
        public readonly string To;

        public Move(string from, string to)
        {
			From = from; To = to;
		}

		public override string ToString() {
			return string.Format("Chuyển {0} qua {1}", From, To);

		}
         
    }
}
