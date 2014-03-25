using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace OpenECC
{
    public abstract class Point
    {
        public abstract FiniteFieldElement X { get; }
        public abstract FiniteFieldElement Y { get; }

        public abstract Point Add(Point q);
        public abstract Point Multiply(BigInteger q);
        public abstract Point Negate();

        #region operators
        public static Point operator +(Point p, Point q)
        {
            return p.Add(q);
        }

        public static Point operator *(Point p, BigInteger q)
        {
            return p.Multiply(q);
        }

        public static Point operator -(Point p)
        {
            return p.Negate();
        }

        public static Point operator -(Point p, Point q)
        {
            return p + (-q);
        }
        #endregion
    }
}
