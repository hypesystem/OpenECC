using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenECC
{
    public class InvalidCurveException : Exception
    {
        public InvalidCurveException(string msg) : base(msg) { }
        public InvalidCurveException(string msg, Exception e) : base(msg, e) { }
    }
}
