using System;
using System.Linq;
using System.Numerics;

namespace OpenECC
{
    public class DoubleAndAddPointMultiplierAlternate : IPointMultiplier
    {
        public Point Multiply(Point p, BigInteger x)
        {
            var x_bits = ToBitArray(x);
            var x_bits_length = x_bits.LongLength;
            var result = p.Curve.Infinity;

            for (long i = 0; i < x_bits_length; i++)
            {
                if (x_bits[i]) result = result + p;
                p = p + p;
            }

            return result;
        }

        bool[] ToBitArray(BigInteger x)
        {
            return ToBitArray(x.ToByteArray());
        }

        bool[] ToBitArray(byte[] bytes)
        {
            var max_bits = bytes.Length * 8;
            var bits = new bool[max_bits];
            for (int i = 0; i < max_bits; i++)
            {
                bits[i] = ((bytes[i / 8] >> (i % 8)) & 1) > 0;
            }

            //Ensure that length is length from most significant bit to end.
            //Ie. in bitestring 00101010 length is 6. In 00001100 01101010 length is 8+4=12
            for (int i = max_bits - 1; i >= 0; i--)
            {
                if (bits[i])
                {
                    bits = bits.Take(i + 1).ToArray();
                    break;
                }
            }

            return bits;
        }
    }
}
