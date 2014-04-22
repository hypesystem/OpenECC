using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenECC.Encryption.SymmetricWrappers
{
    class RijndaelKey : IKey
    {
        private byte[] _bytes;

        public RijndaelKey(byte[] bytes)
        {
            _bytes = bytes;
        }

        public byte[] ToByteArray()
        {
            return _bytes;
        }
    }
}
