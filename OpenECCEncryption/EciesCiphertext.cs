using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenECC.Encryption.SymmetricWrappers;
using OpenECC.Encryption.Core;

namespace OpenECC.Encryption
{
    public class EciesCiphertext : ICiphertext
    {
        public EciesCiphertext(Point r, ICiphertext c, Mac mac)
        {
            throw new NotImplementedException();
        }
    }
}
