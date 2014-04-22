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
            Point result = this;
            for (int i = 1; i < x; i++)
            {
                result = result + this;
            }
            return result;
        }

        public override Point Negate()
        {
            //-infinity = infinity
            if (this.Equals(_curve.Infinity))
                return this;

            return new WeierstrassCurvePoint(X, -Y, _curve);
        }

        #region comparison

        public override bool Equals(object obj)
        {
            if (obj is WeierstrassCurvePoint)
            {
                var q = obj as WeierstrassCurvePoint;

                //If either coordinate is null, the point must be infinity or inequal.
                if (this.X == null || this.Y == null || q.X == null || q.Y == null)
                {
                    return this == _curve.Infinity && q == _curve.Infinity;
                }

                //Deep equals
                return this._curve.Equals(q._curve) && this.X.Equals(q.X) && this.Y.Equals(q.Y);
            }
            return false;
        }

        #endregion
    }
}
