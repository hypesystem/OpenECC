using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenECC;
using OpenECC.Encryption;
using OpenECC.Encryption.Core;
using System.Numerics;

namespace OpenECCTest.BouncyCastleComparison
{
    [TestClass]
    public class Secp256k1EncryptionPerformanceTest
    {
        [TestMethod]
        public void CompareSecp256k1SetupRuntimes()
        {
            int num_runs = 100;

            long openecc_time_sum = 0L;
            long bc_time_sum = 0L;

            for (int i = 0; i < num_runs; i++)
            {
                var openecc_setup = Stopwatch.StartNew();
                var openecc_curve = CurveFactory.secp256k1;
                openecc_setup.Stop();

                openecc_time_sum += openecc_setup.ElapsedMilliseconds;
            }

            for (int i = 0; i < num_runs; i++)
            {
                var bc_setup = Stopwatch.StartNew();
                var bc_stuff = Org.BouncyCastle.Asn1.Sec.SecNamedCurves.GetByName("secp256k1");
                var bc_curve = bc_stuff.Curve;
                bc_setup.Stop();

                bc_time_sum += bc_setup.ElapsedMilliseconds;
            }

            throw new NotImplementedException("BC: " + (bc_time_sum / (double)num_runs) + "; OpenECC: " + (openecc_time_sum / (double)num_runs));
            //RuntimeAssert.LessThan(bc_setup.Elapsed, openecc_setup.Elapsed);
        }

        [TestMethod]
        public void CompareSecp256k1KeyGenerationRuntimes()
        {
            int num_runs = 100;

            long openecc_time_sum = 0L;
            long bc_time_sum = 0L;

            for (int i = 0; i < num_runs; i++)
            {
                ///
                /// OpenECC
                ///
                var openecc_curve = CurveFactory.secp256k1;

                var openecc_keygen_timer = Stopwatch.StartNew();

                var openecc_encoder = new ProbabilisticWeierstrassMessageEncoder(openecc_curve, new BigInteger(7));
                var openecc_encryptor = new ElGamalEncryptor(openecc_curve, openecc_encoder);
                var openecc_keys = openecc_encryptor.GenerateKeyPair();

                openecc_keygen_timer.Stop();
                openecc_time_sum += openecc_keygen_timer.Elapsed.Milliseconds;
            }

            for (int i = 0; i < num_runs; i++)
            {
                ///
                ///Bouncy Castle
                ///
                var bc_stuff = Org.BouncyCastle.Asn1.Sec.SecNamedCurves.GetByName("secp256k1");

                var bc_keygen_timer = Stopwatch.StartNew();

                var bc_keygen = new Org.BouncyCastle.Crypto.Generators.ECKeyPairGenerator();
                var bc_domain_params = new Org.BouncyCastle.Crypto.Parameters.ECDomainParameters(bc_stuff.Curve, bc_stuff.G, bc_stuff.N);
                var bc_random = new Org.BouncyCastle.Security.SecureRandom();
                var bc_keygen_params = new Org.BouncyCastle.Crypto.Parameters.ECKeyGenerationParameters(bc_domain_params, bc_random);
                bc_keygen.Init(bc_keygen_params);
                var bc_keys = bc_keygen.GenerateKeyPair();

                bc_keygen_timer.Stop();
                bc_time_sum += bc_keygen_timer.Elapsed.Milliseconds;
            }

            throw new NotImplementedException("BC: " + (bc_time_sum/(double)num_runs) + "; OpenECC: " + (openecc_time_sum/(double)num_runs));
            //RuntimeAssert.LessThan(bc_time_sum / (double)num_runs, openecc_time_sum / (double)num_runs);
        }
    }
}
