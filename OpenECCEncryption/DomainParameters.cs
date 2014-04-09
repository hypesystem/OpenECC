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
        private readonly WeierstrassCurve _curve;
        private readonly Point _p;
        private readonly BigInteger _n, _cofactor;

        public DomainParameters(WeierstrassCurve curve, Point p, BigInteger n, BigInteger cofactor)
        {
            _curve = curve;
            _p = p;
            _n = n;
            _cofactor = cofactor;
        }

        #region properties
        public WeierstrassCurve Curve
        {
            get
            {
                return _curve;
            }
        }

        public Point P
        {
            get
            {
                return _p;
            }
        }

        public BigInteger N
        {
            get
            {
                return _n;
            }
        }

        public BigInteger Cofactor
        {
            get
            {
                return _cofactor;
            }
        }
        #endregion

        public bool ValidPublicKey(PublicKey pub)
        {
            var p = pub.Point;
            if (PointIsInfinity(p)) return false;
            if (!PointIsInField(p)) return false;
            if (!PointIsOnCurve(p)) return false;
            if (!PointTimesNIsInfinity(p)) return false;
            return true;
        }

        private bool PointIsInfinity(Point Q)
        {
            return Q == _curve.Infinity;
        }

        private bool PointIsInField(Point Q)
        {
            return (Q.X.Value >= 0 && Q.X.Value < _curve.Prime) &&
                (Q.Y.Value >= 0 && Q.Y.Value < _curve.Prime);
        }

        private bool PointIsOnCurve(Point Q)
        {
            throw new NotImplementedException();
        }

        //TODO: Better name for this !!!
        private bool PointTimesNIsInfinity(Point Q)
        {
            return (Q * _n) == _curve.Infinity;
        }
    }
}
