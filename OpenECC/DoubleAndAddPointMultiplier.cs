using System;
using System.Numerics;

namespace OpenECC
{
    public class DoubleAndAddPointMultiplier : IPointMultiplier
    {
        public Point Multiply(Point p, BigInteger x)
        {
            if (x.Equals(BigInteger.Zero)) return p.Curve.Infinity;

            if ((x % 2).Equals(BigInteger.One))
            {
                return p + Multiply(p, x - 1);
            }

            return Multiply(p + p, x / 2);
        }
    }
}
