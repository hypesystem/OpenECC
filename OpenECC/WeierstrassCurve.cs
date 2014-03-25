using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace OpenECC
{
    /// <summary>
    /// A curve of the form y^2 = x^3+ax+b over a field F_prime
    /// </summary>
    public class WeierstrassCurve : ICurve
    {
        private BigInteger _a, _b, _prime;
        private readonly WeierstrassCurvePoint _infinity;
        public WeierstrassCurvePoint Infinity { get { return _infinity; } }

        public WeierstrassCurve(BigInteger a, BigInteger b, BigInteger prime)
        {
            _a = a;
            _b = b;
            _prime = prime;
            _infinity = new WeierstrassCurvePoint(null, null, this);
        }

        public BigInteger A
        {
            get
            {
                return _a;
            }
        }

        public BigInteger B
        {
            get
            {
                return _b;
            }
        }

        public BigInteger Prime
        {
            get
            {
                return _prime;
            }
        }
    }
}
