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

        #region binary_double_and_add

        [TestMethod]
        public void BinaryDoubleAndAddMultiplierOneTest()
        {
            WeierstrassCurvePoint.Multiplier = new BinaryDoubleAndAddPointMultiplier();
            Assert.AreEqual(p, p * 1);
        }

        [TestMethod]
        public void BinaryDoubleAndAddMultiplierTwoTest()
        {
            WeierstrassCurvePoint.Multiplier = new BinaryDoubleAndAddPointMultiplier();
            Assert.AreEqual(p2, p * 2);
        }

        [TestMethod]
        public void BinaryDoubleAndAddMultiplierFourTest()
        {
            WeierstrassCurvePoint.Multiplier = new BinaryDoubleAndAddPointMultiplier();
            Assert.AreEqual(p4, p * 4);
        }

        [TestMethod]
        public void BinaryDoubleAndAddMultiplierTenTest()
        {
            WeierstrassCurvePoint.Multiplier = new BinaryDoubleAndAddPointMultiplier();
            Assert.AreEqual(p10, p * 10);
        }

        [TestMethod]
        public void BinaryDoubleAndAddMultiplierHundredTest()
        {
            WeierstrassCurvePoint.Multiplier = new BinaryDoubleAndAddPointMultiplier();
            Assert.AreEqual(p100, p * 100);
        }

        #endregion

        #region naf

        [TestMethod]
        public void NafMultiplierOneTest()
        {
            WeierstrassCurvePoint.Multiplier = new NafMultiplier();
            Assert.AreEqual(p, p * 1);
        }

        [TestMethod]
        public void NafMultiplierTwoTest()
        {
            WeierstrassCurvePoint.Multiplier = new NafMultiplier();
            Assert.AreEqual(p2, p * 2);
        }

        [TestMethod]
        public void NafMultiplierFourTest()
        {
            WeierstrassCurvePoint.Multiplier = new NafMultiplier();
            Assert.AreEqual(p4, p * 4);
        }

        [TestMethod]
        public void NafMultiplierTenTest()
        {
            WeierstrassCurvePoint.Multiplier = new NafMultiplier();
            Assert.AreEqual(p10, p * 10);
        }

        [TestMethod]
        public void NafMultiplierHundredTest()
        {
            WeierstrassCurvePoint.Multiplier = new NafMultiplier();
            Assert.AreEqual(p100, p * 100);
        }

        #endregion

        #region wnaf

        [TestMethod]
        public void WNafMultiplierOneTest()
        {
            WeierstrassCurvePoint.Multiplier = new WNafMultiplier(5);
            Assert.AreEqual(p, p * 1);
        }

        [TestMethod]
        public void WNafMultiplierTwoTest()
        {
            WeierstrassCurvePoint.Multiplier = new WNafMultiplier(5);
            Assert.AreEqual(p2, p * 2);
        }

        [TestMethod]
        public void WNafMultiplierFourTest()
        {
            WeierstrassCurvePoint.Multiplier = new WNafMultiplier(5);
            Assert.AreEqual(p4, p * 4);
        }

        [TestMethod]
        public void WNafMultiplierTenTest()
        {
            WeierstrassCurvePoint.Multiplier = new WNafMultiplier(5);
            Assert.AreEqual(p10, p * 10);
        }

        [TestMethod]
        public void WNafMultiplierHundredTest()
        {
            WeierstrassCurvePoint.Multiplier = new WNafMultiplier(5);
            Assert.AreEqual(p100, p * 100);
        }

        #endregion


    }
}
