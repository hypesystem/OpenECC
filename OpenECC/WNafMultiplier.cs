using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace OpenECC
{
    public class WNafMultiplier : IPointMultiplier
    {
        private readonly int _w;
        private readonly int _two_to_w;
        private readonly int _limit;

        public WNafMultiplier(int w)
        {
            _w = w;
            _two_to_w = (int)Math.Pow(2, _w);
            _limit = (int)Math.Pow(2, _w - 1);
        }

        public Point Multiply(Point p, BigInteger k)
        {
            var wnaf = ComputeWNaf(k).ToArray();
            var wnaf_legnth = wnaf.LongLength;
            var precomputed_points = PrecomputeMultiplications(p);

            var result = p.Curve.Infinity;
            for (long i = wnaf_legnth - 1; i >= 0; i--)
            {
                result = result + result;
                if (wnaf[i] != BigInteger.Zero)
                {
                    if (wnaf[i] > BigInteger.Zero)
                    {
                        result = result + precomputed_points[wnaf[i]];
                    }
                    else
                    {
                        result = result - precomputed_points[-wnaf[i]];
                    }
                }
            }

            return result;
        }

        IEnumerable<long> ComputeWNaf(BigInteger k)
        {
            while (k >= 1)
            {
                if (k % 2 == 1)
                {
                    var k_i = Mods(k);
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

        long Mods(BigInteger k)
        {
            var k_mod = k % _two_to_w;
            if (k_mod >= _limit)
            {
                return (long)(k_mod - _two_to_w);
            }
            return (long)k_mod;
        }

        Point[] PrecomputeMultiplications(Point p)
        {
            var arr = new Point[_limit];

            for (int i = 1; i < _limit; i = i + 2)
            {
                var r = p;
                for (int j = 1; j < i; j++)
                {
                    r = r + p;
                }
                arr[i] = r;
            }

            return arr;
        }
    }
}
