using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenECC;
using System.Numerics;

namespace OpenECCTest
{
    [TestClass]
    public class WeierstrassCurvePointTest
    {
        WeierstrassCurvePoint p;

        [TestInitialize]
        public void SetUp()
        {
            var curve = new WeierstrassCurve(new BigInteger(4), new BigInteger(20), new BigInteger(29));
            p = new WeierstrassCurvePoint(new BigInteger(5), new BigInteger(22), curve);
        }
        
        [TestMethod]
        public void TestNegationCircular()
        {
            var neg_p = -p;
            Assert.AreEqual(p, -neg_p);
        }

        [TestMethod]
        public void TestDoublingSameAsAdding()
        {
            //4P = p + p + p + p
            var result_1 = p + p + p + p;
            
            //4P = 2p + 2p
            var p_dbl = p + p;
            var result_2 = p_dbl + p_dbl;

            Assert.AreEqual(result_1, result_2);
        }

        [TestMethod]
        public void TestMultiplicationSameAsAdding()
        {
            //4P = p + p + p + p
            var result_1 = p + p + p + p;
            
            //4P = 4*p
            var result_2 = p * 4;

            Assert.AreEqual(result_1, result_2);
        }
    }
}
