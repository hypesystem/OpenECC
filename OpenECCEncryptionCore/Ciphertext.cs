using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenECC.Encryption.Core
{
    public class Ciphertext : ConvertableByteArray
    {
        public Ciphertext(params byte[][] bytes) : base(bytes) { }
        public Ciphertext(string str) : base(str) { }
    }
}
