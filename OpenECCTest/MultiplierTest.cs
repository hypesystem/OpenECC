using System;
using OpenECC;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenECCTest
{
    [TestClass]
    public class MultiplierTest
    {
        WeierstrassCurvePoint p;

        [TestInitialize]
        public void SetUp()
        {
            var curve = new WeierstrassCurve(new BigInteger(4), new BigInteger(20), new BigInteger(29));
            p = new WeierstrassCurvePoint(new BigInteger(5), new BigInteger(22), curve);
        }

        #region naive

        [TestMethod]
        public void NaiveMultiplierOneTest()
        {
            WeierstrassCurvePoint.Multiplier = new NaivePointMultiplier();
            Assert.AreEqual(p, p * 1);
        }

        [TestMethod]
        public void NaiveMultiplierTwoTest()
        {
            WeierstrassCurvePoint.Multiplier = new NaivePointMultiplier();
            Assert.AreEqual(p + p, p * 2);
        }

        [TestMethod]
        public void NaiveMultiplierFourTest()
        {
            WeierstrassCurvePoint.Multiplier = new NaivePointMultiplier();
            Assert.AreEqual(p + p + p + p, p * 4);
        }

        [TestMethod]
        public void NaiveMultiplierTenTest()
        {
            WeierstrassCurvePoint.Multiplier = new NaivePointMultiplier();
            Assert.AreEqual(p + p + p + p + p + p + p + p + p + p, p * 10);
        }

        #endregion

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
            Assert.AreEqual(p + p, p * 2);
        }

        [TestMethod]
        public void DoubleAndAddMultiplierFourTest()
        {
            WeierstrassCurvePoint.Multiplier = new DoubleAndAddPointMultiplier();
            Assert.AreEqual(p + p + p + p, p * 4);
        }

        [TestMethod]
        public void DoubleAndAddMultiplierTenTest()
        {
            WeierstrassCurvePoint.Multiplier = new DoubleAndAddPointMultiplier();
            Assert.AreEqual(p + p + p + p + p + p + p + p + p + p, p * 10);
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
            Assert.AreEqual(p + p, p * 2);
        }

        [TestMethod]
        public void FpNafMultiplierFourTest()
        {
            WeierstrassCurvePoint.Multiplier = new FpNafMultiplier();
            Assert.AreEqual(p + p + p + p, p * 4);
        }

        [TestMethod]
        public void FpNafMultiplierTenTest()
        {
            WeierstrassCurvePoint.Multiplier = new FpNafMultiplier();
            Assert.AreEqual(p + p + p + p + p + p + p + p + p + p, p * 10);
        }

        #endregion

        #region wnaf

        [TestMethod]
        public void WNafPointMultiplierOneTest()
        {
            WeierstrassCurvePoint.Multiplier = new WNafPointMultiplier();
            Assert.AreEqual(p, p * 1);
        }

        [TestMethod]
        public void WNafPointMultiplierTwoTest()
        {
            WeierstrassCurvePoint.Multiplier = new WNafPointMultiplier();
            Assert.AreEqual(p + p, p * 2);
        }

        [TestMethod]
        public void WNafPointMultiplierFourTest()
        {
            WeierstrassCurvePoint.Multiplier = new WNafPointMultiplier();
            Assert.AreEqual(p + p + p + p, p * 4);
        }

        [TestMethod]
        public void WNafPointMultiplierTenTest()
        {
            WeierstrassCurvePoint.Multiplier = new WNafPointMultiplier();
            Assert.AreEqual(p + p + p + p + p + p + p + p + p + p, p * 10);
        }

        #endregion
    }
}
