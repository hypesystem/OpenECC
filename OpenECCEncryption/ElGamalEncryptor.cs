﻿using System;
using System.Numerics;
using System.Security.Cryptography;
using OpenECC.Encryption.Core;

namespace OpenECC.Encryption
{
    public class ElGamalEncryptor : IEncryptor
    {
        ICurve _curve;
        SecureRandom _rng = new SecureRandom();
        IMessageEncoder _encoder;

        public ElGamalEncryptor(ICurve curve)
        {
            _curve = curve;

            //The encoder only works with WeierstrassCurves
            if (curve is WeierstrassCurve)
            {
                var c = curve as WeierstrassCurve;
                _encoder = new ProbabilisticWeierstrassMessageEncoder(c);
            }
            else
            {
                throw new ArgumentException("Curve must be a WeierstrassCurve in order for the encoding to work.", "curve");
            }
        }

        public Ciphertext Encrypt(PublicKey Q, Plaintext m)
        {
            BigInteger encoding_k;
            var M = _encoder.EncodeMessage(m, out encoding_k);

            var k = SelectK();

            var c1 = _curve.Generator * k;
            var c2 = M + (Q.Point * k);

            return new ElGamalCiphertext(c1, c2, encoding_k);
        }

        public BigInteger SelectK()
        {
            return _rng.GetBigInteger(
                min: BigInteger.One,
                max: _curve.OrderOfGenerator - 1
            );
        }

        public Plaintext Decrypt(PrivateKey d, Ciphertext c)
        {
            if (!(c is ElGamalCiphertext))
                throw new ArgumentException("Ciphertext must be ElGamalCiphertext!");

            var ciphertext = c as ElGamalCiphertext;

            var M = ciphertext.C2 - (ciphertext.C1 * d.Value);

            return _encoder.DecodeMessage(M, ciphertext.EncodingKey);
        }

        public KeyPair GenerateKeyPair()
        {
            var d = SelectK();
            var Q = _curve.Generator * d;
            return new KeyPair(new PublicKey(Q), new PrivateKey(d));
        }
    }
}
