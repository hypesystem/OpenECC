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

        /// <summary>
        /// Convertable between string and byte array. Primary form is byte array.
        /// </summary>
        /// <param name="bytes"></param>
        public Ciphertext(byte[] bytes)
        {
            _bytes = bytes;
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
