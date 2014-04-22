using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenECC.Encryption.SymmetricWrappers
{
    public class Mac
    {
        private byte[] _bytes;

        public Mac(byte[] bytes)
        {
            _bytes = bytes;
        }
    }
}
