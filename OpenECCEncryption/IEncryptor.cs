using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenECC.Encryption.Core;

namespace OpenECC.Encryption
{
    public interface IEncryptor
    {
        Ciphertext Encrypt(PublicKey pub, Plaintext m);
        Plaintext Decrypt(PrivateKey priv, Ciphertext c);
    }
}
