using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class SimpleNode
    {
        public int idx { set; get; }
        public int weight { set; get; }
        public int prev { set; get; }
        public SimpleNode(int i, int w)
        {
            idx = i;
            weight = w;
            prev = -1;
        }
    }
}
