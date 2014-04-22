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
        ICiphertext Encrypt(PublicKey pub, IPlaintext m);
        IPlaintext Decrypt(PrivateKey priv, ICiphertext c);
    }
}
