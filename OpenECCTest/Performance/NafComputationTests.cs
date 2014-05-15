using System;
using System.Numerics;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenECC;

namespace OpenECCTest.Performance
{
    [TestClass]
    public class NafComputationTests
    {
        [TestMethod]
        public void TestNafComputation()
        {
            var multiplier = new NafMultiplier();

            int sum_time = 0;

            for (int i = 0; i < 1000; i++)
            {
                var val = new BigInteger(i * 121412);

                var timer = Stopwatch.StartNew();
                multiplier.ComputeNaf(val).ToArray();
                timer.Stop();
                sum_time += timer.Elapsed.Milliseconds;
            }

            throw new AssertFailedException("Runtime " + (sum_time / 1000d) + "ms (1000 in "+sum_time+"ms)");
        }

        [TestMethod]
        public void TestWNafComputationW2()
        {
            var multiplier = new WNafMultiplier(2);

            int sum_time = 0;

            for (int i = 0; i < 1000; i++)
            {
                var val = new BigInteger(i * 121412);

                var timer = Stopwatch.StartNew();
                multiplier.ComputeWNaf(val).ToArray();
                timer.Stop();
                sum_time += timer.Elapsed.Milliseconds;
            }

            throw new AssertFailedException("Runtime " + (sum_time / 1000d) + "ms (1000 in " + sum_time + "ms)");
        }

        [TestMethod]
        public void TestWNafComputationW3()
        {
            var multiplier = new WNafMultiplier(3);

            int sum_time = 0;

            for (int i = 0; i < 1000; i++)
            {
                var val = new BigInteger(i * 121412);

                var timer = Stopwatch.StartNew();
                multiplier.ComputeWNaf(val).ToArray();
                timer.Stop();
                sum_time += timer.Elapsed.Milliseconds;
            }

            throw new AssertFailedException("Runtime " + (sum_time / 1000d) + "ms (1000 in " + sum_time + "ms)");
        }

        [TestMethod]
        public void TestWNafComputationW4()
        {
            var multiplier = new WNafMultiplier(4);

            int sum_time = 0;

            for (int i = 0; i < 1000; i++)
            {
                var val = new BigInteger(i * 121412);

                var timer = Stopwatch.StartNew();
                multiplier.ComputeWNaf(val).ToArray();
                timer.Stop();
                sum_time += timer.Elapsed.Milliseconds;
            }

            throw new AssertFailedException("Runtime " + (sum_time / 1000d) + "ms (1000 in " + sum_time + "ms)");
        }

        [TestMethod]
        public void TestWNafComputationW5()
        {
            var multiplier = new WNafMultiplier(5);

            int sum_time = 0;

            for (int i = 0; i < 1000; i++)
            {
                var val = new BigInteger(i * 121412);

                var timer = Stopwatch.StartNew();
                multiplier.ComputeWNaf(val).ToArray();
                timer.Stop();
                sum_time += timer.Elapsed.Milliseconds;
            }

            throw new AssertFailedException("Runtime " + (sum_time / 1000d) + "ms (1000 in " + sum_time + "ms)");
        }
    }
}
