using System;
using OpenECC.Encryption.Core;

namespace OpenECC.Encryption
{
    public class ElGamalCiphertext : Ciphertext
    {
        public ElGamalCiphertext(Point c1, Point c2) : base ("/")
        {
            throw new NotImplementedException();
            //Should use base properly!
        }
    }
}
