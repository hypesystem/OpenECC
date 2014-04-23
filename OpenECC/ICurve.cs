using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace OpenECC
{
    public interface ICurve
    {
        BigInteger Prime { get; }
        Point Generator { get; }
        BigInteger OrderOfGenerator { get; }
    }
}
