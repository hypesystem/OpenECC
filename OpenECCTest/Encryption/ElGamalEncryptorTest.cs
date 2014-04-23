using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenECC.Encryption;
using OpenECC.Encryption.Core;
using System.Numerics;

namespace OpenECCTest.Encryption
{
    [TestClass]
    public class ElGamalEncryptorTest
    {
        [TestMethod]
        public void TestEncryptDecrypt()
        {
            var enc = new ElGamalEncryptor(TestCurveFactory.SimpleCurve1, BigInteger.Parse("Fail"));

            Plaintext m = new Plaintext("Hello, World. This is a test string.");


            //enc.Encrypt(pub, m);
        }
    }
}
