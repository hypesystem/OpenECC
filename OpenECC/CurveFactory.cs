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
        /// (Weierstrass curve with a = 0, b = 7)
        /// This curve is used in the Bitcoin implementation.
        /// </summary>
        [Obsolete("This curve is not safe - see http://safecurves.cr.yp.to")]
        public static WeierstrassCurve secp256k1
        {
            get
            {
                var var2to256 = BigInteger.Pow(new BigInteger(2), 256);
                var var2to32 = BigInteger.Pow(new BigInteger(2), 32);
                var p = var2to256 - var2to32 - new BigInteger(977);

                var g_x = BigInteger.Parse("55066263022277343669578718895168534326250603453777594175500187360389116729240");
                var g_y = BigInteger.Parse("32670510020758816978083085130507043184471273380659243275938904335757337482424");

                return new WeierstrassCurve(new BigInteger(0), new BigInteger(7), p, g_x, g_y);
            }
        }
    }
}
