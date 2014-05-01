using System;
using OpenECC.Encryption.Core;
using System.Numerics;

namespace OpenECC.Encryption
{
    public class ElGamalCiphertext : Ciphertext
    {
        private Point _c1, _c2;
        private BigInteger _encoding_key;

        public ElGamalCiphertext(Point c1, Point c2, BigInteger encoding_key) : base (c1.ToByteArray(), c2.ToByteArray(), encoding_key.ToByteArray())
        {
            _c1 = c1;
            _c2 = c2;
            _encoding_key = encoding_key;
        }

        public Point C1
        {
            get
            {
                return _c1;
            }
        }

        public Point C2
        {
            get
            {
                return _c2;
            }
        }

        public BigInteger EncodingKey
        {
            get
            {
                return _encoding_key;
            }
        }
    }
}
