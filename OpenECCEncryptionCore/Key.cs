using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenECC.Encryption.Core
{
    public class Key : ConvertableByteArray
    {
        public Key(string content) : base(content) { }
        public Key(byte[] bytes) : base(bytes) { }
    }
}
