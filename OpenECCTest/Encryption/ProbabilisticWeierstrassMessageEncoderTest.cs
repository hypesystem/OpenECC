using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenECC.Encryption.Core;
using System.Numerics;
using OpenECC;
using OpenECC.Encryption;

namespace OpenECCTest.Encryption
{
    [TestClass]
    public class ProbabilisticWeierstrassMessageEncoderTest
    {
        [TestMethod]
        public void TestEncoderCyclic()
        {
            var curve = CurveFactory.nistp384;
            var encoder = new ProbabilisticWeierstrassMessageEncoder(curve);

            //Encode
            var m = new Plaintext("A");
            BigInteger encoding_key;
            var M = encoder.EncodeMessage(m, out encoding_key);

            //Decode
            var m2 = encoder.DecodeMessage(M, encoding_key);

            Assert.AreEqual(m, m2);
        }
    }
}
