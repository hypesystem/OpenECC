using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenECCTest.BouncyCastleComparison
{
    [TestClass]
    public class ArithmeticTest
    {
        OpenECC.ICurve OpenECCSimpleCurve, OpenECCSecp256k1;
        Org.BouncyCastle.Math.EC.ECCurve BCSimpleCurve, BCSecp256k1;

        [TestInitialize]
        public void SetUpSimpleCurve()
        {
            OpenECCSimpleCurve = new OpenECC.WeierstrassCurve(new System.Numerics.BigInteger(3), new System.Numerics.BigInteger(6), new System.Numerics.BigInteger(7919));
            BCSimpleCurve = new Org.BouncyCastle.Math.EC.FpCurve(new Org.BouncyCastle.Math.BigInteger("3"), new Org.BouncyCastle.Math.BigInteger("6"), new Org.BouncyCastle.Math.BigInteger("7919"));
        }
        
        /*[TestInitialize]
        public void SetUpSecp256k1()
        {
            OpenECCSecp256k1 = OpenECC.CurveFactory.secp256k1;
            BCSecp256k1 = new Org.BouncyCastle.Math.EC.FpCurve( ... );
        }*/

        [TestMethod]
        public void TestSimpleCurveAddition()
        {

        }
    }
}
