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
        byte[] rng_bytes;

        public ElGamalEncryptor(ICurve curve, BigInteger n)
        {
            _curve = curve;
            _n = n;

            //Byte array with enough room for a number the size of n
            rng_bytes = _n.ToByteArray();

            //What is prime order (n)???
            throw new NotImplementedException();
        }

        public Ciphertext Encrypt(PublicKey Q, Plaintext m)
        {
            var M = RepresentPlaintextAsPoint(m);

            var k = SelectK();

            var c1 = _curve.Generator * k;
            var c2 = M + (Q.Point * k);

            return new ElGamalCiphertext(c1, c2);
        }

        public Point RepresentPlaintextAsPoint(Plaintext m)
        {
            throw new NotImplementedException();
        }

        public BigInteger SelectK()
        {
            //Generate secure random byte sequence
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(rng_bytes);

            var rand = new BigInteger(rng_bytes);

            //Fit in range [1;n-1]
            return (rand % (_n - 1)) + 1;
        }

        public Plaintext Decrypt(PrivateKey d, Ciphertext c)
        {
            if (!(c is ElGamalCiphertext))
                throw new ArgumentException("Ciphertext must be ElGamalCiphertext!");

            var ciphertext = c as ElGamalCiphertext;

            var M = ciphertext.C2 - (ciphertext.C1 * d.Value);

            return RepresentPointAsPlaintext(M);
        }

        private Plaintext RepresentPointAsPlaintext(Point p)
        {
            throw new NotImplementedException();
        }
    }
}
