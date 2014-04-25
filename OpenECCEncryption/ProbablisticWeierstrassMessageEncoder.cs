using System;
using System.Numerics;
using OpenECC.Encryption.Core;

namespace OpenECC.Encryption
{
    public class ProbablisticWeierstrassMessageEncoder : IMessageEncoder
    {
        private WeierstrassCurve _curve;
        private BigInteger _k;

        public ProbablisticWeierstrassMessageEncoder(WeierstrassCurve curve, BigInteger k)
        {
            _curve = curve;
            _k = k;
        }

        public Point EncodeMessage(Plaintext message)
        {
            var m = message.ToBigInteger();

            throw new NotImplementedException();
        }

        public Plaintext DecodeMessage(Point messagePoint)
        {
            throw new NotImplementedException();
        }
    }
}
