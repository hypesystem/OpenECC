using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenECCTest.BouncyCastleComparison
{
    [TestClass]
    class Secp256k1ArithmeticTest
    {
        private OpenECC.WeierstrassCurve OpenECCSecp256k1;
        private Org.BouncyCastle.Math.EC.FpCurve BCSecp256k1;

        [TestInitialize]
        public void SetUpSecp256k1()
        {
            OpenECCSecp256k1 = OpenECC.CurveFactory.secp256k1;
            /*
            var var2to256 = new Org.BouncyCastle.Math.BigInteger("2")
            var var2to256 = new BigInteger(2) ^ new BigInteger(256);
            var var2to32 = new BigInteger(2) ^ new BigInteger(32);
            var p = var2to256 - var2to32 - new BigInteger(977);
            BCSecp256k1 = new Org.BouncyCastle.Math.EC.FpCurve( ... ); */
        }
    }
}
