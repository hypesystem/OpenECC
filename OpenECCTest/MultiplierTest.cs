using System;
using OpenECC;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenECCTest
{
    [TestClass]
    public class MultiplierTest
    {
        Point p, p2, p4, p10, p100, p10000;

        [TestInitialize]
        public void SetUp()
        {
            var curve = new WeierstrassCurve(new BigInteger(4), new BigInteger(20), new BigInteger(29));
            p = new WeierstrassCurvePoint(new BigInteger(5), new BigInteger(22), curve);
            p2 = p + p;
            p4 = p2 + p2;
            p10 = p4 + p4 + p2;
            p100 = p10 + p10 + p10 + p10 + p10 + p10 + p10 + p10 + p10 + p10;
            var p200 = p100 + p100;
            var p1000 = p200 + p200 + p200 + p200 + p200;
            var p2000 = p1000 + p1000;
            p10000 = p2000 + p2000 + p2000 + p2000 + p2000;
        }

        [TestCleanup]
        public void CleanUp()
        {
            WeierstrassCurvePoint.Multiplier = WeierstrassCurvePoint.DefaultMultiplier;
        }

        #region double_and_add

        [TestMethod]
        public void DoubleAndAddMultiplierOneTest()
        {
            WeierstrassCurvePoint.Multiplier = new DoubleAndAddPointMultiplier();
            Assert.AreEqual(p, p * 1);
        }

        [TestMethod]
        public void DoubleAndAddMultiplierTwoTest()
        {
            WeierstrassCurvePoint.Multiplier = new DoubleAndAddPointMultiplier();
            Assert.AreEqual(p2, p * 2);
        }

        [TestMethod]
        public void DoubleAndAddMultiplierFourTest()
        {
            WeierstrassCurvePoint.Multiplier = new DoubleAndAddPointMultiplier();
            Assert.AreEqual(p4, p * 4);
        }

        [TestMethod]
        public void DoubleAndAddMultiplierTenTest()
        {
            WeierstrassCurvePoint.Multiplier = new DoubleAndAddPointMultiplier();
            Assert.AreEqual(p10, p * 10);
        }

        [TestMethod]
        public void DoubleAndAddMultiplierHundredTest()
        {
            WeierstrassCurvePoint.Multiplier = new DoubleAndAddPointMultiplier();
            Assert.AreEqual(p100, p * 100);
        }

        #endregion

        #region fpnaf

        [TestMethod]
        public void FpNafMultiplierOneTest()
        {
            WeierstrassCurvePoint.Multiplier = new FpNafMultiplier();
            Assert.AreEqual(p, p * 1);
        }

        [TestMethod]
        public void FpNafMultiplierTwoTest()
        {
            WeierstrassCurvePoint.Multiplier = new FpNafMultiplier();
            Assert.AreEqual(p2, p * 2);
        }

        [TestMethod]
        public void FpNafMultiplierFourTest()
        {
            WeierstrassCurvePoint.Multiplier = new FpNafMultiplier();
            Assert.AreEqual(p4, p * 4);
        }

        [TestMethod]
        public void FpNafMultiplierTenTest()
        {
            WeierstrassCurvePoint.Multiplier = new FpNafMultiplier();
            Assert.AreEqual(p10, p * 10);
        }

        [TestMethod]
        public void FpNafMultiplierHundredTest()
        {
            WeierstrassCurvePoint.Multiplier = new FpNafMultiplier();
            Assert.AreEqual(p100, p * 100);
        }

        #endregion

    }
}
