using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenECC.Encryption.Core;

namespace OpenECC.SymmetricEncryptionWrapper
{
    public interface ISymmetricEncryptor
    {
        ICiphertext Encrypt(IKey k, IPlaintext m);
    }
}
