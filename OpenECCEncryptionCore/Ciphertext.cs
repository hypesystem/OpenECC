using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenECC.Encryption.Core
{
    public class Ciphertext
    {
        private byte[] _bytes;
        private static System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();

        /// <summary>
        /// Convertable between string and byte array. Primary form is byte array.
        /// </summary>
        /// <param name="bytes"></param>
        public Ciphertext(byte[] bytes)
        {
            _bytes = bytes;
        }

        public Ciphertext(string str)
        {
            _bytes = encoding.GetBytes(str);
        }

        public override string ToString()
        {
            throw new NotImplementedException();
            //return BytesToString(_bytes);
        }

        public byte[] ToByteArray()
        {
            return _bytes;
        }
    }
}
