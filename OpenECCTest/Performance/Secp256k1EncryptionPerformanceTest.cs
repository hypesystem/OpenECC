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
            var openecc_setup = Stopwatch.StartNew();
            var openecc_curve = CurveFactory.secp256k1;
            openecc_setup.Stop();

            var bc_setup = Stopwatch.StartNew();
            var bc_stuff = Org.BouncyCastle.Asn1.Sec.SecNamedCurves.GetByName("secp256k1");
            var bc_curve = bc_stuff.Curve;
            bc_setup.Stop();

            throw new NotImplementedException("BC: "+bc_setup.Elapsed+"; OpenECC: "+openecc_setup.Elapsed);
            RuntimeAssert.LessThan(bc_setup.Elapsed, openecc_setup.Elapsed);
        }

        [TestMethod]
        public void CompareSecp256k1KeyGenerationRuntimes()
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

            throw new NotImplementedException("BC: " + bc_keygen_timer.Elapsed + "; OpenECC: " + openecc_keygen_timer.Elapsed);
            RuntimeAssert.LessThan(bc_keygen_timer.Elapsed, openecc_keygen_timer.Elapsed);
        }

        [TestMethod]
        public void CompareSecp256k1EncryptionRuntimes()
        {
            ///
            /// OpenECC
            ///
            var openecc_curve = CurveFactory.secp256k1;
            var openecc_encoder = new ProbabilisticWeierstrassMessageEncoder(openecc_curve, new BigInteger(7));
            var openecc_encryptor = new ElGamalEncryptor(openecc_curve, openecc_encoder);
            var openecc_keys = openecc_encryptor.GenerateKeyPair();
            var openecc_plaintext = new Plaintext("Hello, World.");

            var openecc_encryption_timer = Stopwatch.StartNew();
            var openecc_ciphertext = openecc_encryptor.Encrypt(openecc_keys.PublicKey, openecc_plaintext);
            openecc_encryption_timer.Stop();

            ///
            /// Bouncy Castle
            ///
            var bc_stuff = Org.BouncyCastle.Asn1.Sec.SecNamedCurves.GetByName("secp256k1");
            var bc_keygen = new Org.BouncyCastle.Crypto.Generators.ECKeyPairGenerator();
            var bc_domain_params = new Org.BouncyCastle.Crypto.Parameters.ECDomainParameters(bc_stuff.Curve, bc_stuff.G, bc_stuff.N);
            var bc_random = new Org.BouncyCastle.Security.SecureRandom();
            var bc_keygen_params = new Org.BouncyCastle.Crypto.Parameters.ECKeyGenerationParameters(bc_domain_params, bc_random);
            bc_keygen.Init(bc_keygen_params);
            var bc_keys = bc_keygen.GenerateKeyPair();

            var bc_encryption_timer = Stopwatch.StartNew();
            //TODO: Encryption!
        }

        [TestMethod]
        public void CompareSecp256k1DecryptionRuntimes()
        {

        }
    }
}
