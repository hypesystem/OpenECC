using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace OpenECC
{
    public class WNafPointMultiplier : IPointMultiplier
    {
        private int _w = 4;
        private IPointMultiplier _naive_multiplier = new NaivePointMultiplier();

        public Point Multiply(Point p, BigInteger x)
        {
            var multiplicands = ComputeMultiplicands(x);
            var precomp_points = PrecomputePoints(multiplicands, p);

            Point result = p;
            for (int i = multiplicands.Count - 1; i >= 0; i--)
            {
                result = result + result;
                if (i < multiplicands.Count && !multiplicands[i].Equals(BigInteger.Zero))
                {
                    result = result + _naive_multiplier.Multiply(p.Curve.Generator, multiplicands[i]);
                }
            }
            return result;
        }

        List<BigInteger> ComputeMultiplicands(BigInteger x)
        {
            var multiplicands = new List<BigInteger>();


            while (x > 0)
            {
                if (x % 2 == 1)
                {
                    var next = Mods(x, _w);
                    x = x - next;
                    multiplicands.Add(next);
                }
                else
                {
                    multiplicands.Add(BigInteger.Zero);
                }
                x = x / 2;
            }

            return multiplicands;
        }

        BigInteger Mods(BigInteger x, int w)
        {
            var edg = BigInteger.Pow(new BigInteger(2), w - 1);
            var mod = BigInteger.Pow(new BigInteger(2), w);

            if (x % mod >= edg)
                return (x % mod) - mod;
            else
                return x % mod;
        }

        Point[] PrecomputePoints(List<BigInteger> multiplicands, Point p)
        {
            return multiplicands.Select(x => _naive_multiplier.Multiply(p, x)).ToArray();
        }
    }
}
