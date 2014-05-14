using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenECC;
using System.Numerics;

namespace OpenECCTest
{
    [TestClass]
    public class MultiplicationPerformanceTest
    {
        /// <summary>
        /// Method due to Jon Skeet, http://stackoverflow.com/a/969327/1080564
        /// </summary>
        public static TimeSpan Time(Action action)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            action();
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        [TestMethod]
        public void TestSmallMultiplication()
        {
            var curve = TestCurveFactory.SimpleCurve1;
            var point = new WeierstrassCurvePoint(new BigInteger(5), new BigInteger(22), curve);

            var time = Time(() =>
            {
                var point2 = point * new BigInteger(100);
            });

            RuntimeAssert.LessThan(
                expected: new TimeSpan(0,0,1),
                actual: time
            );
        }
    }
}
