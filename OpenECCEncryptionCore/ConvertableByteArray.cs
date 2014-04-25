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

        public ConvertableByteArray(byte[] bytes)
        {
            _bytes = bytes;
        }

        public ConvertableByteArray(string str)
        {
            _bytes = encoding.GetBytes(str);
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
