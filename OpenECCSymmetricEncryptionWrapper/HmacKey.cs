using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenECC.Encryption.SymmetricWrappers
{
    public class HmacKey
    {
        private byte[] _bytes;

        public HmacKey(byte[] bytes)
        {
            _bytes = bytes;
        }

        public byte[] ToByteArray()
        {
            return _bytes;
        }
    }
}
