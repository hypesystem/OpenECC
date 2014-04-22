using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography;
using OpenECC.Encryption.Core;
using OpenECC.Encryption.SymmetricWrappers;
using System.Numerics;

namespace OpenECCTest.Encryption
{
    [TestClass]
    public class RijndaelTest
    {
        Plaintext plaintext;
        Key key;
        IV iv;

        [TestInitialize]
        public void Setup()
        {
            plaintext = new Plaintext("Hello, World. This is a test string.");

            var gen = new RijndaelManaged();
            gen.GenerateIV();
            gen.GenerateKey();

            key = new Key(gen.Key);
            iv = new IV(new BigInteger(gen.IV));
        }

        [TestMethod]
        public void TestEncryptDecrypt()
        {
            RijndaelSymmetricEncryptor enc = new RijndaelSymmetricEncryptor(key, iv);
            var ciphertext = enc.Encrypt(plaintext);

            var plaintext2 = enc.Decrypt(ciphertext);

            Assert.AreEqual(plaintext, plaintext2);
        }
    }
}
