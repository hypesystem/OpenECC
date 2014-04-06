using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenECCTest.BouncyCastleComparison
{
    [TestClass]
    public class Secp256k1ArithmeticTest
    {
        private OpenECC.ICurve OpenECCSecp256k1;
        private OpenECC.Point OpenECCGenerator, OpenECCPoint1, OpenECCPoint2;
        private Org.BouncyCastle.Math.EC.ECCurve BCSecp256k1;
        private Org.BouncyCastle.Math.EC.ECPoint BCGenerator, BCPoint1, BCPoint2;

        [TestInitialize]
        public void SetUpSecp256k1()
        {
            //Set up OpenECC Curve
            OpenECCSecp256k1 = OpenECC.CurveFactory.secp256k1;
            OpenECCGenerator = new OpenECC.WeierstrassCurvePoint(
                System.Numerics.BigInteger.Parse("55066263022277343669578718895168534326250603453777594175500187360389116729240"),
                System.Numerics.BigInteger.Parse("32670510020758816978083085130507043184471273380659243275938904335757337482424"),
                OpenECCSecp256k1);
            OpenECCPoint1 = OpenECCGenerator * 3;
            OpenECCPoint2 = OpenECCGenerator * 5;

            //Set up BouncyCastle curve
            var bc_stuff = Org.BouncyCastle.Asn1.Sec.SecNamedCurves.GetByName("secp256k1");
            BCSecp256k1 = bc_stuff.Curve;
            BCGenerator = bc_stuff.G;
            BCPoint1 = BCGenerator.Multiply(new Org.BouncyCastle.Math.BigInteger("3"));
            BCPoint2 = BCGenerator.Multiply(new Org.BouncyCastle.Math.BigInteger("5"));
        }

        [TestMethod]
        public void TestSecp256k1OpenECCGeneratorIsCorrect()
        {
            Assert.AreEqual(OpenECCGenerator.X.Value.ToString(), BCGenerator.X.ToBigInteger().ToString());
            Assert.AreEqual(OpenECCGenerator.Y.Value.ToString(), BCGenerator.Y.ToBigInteger().ToString());
        }

        private void AssertPointsAreEqual(Org.BouncyCastle.Math.EC.ECPoint bcp, OpenECC.Point oeccp)
        {
            Assert.AreEqual(bcp.X.ToBigInteger().ToString(), oeccp.X.Value.ToString());
            Assert.AreEqual(bcp.Y.ToBigInteger().ToString(), oeccp.Y.Value.ToString());
        }

        /// <summary>
        /// This test must pass for any of the other tests to work, as the multiplication is used
        /// to generate points.
        /// </summary>
        [TestMethod]
        public void TestSecp256k1Multiplication()
        {
            AssertPointsAreEqual(BCPoint1, OpenECCPoint1);
            AssertPointsAreEqual(BCPoint2, OpenECCPoint2);
        }
    }
}
