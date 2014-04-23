using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenECC.Encryption.Core;

namespace OpenECCTest.Encryption.Core
{
    [TestClass]
    public class CiphertextTest
    {
        private Ciphertext c;

        [TestInitialize]
        public void Setup()
        {
            c = new Ciphertext(new byte[] { 72, 69, 73, 76 });
        }

        [TestMethod]
        public void TestCiphertextCyclic()
        {
            var str = c.ToString();
            var c2 = new Ciphertext(str);
            Assert.AreEqual(c, c2);
        }
    }
}
