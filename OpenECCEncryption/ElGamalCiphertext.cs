using System;
using OpenECC.Encryption.Core;

namespace OpenECC.Encryption
{
    public class ElGamalCiphertext : Ciphertext
    {
        private Point _c1, _c2;

        public ElGamalCiphertext(Point c1, Point c2) : base ("/")
        {
            _c1 = c1;
            _c2 = c2;

            throw new NotImplementedException();
            //Should use base properly!
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
    }
}
