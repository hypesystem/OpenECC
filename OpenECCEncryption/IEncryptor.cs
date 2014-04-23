using System;
using OpenECC.Encryption.Core;

namespace OpenECC.Encryption
{
    public interface IEncryptor
    {
        Ciphertext Encrypt(PublicKey pub, Plaintext m);
        Plaintext Decrypt(PrivateKey priv, Ciphertext c);
        KeyPair GenerateKeyPair();
    }
}
