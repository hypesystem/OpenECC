using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenECC.Encryption.Core;

namespace OpenECC.Encryption.SymmetricWrappers
{
    public interface ISymmetricEncryptor
    {
        Ciphertext Encrypt(Plaintext m);
        Plaintext Decrypt(Ciphertext c);
    }
}
