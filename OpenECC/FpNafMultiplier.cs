using System;
using System.Numerics;

namespace OpenECC
{
    /// <summary>
    /// Direct adaption of Bouncy Castle's FpNafMultiplier
    /// </summary>
    public class FpNafMultiplier : IPointMultiplier
    {
        public Point Multiply(Point p, BigInteger e)
        {
            var h = e * 3;
            var h_bits = ToBitArray(h);
            var e_bits = ToBitArray(e);

            var neg = -p;

            var result = p;
            for (int i = h_bits.Length - 2; i > 0; i--)
            {
                result = result + result;

                if (h_bits[i] != e_bits[i])
                {
                    result = result + (h_bits[i] ? p : neg);
                }
            }

            return result;
        }

        bool[] ToBitArray(BigInteger x)
        {
            return ToBitArray(x.ToByteArray());
        }

        bool[] ToBitArray(byte[] bytes)
        {
            var num_bits = bytes.Length * 8;
            var bits = new bool[num_bits];
            for (int i = 0; i < num_bits; i++)
            {
                bits[num_bits - i - 1] = ((bytes[i / 8] >> (i % 8)) & 1) > 0;
            }
            return bits;
        }
    }
}
