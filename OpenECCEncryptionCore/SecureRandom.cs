using System;
using System.Security.Cryptography;
using System.Numerics;

namespace OpenECC.Encryption.Core
{
    public class SecureRandom
    {
        private RNGCryptoServiceProvider _rng;

        public SecureRandom()
        {
            _rng = new RNGCryptoServiceProvider();
        }

        /// <summary>
        /// Equivalent of "return random x in [min;max]"
        /// </summary>
        public BigInteger GetBigInteger(BigInteger min, BigInteger max)
        {
            byte[] bytes = max.ToByteArray();
            _rng.GetBytes(bytes);
            var rand = new BigInteger(bytes);

            return (rand % (max - min)) + min;
        }

        public BigInteger GetBigInteger(BigInteger max)
        {
            return GetBigInteger(BigInteger.Zero, max);
        }
    }
}
