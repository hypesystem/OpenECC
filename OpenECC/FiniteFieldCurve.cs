using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace OpenECC
{
    public class FiniteFieldCurve : ICurve
    {
        private readonly BigInteger _a, _b, _prime;

        public FiniteFieldCurve(BigInteger a, BigInteger b, BigInteger prime)
        {
            _a = a;
            _b = b;
            _prime = prime;
        }
    }
}
