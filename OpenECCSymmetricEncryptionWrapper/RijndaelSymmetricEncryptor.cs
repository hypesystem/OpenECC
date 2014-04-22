using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenECC.Encryption.Core;

namespace OpenECC.Encryption.SymmetricWrappers
{
    class RijndaelSymmetricEncryptor : ISymmetricEncryptor
    {
        public ICiphertext Encrypt(IKey k, IPlaintext m)
        {
            if (!(k is RijndaelKey)) throw new ArgumentException("Key must be a Rijndael key!", "key");

            throw new NotImplementedException();
        }

        public IPlaintext Decrypt(IKey k, ICiphertext c)
        {
            throw new NotImplementedException();
        }
    }
}
