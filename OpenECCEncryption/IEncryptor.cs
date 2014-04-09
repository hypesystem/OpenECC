using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenECC.Encryption
{
    public interface IEncryptor
    {
        ICiphertext Encrypt(PublicKey pub, IPlaintext m);
        IPlaintext Decrypt(PrivateKey priv, ICiphertext c);
    }
}
