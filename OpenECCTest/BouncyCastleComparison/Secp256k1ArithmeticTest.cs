using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenECCTest.BouncyCastleComparison
{
    [TestClass]
    public class Secp256k1ArithmeticTest
    {
        private OpenECC.WeierstrassCurve OpenECCSecp256k1;
        private OpenECC.WeierstrassCurvePoint OpenECCGenerator;
        private Org.BouncyCastle.Math.EC.ECCurve BCSecp256k1;
        private Org.BouncyCastle.Math.EC.ECPoint BCGenerator;

        [TestInitialize]
        public void SetUpSecp256k1()
        {
            OpenECCSecp256k1 = OpenECC.CurveFactory.secp256k1;
            OpenECCGenerator = new OpenECC.WeierstrassCurvePoint(
                System.Numerics.BigInteger.Parse("55066263022277343669578718895168534326250603453777594175500187360389116729240"),
                System.Numerics.BigInteger.Parse("32670510020758816978083085130507043184471273380659243275938904335757337482424"),
                OpenECCSecp256k1);

            var bc_stuff = Org.BouncyCastle.Asn1.Sec.SecNamedCurves.GetByName("secp256k1");
            BCSecp256k1 = bc_stuff.Curve;
            BCGenerator = bc_stuff.G;
        }

        [TestMethod]
        public void TestOpenECCGeneratorIsCorrect()
        {
            Assert.AreEqual(OpenECCGenerator.X.X.ToString(), BCGenerator.X.ToBigInteger().ToString());
            Assert.AreEqual(OpenECCGenerator.Y.X.ToString(), BCGenerator.Y.ToBigInteger().ToString());
        }
    }
}
