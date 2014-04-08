using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenECC.Encryption
{
    public static class PublicKeyValidator
    {
        //TODO: ValidPublicKey should be part of DomainParameters!
        public static bool ValidPublicKey(PublicKey pub, DomainParameters param)
        {
            if (param.PointIsInfinity(pub)) return false;
            if (!param.PointIsInField(pub)) return false;
            if (!param.PointIsOnCurve(pub)) return false;
            if (!param.PointTimesNIsInfinity(pub)) return false;
            return true;
        }
    }
}
