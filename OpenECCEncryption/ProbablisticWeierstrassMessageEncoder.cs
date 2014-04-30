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
            //Map message to Z_p
            var m = message.ToBigInteger();

            //Select K such that (m+1)K < p
            var k = (m + 1) / _curve.Prime;

            return IntegerEncoding(m, k);
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
            for (BigInteger j_value = BigInteger.Zero; j_value < k.Value; j_value++)
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
            throw new NotImplementedException();
        }
    }
}
