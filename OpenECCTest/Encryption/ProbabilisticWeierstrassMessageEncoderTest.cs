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
            var encoder = new ProbabilisticWeierstrassMessageEncoder(curve, new BigInteger(7));

            //Encode
            var m = new Plaintext("A");
            BigInteger encoding_key;
            var M = encoder.EncodeMessage(m);

            //Decode
            var m2 = encoder.DecodeMessage(M);

            Assert.AreEqual(m, m2);
        }
    }
}
