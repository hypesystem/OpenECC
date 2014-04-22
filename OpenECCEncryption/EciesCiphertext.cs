using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenECC.Encryption.SymmetricWrappers;
using OpenECC.Encryption.Core;

namespace OpenECC.Encryption
{
    public class EciesCiphertext : Ciphertext
    {
        public EciesCiphertext(Point r, Ciphertext c, Mac mac) : base(c.ToByteArray())
        {
            throw new NotImplementedException();
        }
    }
}
