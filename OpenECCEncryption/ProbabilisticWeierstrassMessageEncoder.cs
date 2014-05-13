using System;
using System.Numerics;
using OpenECC.Encryption.Core;

namespace OpenECC.Encryption
{
    public class ProbabilisticWeierstrassMessageEncoder : IMessageEncoder
    {
        private WeierstrassCurve _curve;
        private BigInteger _k;

        public ProbabilisticWeierstrassMessageEncoder(WeierstrassCurve curve, BigInteger encoding_key)
        {
            _curve = curve;
            _k = encoding_key;
        }

        public Point EncodeMessage(Plaintext message)
        {
            var m = message.ToBigInteger();

            //Ensure that message is not too long.
            if (m + 1 >= _curve.Prime)
                throw new ArgumentException("Message too large to be encrypted. Must be smaller than p (" + _curve.Prime + ").", "message");

            return IntegerEncoding(m, _k);
        }

        Point IntegerEncoding(BigInteger m_value, BigInteger k_value) {
            var m = new FiniteFieldElement(m_value, _curve.Prime);
            var k = new FiniteFieldElement(k_value, _curve.Prime);
            var a = new FiniteFieldElement(_curve.A, _curve.Prime);
            var b = new FiniteFieldElement(_curve.B, _curve.Prime);

            //cache m*k
            var m_times_k = m * k;

            FiniteFieldElement x;
            FiniteFieldElement y;
            for (BigInteger j_value = BigInteger.Zero; j_value < k_value; j_value++)
            {
                var j = new FiniteFieldElement(j_value, _curve.Prime);
                x = (m_times_k + j);

                //z = x^3+ax+b
                var z = (x^3) + (a*x) + b;

                //sqrt mod p
                if (z.TrySqrt(out y))
                {
                    return new WeierstrassCurvePoint(x.Value, y.Value, _curve);
                }
            }

            throw new ArgumentException("Could not encode m as point on curve. Probablistic mapping failed.", "m_value");
        }

        public Plaintext DecodeMessage(Point messagePoint)
        {
            //m = floor(x/k)
            var m = messagePoint.X.Value / _k;

            return new Plaintext(m.ToByteArray());
        }
    }
}
