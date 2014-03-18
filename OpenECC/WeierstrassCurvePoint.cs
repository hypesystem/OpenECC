﻿using System;
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
        private static readonly WeierstrassCurvePoint _infinity = new WeierstrassCurvePoint(null,null,null);
        private WeierstrassCurvePoint Infinity { get { return _infinity; } }

        private readonly FiniteFieldElement _x, _y, _z;
        private readonly WeierstrassCurve _curve;

        public WeierstrassCurvePoint(FiniteFieldElement x, FiniteFieldElement y, ICurve curve)
        {
            if (!(curve is WeierstrassCurve))
                throw new InvalidCurveException("A weierstrass curve point should only be placed on a weierstrass curve, but was placed on " + curve + ".");

            _x = x;
            _y = y;
            _z = new FiniteFieldElement(x.X, new BigInteger(1));
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
            if (q == Infinity)
                return this;

            //p + -p = infinity
            if (this == -q)
                return Infinity;

            FiniteFieldElement x3, y3;

            //if p + q where p = q, do point doubling
            if (this == q)
            {
                var a = new FiniteFieldElement(_curve.A, _curve.Prime);
                var lambda = ((3 * ((this.X) ^ 2) + a) / (2 * this.Y));
                x3 = (lambda ^ 2) - (2 * this.X);
                y3 = (lambda) * (this.X - x3) - this.Y;
            }
            else
            {
                //adding two distinct points.
                var lambda = (q.Y - this.Y / q.X - this.X);
                x3 = (lambda ^ 2) - this.X - q.X;
                y3 = (lambda) * (this.X - x3) - this.Y;
            }
            return new WeierstrassCurvePoint(x3, y3, _curve);
        }

        public override Point Multiply(Point q)
        {
            throw new NotImplementedException();
        }

        public override Point Exponentiate(int x)
        {
            Point tmp = this;
            for (int i = 1; i < x; i++)
            {
                tmp = tmp * this;
            }
            return tmp;
        }

        public override Point Negate()
        {
            //-infinity = infinity
            if (this == Infinity)
                return this;

            return new WeierstrassCurvePoint(X, -Y, _curve);
        }
    }
}
