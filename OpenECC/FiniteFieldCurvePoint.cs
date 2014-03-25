using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace OpenECC
{
    public class FiniteFieldCurvePoint : Point
    {
        private static readonly FiniteFieldCurvePoint _infinity = new FiniteFieldCurvePoint(null,null,null);
        private FiniteFieldCurvePoint Infinity { get { return _infinity; } }

        private readonly FiniteFieldElement _x, _y, _z;
        private readonly ICurve _curve;

        public FiniteFieldCurvePoint(FiniteFieldElement x, FiniteFieldElement y, ICurve curve)
        {
            _x = x;
            _y = y;
            _z = new FiniteFieldElement(x.Value, new BigInteger(1));
            _curve = curve;
        }

        public override FiniteFieldElement X { get { return _x; } }
        public override FiniteFieldElement Y { get { return _y; } }

        public override Point Add(Point q)
        {
            //p + infinity = p
            if (q == Infinity)
                return this;

            //p + -p = infinity
            if (this == -q)
                return Infinity;

            throw new NotImplementedException();
        }

        public override Point Multiply(BigInteger x)
        {
            throw new NotImplementedException();
        }

        public override Point Negate()
        {
            //-infinity = infinity
            if (this == Infinity)
                return this;

            return new FiniteFieldCurvePoint(X, -Y, _curve);
        }
    }
}
