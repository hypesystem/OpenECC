using System;
using System.Diagnostics;
using OpenECC;
using OpenECC.Encryption;
using OpenECC.Encryption.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;

namespace OpenECCTest.Performance
{
    [TestClass]
    public class FullStackPerformanceTests
    {
        Plaintext _m = new Plaintext("Hello World");

        public static void AssertRuntime(TimeSpan expected, TimeSpan actual, string msg = "")
        {
            if(actual > expected)
                throw new AssertFailedException("Runtime assertion "+msg+" failed. Expected <" + expected + ">. Actual <" + actual + ">");
        }

        [TestCleanup]
        public void CleanUp()
        {
            WeierstrassCurvePoint.Multiplier = WeierstrassCurvePoint.DefaultMultiplier;
        }

        [TestMethod]
        public void TestSecp256k1ElGamalDoubleAndAdd()
        {
            var stopwatch = Stopwatch.StartNew();

            var curve = CurveFactory.secp256k1;
            WeierstrassCurvePoint.Multiplier = new DoubleAndAddPointMultiplier();
            var encoder = new ProbabilisticWeierstrassMessageEncoder(curve, new BigInteger(7));
            var encryptor = new ElGamalEncryptor(curve, encoder);

            stopwatch.Stop();
            var t_setup = stopwatch.Elapsed;
            stopwatch.Restart();

            var keys = encryptor.GenerateKeyPair();

            stopwatch.Stop();
            var t_key_generation = stopwatch.Elapsed;
            stopwatch.Restart();

            var c = encryptor.Encrypt(keys.PublicKey, _m);

            stopwatch.Stop();
            var t_encryption = stopwatch.Elapsed;
            stopwatch.Restart();

            var m2 = encryptor.Decrypt(keys.PrivateKey, c);

            stopwatch.Stop();
            var t_decryption = stopwatch.Elapsed;
            var t_total = t_setup + t_key_generation + t_encryption + t_decryption;

            Assert.AreEqual(_m, m2);

            throw new AssertFailedException("Runtime " + t_total + "(" + t_key_generation + "," + t_encryption + "," + t_decryption + ")");

            AssertRuntime(TimeSpan.FromSeconds(10d), t_key_generation, "key generation");
            AssertRuntime(TimeSpan.FromSeconds(20d), t_decryption, "decryption");
            AssertRuntime(TimeSpan.FromSeconds(20d), t_encryption, "encryption");
        }

        [TestMethod]
        public void TestSecp256k1ElGamalFpNaf()
        {
            var stopwatch = Stopwatch.StartNew();

            var curve = CurveFactory.secp256k1;
            WeierstrassCurvePoint.Multiplier = new FpNafMultiplier();
            var encoder = new ProbabilisticWeierstrassMessageEncoder(curve, new BigInteger(7));
            var encryptor = new ElGamalEncryptor(curve, encoder);

            stopwatch.Stop();
            var t_setup = stopwatch.Elapsed;
            stopwatch.Restart();

            var keys = encryptor.GenerateKeyPair();

            stopwatch.Stop();
            var t_key_generation = stopwatch.Elapsed;
            stopwatch.Restart();

            var c = encryptor.Encrypt(keys.PublicKey, _m);

            stopwatch.Stop();
            var t_encryption = stopwatch.Elapsed;
            stopwatch.Restart();

            var m2 = encryptor.Decrypt(keys.PrivateKey, c);

            stopwatch.Stop();
            var t_decryption = stopwatch.Elapsed;
            var t_total = t_setup + t_key_generation + t_encryption + t_decryption;

            Assert.AreEqual(_m, m2);

            throw new AssertFailedException("Runtime " + t_total + "(" + t_key_generation + "," + t_encryption + "," + t_decryption + ")");

            AssertRuntime(TimeSpan.FromSeconds(10d), t_key_generation, "key generation");
            AssertRuntime(TimeSpan.FromSeconds(20d), t_decryption, "decryption");
            AssertRuntime(TimeSpan.FromSeconds(20d), t_encryption, "encryption");
        }
    }
}
