using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenECC.Encryption.Core
{
    public class Mac : ConvertableByteArray
    {
        public Mac(string content) : base(content) { }
        public Mac(byte[] bytes) : base(bytes) { }
    }
}
