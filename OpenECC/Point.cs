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
        private static IPointMultiplier _multiplier = null;
        private static IPointMultiplier _default_multiplier = new WNafMultiplier(3);

        public static IPointMultiplier Multiplier
        {
            get
            {
                if (_multiplier == null) _multiplier = DefaultMultiplier;
                return _multiplier;
            }
            set
            {
                _multiplier = value;
            }
        }

        public static IPointMultiplier DefaultMultiplier
        {
            get
            {
                return _default_multiplier;
            }
        }

        public abstract FiniteFieldElement X { get; }
        public abstract FiniteFieldElement Y { get; }
        public abstract ICurve Curve { get; }

        public abstract Point Add(Point q);
        public abstract Point Negate();

        public Point Multiply(BigInteger q)
        {
            return Multiplier.Multiply(this, q);
        }

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

        #region conversion
        public byte[] ToByteArray()
        {
            return X.Value.ToByteArray().Concat(Y.Value.ToByteArray()).ToArray();
        }
        #endregion
    }
}
