using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenECCTest.BouncyCastleComparison
{
    [TestClass]
    public class ArithmeticTest
    {
        OpenECC.WeierstrassCurve OpenECCSimpleCurve, OpenECCSecp256k1;
        OpenECC.WeierstrassCurvePoint OpenECCSimplePoint1, OpenECCSimplePoint2, OpenECCSimplePoint3, OpenECCSimplePoint4;
        Org.BouncyCastle.Math.EC.FpCurve BCSimpleCurve, BCSecp256k1;
        Org.BouncyCastle.Math.EC.ECPoint BCSimplePoint1, BCSimplePoint2, BCSimplePoint3, BCSimplePoint4;

        [TestInitialize]
        public void SetUpSimpleCurve()
        {
            OpenECCSimpleCurve = new OpenECC.WeierstrassCurve(new System.Numerics.BigInteger(4), new System.Numerics.BigInteger(20), new System.Numerics.BigInteger(29));
            OpenECCSimplePoint1 = new OpenECC.WeierstrassCurvePoint(new System.Numerics.BigInteger(5), new System.Numerics.BigInteger(22), OpenECCSimpleCurve);
            OpenECCSimplePoint2 = new OpenECC.WeierstrassCurvePoint(new System.Numerics.BigInteger(16), new System.Numerics.BigInteger(27), OpenECCSimpleCurve);
            OpenECCSimplePoint3 = new OpenECC.WeierstrassCurvePoint(new System.Numerics.BigInteger(13), new System.Numerics.BigInteger(6), OpenECCSimpleCurve);
            OpenECCSimplePoint4 = new OpenECC.WeierstrassCurvePoint(new System.Numerics.BigInteger(14), new System.Numerics.BigInteger(6), OpenECCSimpleCurve);

            BCSimpleCurve = new Org.BouncyCastle.Math.EC.FpCurve(new Org.BouncyCastle.Math.BigInteger("29"), new Org.BouncyCastle.Math.BigInteger("4"), new Org.BouncyCastle.Math.BigInteger("20"));
            BCSimplePoint1 = BCSimpleCurve.CreatePoint(new Org.BouncyCastle.Math.BigInteger("5"), new Org.BouncyCastle.Math.BigInteger("22"), false);
            BCSimplePoint2 = BCSimpleCurve.CreatePoint(new Org.BouncyCastle.Math.BigInteger("16"), new Org.BouncyCastle.Math.BigInteger("27"), false);
            BCSimplePoint3 = BCSimpleCurve.CreatePoint(new Org.BouncyCastle.Math.BigInteger("13"), new Org.BouncyCastle.Math.BigInteger("6"), false);
            BCSimplePoint4 = BCSimpleCurve.CreatePoint(new Org.BouncyCastle.Math.BigInteger("14"), new Org.BouncyCastle.Math.BigInteger("6"), false);
        }
        
        /*[TestInitialize]
        public void SetUpSecp256k1()
        {
            OpenECCSecp256k1 = OpenECC.CurveFactory.secp256k1;
            BCSecp256k1 = new Org.BouncyCastle.Math.EC.FpCurve( ... );
        }*/

        [TestMethod]
        public void TestSimpleCurveAddInfinity()
        {
            var bc_point = BCSimplePoint1.Add(BCSimpleCurve.Infinity);
            Assert.AreEqual(BCSimplePoint1, bc_point);

            var oecc_point = OpenECCSimplePoint1 + OpenECCSimpleCurve.Infinity;
            Assert.AreEqual(OpenECCSimplePoint1, oecc_point);
        }

        [TestMethod]
        public void TestSimpleCurveAddition()
        {
            var bc_point = BCSimplePoint1.Add(BCSimplePoint2);
            var oecc_point = OpenECCSimplePoint1 + OpenECCSimplePoint2;

            Assert.AreEqual(bc_point.X.ToBigInteger().ToString(), oecc_point.X.X.ToString());
            Assert.AreEqual(bc_point.Y.ToBigInteger().ToString(), oecc_point.Y.X.ToString());
        }

        [TestMethod]
        public void TestSimpleCurveDoubling()
        {
            var bc_point = BCSimplePoint1.Add(BCSimplePoint1);
            var oecc_point = OpenECCSimplePoint1 + OpenECCSimplePoint1;

            Assert.AreEqual(bc_point.X.ToBigInteger().ToString(), oecc_point.X.X.ToString());
            Assert.AreEqual(bc_point.Y.ToBigInteger().ToString(), oecc_point.Y.X.ToString());
        }
    }
}
