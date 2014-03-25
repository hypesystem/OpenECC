using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenECC
{
    public static class BigIntegerConversion
    {
        public static Org.BouncyCastle.Math.BigInteger ToBouncyCastleBigInteger(this System.Numerics.BigInteger i)
        {
            return new Org.BouncyCastle.Math.BigInteger(i.ToString());
        }

        public static System.Numerics.BigInteger ToNativeBigInteger(this Org.BouncyCastle.Math.BigInteger i)
        {
            return System.Numerics.BigInteger.Parse(i.ToString());
        }
    }
}
