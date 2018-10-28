using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public enum Status
    {
        GoingUp,
        GoingDown,
        Stopped
    }
    public class Request
    {
        public Request(int floor)
        {
            Floor = floor;
        }
        public int Floor { get; set; }
    }
}
