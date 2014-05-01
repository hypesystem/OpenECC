using System;
using System.Numerics;

namespace OpenECC
{
    public interface IPointMultiplier
    {
        Point Multiply(Point p, BigInteger x);
    }
}
