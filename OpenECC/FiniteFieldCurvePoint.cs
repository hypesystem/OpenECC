using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenECC
{
    public class FiniteFieldCurvePoint : Point
    {
        private readonly int _x, _y;
        private readonly ICurve _curve;

        public FiniteFieldCurvePoint(int x, int y, ICurve curve)
        {
            _x = x;
            _y = y;
            _curve = curve;
        }

        public override int X { get { return _x; } }
        public override int Y { get { return _y; } }

        public override Point Add(Point q)
        {
            throw new NotImplementedException();
        }

        public override Point Multiply(Point q)
        {
            throw new NotImplementedException();
        }

        public override Point Exponentiate(int x)
        {
            throw new NotImplementedException();
        }
    }
}
