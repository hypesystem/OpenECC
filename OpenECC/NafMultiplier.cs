using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace OpenECC
{
    /// <summary>
    /// Non-adjacent form multiplier.
    /// </summary>
    public class NafMultiplier : IPointMultiplier
    {
        public Point Multiply(Point p, BigInteger x)
        {
            var naf = ComputeNaf(x).ToArray();
            var num_nafs = naf.LongLength;

            var result = p.Curve.Infinity;

            for (long i = num_nafs - 1; i >= 0; i--)
            {
                result = result + result;
                if (naf[i] == BigInteger.One) result = result + p;
                if (naf[i] == BigInteger.MinusOne) result = result - p;
            }

            return result;
        }

        public IEnumerable<BigInteger> ComputeNaf(BigInteger k)
        {
            while (k >= 1)
            {
                if (k % 2 == 1)
                {
                    var k_i = 2 - (k % 4);
                    yield return k_i;
                    k = k - k_i;
                }
                else
                {
                    yield return 0;
                }
                k = k / 2;
            }
        }
    }
}
