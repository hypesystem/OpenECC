using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace OpenECC
{
    public class CurveFactory
    {

        /// <summary>
        /// y^2 = x^3+0x+7 over Fp where p = 2^256 - 2^32 - 977
        /// (a = 0, b = 7)
        /// </summary>
        public static ICurve secp256k1
        {
            get
            {
                var var2to256 = new BigInteger(2) ^ new BigInteger(256);
                var var2to32 = new BigInteger(2) ^ new BigInteger(32);
                var p = var2to256 - var2to32 - new BigInteger(977);
                return new WeierstrassCurve(new BigInteger(0), new BigInteger(7), p);
            }
        }
    }
}
