using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenECCTest.BouncyCastleComparison
{
    [TestClass]
    public class Secp256k1ArithmeticTest
    {
        private OpenECC.WeierstrassCurve OpenECCSecp256k1;
        private OpenECC.Point OpenECCGenerator, OpenECCPoint1, OpenECCPoint2;
        private Org.BouncyCastle.Math.EC.ECCurve BCSecp256k1;
        private Org.BouncyCastle.Math.EC.ECPoint BCGenerator, BCPoint1, BCPoint2;

        [TestInitialize]
        public void SetUpSecp256k1()
        {
            //Set up OpenECC Curve
            OpenECCSecp256k1 = OpenECC.CurveFactory.secp256k1;
            OpenECCGenerator = OpenECCSecp256k1.Generator;
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

        [TestMethod]
        public void TestSecp256k1AddInfinity()
        {
            //Document that BouncyCastle does the right thing.
            var bc_point = BCPoint1.Add(BCSecp256k1.Infinity);
            Assert.AreEqual(BCPoint1, bc_point);

            var oecc_point = OpenECCPoint1 + OpenECCSecp256k1.Infinity;
            Assert.AreEqual(OpenECCPoint1, oecc_point);
        }

        [TestMethod]
        public void TestSecp256k1Addition()
        {
            var bc_point = BCPoint1.Add(BCPoint2);
            var oecc_point = OpenECCPoint1 + OpenECCPoint2;

            AssertPointsAreEqual(bc_point, oecc_point);
        }

        [TestMethod]
        public void TestSecp256k1Doubling()
        {
            var bc_point = BCPoint1.Add(BCPoint1);
            var oecc_point = OpenECCPoint1 + OpenECCPoint1;

            AssertPointsAreEqual(bc_point, oecc_point);
        }

        [TestMethod]
        public void TestSecp256k1Subtraction()
        {
            var bc_point = BCPoint1.Subtract(BCPoint2);
            var oecc_point = OpenECCPoint1 - OpenECCPoint2;

            AssertPointsAreEqual(bc_point, oecc_point);
        }
    }
}
