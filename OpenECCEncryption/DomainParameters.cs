using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using OpenECC;

namespace OpenECC.Encryption
{
    public class DomainParameters
    {
        private WeierstrassCurve _curve;
        private Point _p;
        private BigInteger _n;

        public DomainParameters(WeierstrassCurve curve, Point p, BigInteger n)
        {
            _curve = curve;
            _p = p;
            _n = n;
        }

        public bool PointIsInfinity(Point Q)
        {
            return Q == _curve.Infinity;
        }

        public bool PointIsInField(Point Q)
        {
            return (Q.X.Value >= 0 && Q.X.Value < _curve.Prime) &&
                (Q.Y.Value >= 0 && Q.Y.Value < _curve.Prime);
        }

        public bool PointIsOnCurve(Point Q)
        {
            throw new NotImplementedException();
        }

        //TODO: Better name for this !!!
        public bool PointTimesNIsInfinity(Point Q)
        {
            return (Q * _n) == _curve.Infinity;
        }
    }
}
