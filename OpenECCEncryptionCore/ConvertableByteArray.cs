using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace OpenECC.Encryption.Core
{
    public abstract class ConvertableByteArray
    {
        private byte[] _bytes;
        private static System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();

        public ConvertableByteArray(string str) : this(encoding.GetBytes(str)) { }

        public ConvertableByteArray(params byte[][] bytes)
        {
            //TODO: This is not the best way to convert to byte array...
            _bytes = ConcatByteArrays(bytes);
        }

        byte[] ConcatByteArrays(IEnumerable<byte[]> arrs)
        {
            IEnumerable<byte> result = new byte[0];
            foreach (var arr in arrs)
            {
                result = result.Concat(arr);
            }
            return result.ToArray();
        }

        public override string ToString()
        {
            return Encoding.ASCII.GetString(_bytes);
        }

        public byte[] ToByteArray()
        {
            return _bytes;
        }

        public BigInteger ToBigInteger()
        {
            return new BigInteger(ToByteArray());
        }

        public override bool Equals(object obj)
        {
            if (obj is ConvertableByteArray)
            {
                var cba = obj as ConvertableByteArray;
                return ToByteArray().SequenceEqual(cba.ToByteArray());
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ToByteArray().GetHashCode();
        }
    }
}
