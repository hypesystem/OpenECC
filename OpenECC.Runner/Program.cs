using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenECC;
using OpenECC.Encryption;
using System.Numerics;
using OpenECC.Encryption.Core;

namespace OpenECC.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
            var str = args[0];

            var curve = CurveFactory.secp256k1;
            var encoder = new ProbabilisticWeierstrassMessageEncoder(curve, new BigInteger(7));
            var encryptor = new ElGamalEncryptor(curve, encoder);
            var keys = encryptor.GenerateKeyPair();
            var plaintext = new Plaintext(str);

            var ciphertext = encryptor.Encrypt(keys.PublicKey, plaintext);
            var plaintext2 = encryptor.Decrypt(keys.PrivateKey, ciphertext);
        }
    }
}
