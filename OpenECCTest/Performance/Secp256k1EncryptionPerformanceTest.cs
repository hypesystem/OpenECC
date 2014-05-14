using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenECC;

namespace OpenECCTest.BouncyCastleComparison
{
    [TestClass]
    public class Secp256k1EncryptionPerformanceTest
    {
        [TestMethod]
        public void CompareSecp256k1SetupRuntimes()
        {
            var openecc_setup = Stopwatch.StartNew();
            var openecc_curve = CurveFactory.secp256k1;
            openecc_setup.Stop();

            var bc_setup = Stopwatch.StartNew();
            var bc_stuff = Org.BouncyCastle.Asn1.Sec.SecNamedCurves.GetByName("secp256k1");
            var bc_curve = bc_stuff.Curve;
            bc_setup.Stop();

            RuntimeAssert.LessThan(bc_setup.Elapsed, openecc_setup.Elapsed);
        }

        [TestMethod]
        public void CompareSecp256k1KeyGenerationRuntimes()
        {

        }

        [TestMethod]
        public void CompareSecp256k1EncryptionRuntimes()
        {

        }

        [TestMethod]
        public void CompareSecp256k1DecryptionRuntimes()
        {

        }
    }
}
