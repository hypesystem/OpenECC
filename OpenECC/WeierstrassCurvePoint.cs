using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace OpenECC
{
    /// <summary>
    /// A point on a WeierstrassCurve.
    /// </summary>
    public class WeierstrassCurvePoint : Point
    {
        private static IPointMultiplier _multiplier = new DoubleAndAddPointMultiplier();

        public static IPointMultiplier Multiplier
        {
            get
            {
                return _multiplier;
            }
            set
            {
                _multiplier = value;
            }
        }


        private readonly FiniteFieldElement _x, _y;
        private readonly WeierstrassCurve _curve;

        public WeierstrassCurvePoint(BigInteger x, BigInteger y, ICurve curve)
            : this(new FiniteFieldElement(x, curve.Prime), new FiniteFieldElement(y, curve.Prime), curve) {  }

        public WeierstrassCurvePoint(FiniteFieldElement x, FiniteFieldElement y, ICurve curve)
        {
            if (!(curve is WeierstrassCurve))
                throw new InvalidCurveException("A weierstrass curve point should only be placed on a weierstrass curve, but was placed on " + curve + ".");

            _x = x;
            _y = y;
            _curve = curve as WeierstrassCurve;
        }

        public override FiniteFieldElement X { get { return _x; } }
        public override FiniteFieldElement Y { get { return _y; } }
        public override ICurve Curve { get { return _curve; } }

        public override Point Add(Point other)
        {
            if(!(other is WeierstrassCurvePoint))
                throw new InvalidCurveException("Cannot add two points that belong to different curve-types. Second point must be WeierstrassCurvePoint.");

            var q = other as WeierstrassCurvePoint;

            if (this._curve != q._curve)
                throw new InvalidCurveException("Cannot add two points on different curves.");

            //p + infinity = p
            if (q.Equals(_curve.Infinity))
                return this;

            if (this.Equals(_curve.Infinity))
                return q;

            //p + -p = infinity
            if (this.Equals(-q))
                return _curve.Infinity;

            FiniteFieldElement x3, y3;

            //if p + q where p = q, do point doubling
            if (this.Equals(q))
            {
                var a = new FiniteFieldElement(_curve.A, _curve.Prime);
                var lambda = ((3 * ((this.X) ^ 2) + a) / (2 * this.Y));
                x3 = (lambda ^ 2) - (2 * this.X);
                y3 = (lambda) * (this.X - x3) - this.Y;
            }
            else
            {
                //adding two distinct points.
                var lambda = (q.Y - this.Y) / (q.X - this.X);
                x3 = (lambda ^ 2) - this.X - q.X;
                y3 = (lambda) * (this.X - x3) - this.Y;
            }
            return new WeierstrassCurvePoint(x3, y3, _curve);
        }

        public override Point Multiply(BigInteger x)
        {
            return _multiplier.Multiply(this, x);
        }

        public override Point Negate()
        {
            //-infinity = infinity
            if (this.Equals(_curve.Infinity))
                return this;

            return new WeierstrassCurvePoint(X, -Y, _curve);
        }

        #region ToString

        public override string ToString()
        {
            return "WeierstrassCurvePoint(" + X.Value + "," + Y.Value + ")";
        }

        #endregion

        #region comparison

        public override bool Equals(object obj)
        {
            if (obj is WeierstrassCurvePoint)
            {
                var q = obj as WeierstrassCurvePoint;

                //If either coordinate is null, the point must be infinity or inequal.
                //Without this check, a null reference may occur below.
                if (this.X == null || this.Y == null || q.X == null || q.Y == null)
                {
                    return this == _curve.Infinity && q == _curve.Infinity;
                }

                return this._curve.Equals(q._curve) && this.X.Equals(q.X) && this.Y.Equals(q.Y);
            }
            return false;
        }

        #endregion
    }
}
