using System;
using System.Numerics;

namespace OpenECC
{
    public class NaivePointMultiplier : IPointMultiplier
    {
        public Point Multiply(Point p, BigInteger x)
        {
            Point result = p;
            for (int i = 1; i < x; i++)
            {
                result = result + p;
            }
            return result;
        }
    }
}
