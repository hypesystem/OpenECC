using System;
using System.Linq;
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

                if (i >= e_bits.Length ? h_bits[i] : h_bits[i] != e_bits[i])
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
