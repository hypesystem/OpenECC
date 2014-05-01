using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenECC;
using OpenECC.Encryption;
using OpenECC.Encryption.Core;
using System.Numerics;

namespace OpenECCTest.Encryption
{
    [TestClass]
    public class ElGamalEncryptorTest
    {
        [TestMethod]
        public void TestElGamalEncryptDecrypt()
        {
            var curve = CurveFactory.secp256k1;
            var encryptor = new ElGamalEncryptor(curve);
            var keys = encryptor.GenerateKeyPair();
            throw new ArgumentException("keypar gen done");

            var m = new Plaintext("Hello, World");

            var c = encryptor.Encrypt(keys.PublicKey, m);

            var m2 = encryptor.Decrypt(keys.PrivateKey, c);

            Assert.AreEqual(m, m2);
        }
    }
}
