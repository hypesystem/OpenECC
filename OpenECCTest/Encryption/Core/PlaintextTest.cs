using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenECC.Encryption.Core;

namespace OpenECCTest.Encryption.Core
{
    [TestClass]
    public class PlaintextTest
    {
        private Plaintext m;

        [TestInitialize]
        public void Setup()
        {
            m = new Plaintext("Hello, World");
        }

        [TestMethod]
        public void TestPlaintextCyclic()
        {
            var bytes = m.ToByteArray();
            var m2 = new Plaintext(bytes);
            Assert.AreEqual(m, m2);
        }
    }
}
