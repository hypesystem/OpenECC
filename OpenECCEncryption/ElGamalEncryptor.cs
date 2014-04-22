using System;
using System.Numerics;
using System.Security.Cryptography;
using OpenECC.Encryption.Core;

namespace OpenECC.Encryption
{
    public class ElGamalEncryptor : IEncryptor
    {
        ICurve _curve;
        BigInteger _n;

        public ElGamalEncryptor(ICurve curve, BigInteger n)
        {
            _curve = curve;
            _n = n;

            //What is prime order (n)???
            throw new NotImplementedException();
        }

        public Ciphertext Encrypt(PublicKey Q, Plaintext m)
        {
            var M = RepresentPlaintextAsPoint(m);

            var k = SelectK(_n);

            var c1 = _curve.Generator * k;
            var c2 = M + (Q.Point * k);

            return new ElGamalCiphertext(c1, c2);
        }

        public Point RepresentPlaintextAsPoint(Plaintext m)
        {
            throw new NotImplementedException();
        }

        public BigInteger SelectK(BigInteger n)
        {
            //Make a byte array with room enough for the limit
            byte[] bytes = n.ToByteArray();

            //Generate secure random byte sequence
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);

            var rand = new BigInteger(bytes);

            //Fit in range [1;n-1]
            return (rand % (n - 1)) + 1;
        }

        public Plaintext Decrypt(PrivateKey d, Ciphertext c)
        {
            throw new NotImplementedException();
        }
    }
}
