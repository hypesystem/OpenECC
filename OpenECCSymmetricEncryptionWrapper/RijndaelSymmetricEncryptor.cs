using System;
using System.IO;
using System.Security.Cryptography;
using OpenECC.Encryption.Core;

namespace OpenECC.Encryption.SymmetricWrappers
{
    /// <summary>
    /// Adapted code from http://msdn.microsoft.com/en-us/magazine/cc164055.aspx
    /// via http://stackoverflow.com/questions/273452/using-aes-encryption-in-c-sharp
    /// </summary>
    public class RijndaelSymmetricEncryptor : ISymmetricEncryptor
    {
        private RijndaelManaged rijndael;

        public RijndaelSymmetricEncryptor(Key k, IV iv)
        {
            rijndael = new RijndaelManaged();

            rijndael.IV = iv.ToByteArray();
            rijndael.Key = k.ToByteArray();
        }

        public Ciphertext Encrypt(Plaintext m)
        {
            ICryptoTransform encryptor = rijndael.CreateEncryptor(rijndael.Key, rijndael.IV);
            byte[] bytes;

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {

                        //Write all data to the stream.
                        swEncrypt.Write(m.ToString());
                    }
                    bytes = msEncrypt.ToArray();
                }
            }
            return new Ciphertext(bytes);
        }

        public Plaintext Decrypt(Ciphertext c)
        {
            ICryptoTransform decryptor = rijndael.CreateDecryptor(rijndael.Key, rijndael.IV);
            string plaintext;

            using (MemoryStream msDecrypt = new MemoryStream(c.ToByteArray()))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {

                        //Read all data from the stream
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
            return new Plaintext(plaintext);
        }
    }
}
