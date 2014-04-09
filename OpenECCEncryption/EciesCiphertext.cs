using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenECC.SymmetricEncryptionWrapper;

namespace OpenECC.Encryption
{
    public class EciesCiphertext : ICiphertext
    {
        public EciesCiphertext(Point r, OpenECC.SymmetricEncryptionWrapper.ICiphertext c, IMac mac)
        {
            throw new NotImplementedException();
        }
    }
}
