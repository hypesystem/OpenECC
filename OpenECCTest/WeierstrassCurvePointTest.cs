using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenECC;
using System.Numerics;

namespace OpenECCTest
{
    [TestClass]
    public class WeierstrassCurvePointTest
    {
        WeierstrassCurvePoint p, r, q;

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
    }
}
