using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenECC
{
    public abstract class Point
    {
        public abstract FiniteFieldElement X { get; }
        public abstract FiniteFieldElement Y { get; }

        public abstract Point Add(Point q);
        public abstract Point Multiply(Point q);
        public abstract Point Exponentiate(int x);

        #region operators
        public static Point operator +(Point p, Point q)
        {
            return p.Add(q);
        }

        public static Point operator *(Point p, Point q)
        {
            return p.Multiply(q);
        }

        public static Point operator ^(Point p, int x)
        {
            return p.Exponentiate(x);
        }
        #endregion
    }
}
