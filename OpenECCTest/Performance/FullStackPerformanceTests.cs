using System;
using System.Diagnostics;
using System.Linq;
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
        int num_runs = 1;
        Plaintext _m = new Plaintext("Hello World");

        [TestCleanup]
        public void CleanUp()
        {
            WeierstrassCurvePoint.Multiplier = WeierstrassCurvePoint.DefaultMultiplier;
        }

        [TestMethod]
        public void TestSecp256k1ElGamalDoubleAndAdd()
        {
            TimeSpan[] setup_times = new TimeSpan[num_runs];
            TimeSpan[] key_generation_times = new TimeSpan[num_runs];
            TimeSpan[] encryption_times = new TimeSpan[num_runs];
            TimeSpan[] decryption_times = new TimeSpan[num_runs];

            for (int i = 0; i < num_runs; i++)
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

                setup_times[i] = t_setup;
                key_generation_times[i] = t_key_generation;
                encryption_times[i] = t_encryption;
                decryption_times[i] = t_decryption;
            }

            var setup_avg = setup_times.Sum(x => x.Milliseconds) / (double)num_runs;
            var key_generation_avg = key_generation_times.Sum(x => x.Milliseconds) / (double)num_runs;
            var encryption_avg = encryption_times.Sum(x => x.Milliseconds) / (double)num_runs;
            var decryption_avg = decryption_times.Sum(x => x.Milliseconds) / (double)num_runs;

            var total_avg = setup_avg + key_generation_avg + encryption_avg + decryption_avg;

            throw new AssertFailedException("Runtime " + total_avg + "(" + key_generation_avg + "," + encryption_avg + "," + decryption_avg + ")");
        }

        [TestMethod]
        public void TestSecp256k1ElGamalDoubleAndAddAlternate()
        {
            TimeSpan[] setup_times = new TimeSpan[num_runs];
            TimeSpan[] key_generation_times = new TimeSpan[num_runs];
            TimeSpan[] encryption_times = new TimeSpan[num_runs];
            TimeSpan[] decryption_times = new TimeSpan[num_runs];

            for (int i = 0; i < num_runs; i++)
            {
                var stopwatch = Stopwatch.StartNew();

                var curve = CurveFactory.secp256k1;
                WeierstrassCurvePoint.Multiplier = new DoubleAndAddPointMultiplierAlternate();
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

                setup_times[i] = t_setup;
                key_generation_times[i] = t_key_generation;
                encryption_times[i] = t_encryption;
                decryption_times[i] = t_decryption;
            }

            var setup_avg = setup_times.Sum(x => x.Milliseconds) / (double)num_runs;
            var key_generation_avg = key_generation_times.Sum(x => x.Milliseconds) / (double)num_runs;
            var encryption_avg = encryption_times.Sum(x => x.Milliseconds) / (double)num_runs;
            var decryption_avg = decryption_times.Sum(x => x.Milliseconds) / (double)num_runs;

            var total_avg = setup_avg + key_generation_avg + encryption_avg + decryption_avg;

            throw new AssertFailedException("Runtime " + total_avg + "(" + key_generation_avg + "," + encryption_avg + "," + decryption_avg + ")");
        }

        [TestMethod]
        public void TestSecp256k1ElGamalNaf()
        {
            TimeSpan[] setup_times = new TimeSpan[num_runs];
            TimeSpan[] key_generation_times = new TimeSpan[num_runs];
            TimeSpan[] encryption_times = new TimeSpan[num_runs];
            TimeSpan[] decryption_times = new TimeSpan[num_runs];

            for (int i = 0; i < num_runs; i++)
            {

                var stopwatch = Stopwatch.StartNew();

                var curve = CurveFactory.secp256k1;
                WeierstrassCurvePoint.Multiplier = new NafMultiplier();
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

                setup_times[i] = t_setup;
                key_generation_times[i] = t_key_generation;
                encryption_times[i] = t_encryption;
                decryption_times[i] = t_decryption;
            }

            var setup_avg = setup_times.Sum(x => x.Milliseconds) / (double)num_runs;
            var key_generation_avg = key_generation_times.Sum(x => x.Milliseconds) / (double)num_runs;
            var encryption_avg = encryption_times.Sum(x => x.Milliseconds) / (double)num_runs;
            var decryption_avg = decryption_times.Sum(x => x.Milliseconds) / (double)num_runs;

            var total_avg = setup_avg + key_generation_avg + encryption_avg + decryption_avg;

            throw new AssertFailedException("Runtime " + total_avg + "(" + key_generation_avg + "," + encryption_avg + "," + decryption_avg + ")");
        }

        [TestMethod]
        public void TestSecp256k1ElGamalW2Naf()
        {
            TimeSpan[] setup_times = new TimeSpan[num_runs];
            TimeSpan[] key_generation_times = new TimeSpan[num_runs];
            TimeSpan[] encryption_times = new TimeSpan[num_runs];
            TimeSpan[] decryption_times = new TimeSpan[num_runs];

            for (int i = 0; i < num_runs; i++)
            {

                var stopwatch = Stopwatch.StartNew();

                var curve = CurveFactory.secp256k1;
                WeierstrassCurvePoint.Multiplier = new WNafMultiplier(2);
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

                setup_times[i] = t_setup;
                key_generation_times[i] = t_key_generation;
                encryption_times[i] = t_encryption;
                decryption_times[i] = t_decryption;
            }

            var setup_avg = setup_times.Sum(x => x.Milliseconds) / (double)num_runs;
            var key_generation_avg = key_generation_times.Sum(x => x.Milliseconds) / (double)num_runs;
            var encryption_avg = encryption_times.Sum(x => x.Milliseconds) / (double)num_runs;
            var decryption_avg = decryption_times.Sum(x => x.Milliseconds) / (double)num_runs;

            var total_avg = setup_avg + key_generation_avg + encryption_avg + decryption_avg;

            throw new AssertFailedException("Runtime " + total_avg + "(" + key_generation_avg + "," + encryption_avg + "," + decryption_avg + ")");
        }

        [TestMethod]
        public void TestSecp256k1ElGamalW3Naf()
        {
            TimeSpan[] setup_times = new TimeSpan[num_runs];
            TimeSpan[] key_generation_times = new TimeSpan[num_runs];
            TimeSpan[] encryption_times = new TimeSpan[num_runs];
            TimeSpan[] decryption_times = new TimeSpan[num_runs];

            for (int i = 0; i < num_runs; i++)
            {

                var stopwatch = Stopwatch.StartNew();

                var curve = CurveFactory.secp256k1;
                WeierstrassCurvePoint.Multiplier = new WNafMultiplier(3);
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

                setup_times[i] = t_setup;
                key_generation_times[i] = t_key_generation;
                encryption_times[i] = t_encryption;
                decryption_times[i] = t_decryption;
            }

            var setup_avg = setup_times.Sum(x => x.Milliseconds) / (double)num_runs;
            var key_generation_avg = key_generation_times.Sum(x => x.Milliseconds) / (double)num_runs;
            var encryption_avg = encryption_times.Sum(x => x.Milliseconds) / (double)num_runs;
            var decryption_avg = decryption_times.Sum(x => x.Milliseconds) / (double)num_runs;

            var total_avg = setup_avg + key_generation_avg + encryption_avg + decryption_avg;

            throw new AssertFailedException("Runtime " + total_avg + "(" + key_generation_avg + "," + encryption_avg + "," + decryption_avg + ")");
        }

        [TestMethod]
        public void TestSecp256k1ElGamalW4Naf()
        {
            TimeSpan[] setup_times = new TimeSpan[num_runs];
            TimeSpan[] key_generation_times = new TimeSpan[num_runs];
            TimeSpan[] encryption_times = new TimeSpan[num_runs];
            TimeSpan[] decryption_times = new TimeSpan[num_runs];

            for (int i = 0; i < num_runs; i++)
            {

                var stopwatch = Stopwatch.StartNew();

                var curve = CurveFactory.secp256k1;
                WeierstrassCurvePoint.Multiplier = new WNafMultiplier(4);
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

                setup_times[i] = t_setup;
                key_generation_times[i] = t_key_generation;
                encryption_times[i] = t_encryption;
                decryption_times[i] = t_decryption;
            }

            var setup_avg = setup_times.Sum(x => x.Milliseconds) / (double)num_runs;
            var key_generation_avg = key_generation_times.Sum(x => x.Milliseconds) / (double)num_runs;
            var encryption_avg = encryption_times.Sum(x => x.Milliseconds) / (double)num_runs;
            var decryption_avg = decryption_times.Sum(x => x.Milliseconds) / (double)num_runs;

            var total_avg = setup_avg + key_generation_avg + encryption_avg + decryption_avg;

            throw new AssertFailedException("Runtime " + total_avg + "(" + key_generation_avg + "," + encryption_avg + "," + decryption_avg + ")");
        }

        [TestMethod]
        public void TestSecp256k1ElGamalW5Naf()
        {
            TimeSpan[] setup_times = new TimeSpan[num_runs];
            TimeSpan[] key_generation_times = new TimeSpan[num_runs];
            TimeSpan[] encryption_times = new TimeSpan[num_runs];
            TimeSpan[] decryption_times = new TimeSpan[num_runs];

            for (int i = 0; i < num_runs; i++)
            {

                var stopwatch = Stopwatch.StartNew();

                var curve = CurveFactory.secp256k1;
                WeierstrassCurvePoint.Multiplier = new WNafMultiplier(5);
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

                setup_times[i] = t_setup;
                key_generation_times[i] = t_key_generation;
                encryption_times[i] = t_encryption;
                decryption_times[i] = t_decryption;
            }

            var setup_avg = setup_times.Sum(x => x.Milliseconds) / (double)num_runs;
            var key_generation_avg = key_generation_times.Sum(x => x.Milliseconds) / (double)num_runs;
            var encryption_avg = encryption_times.Sum(x => x.Milliseconds) / (double)num_runs;
            var decryption_avg = decryption_times.Sum(x => x.Milliseconds) / (double)num_runs;

            var total_avg = setup_avg + key_generation_avg + encryption_avg + decryption_avg;

            throw new AssertFailedException("Runtime " + total_avg + "(" + key_generation_avg + "," + encryption_avg + "," + decryption_avg + ")");
        }

        [TestMethod]
        public void TestSecp256k1ElGamalW6Naf()
        {
            TimeSpan[] setup_times = new TimeSpan[num_runs];
            TimeSpan[] key_generation_times = new TimeSpan[num_runs];
            TimeSpan[] encryption_times = new TimeSpan[num_runs];
            TimeSpan[] decryption_times = new TimeSpan[num_runs];

            for (int i = 0; i < num_runs; i++)
            {

                var stopwatch = Stopwatch.StartNew();

                var curve = CurveFactory.secp256k1;
                WeierstrassCurvePoint.Multiplier = new WNafMultiplier(6);
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

                setup_times[i] = t_setup;
                key_generation_times[i] = t_key_generation;
                encryption_times[i] = t_encryption;
                decryption_times[i] = t_decryption;
            }

            var setup_avg = setup_times.Sum(x => x.Milliseconds) / (double)num_runs;
            var key_generation_avg = key_generation_times.Sum(x => x.Milliseconds) / (double)num_runs;
            var encryption_avg = encryption_times.Sum(x => x.Milliseconds) / (double)num_runs;
            var decryption_avg = decryption_times.Sum(x => x.Milliseconds) / (double)num_runs;

            var total_avg = setup_avg + key_generation_avg + encryption_avg + decryption_avg;

            throw new AssertFailedException("Runtime " + total_avg + "(" + key_generation_avg + "," + encryption_avg + "," + decryption_avg + ")");
        }
    }
}
