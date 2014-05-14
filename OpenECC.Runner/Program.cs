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
            var str = args[0];

            Console.WriteLine("About to encrypt " + str);
            Console.ReadKey();

            var curve = CurveFactory.secp256k1;
            var encoder = new ProbabilisticWeierstrassMessageEncoder(curve, new BigInteger(7));
            var encryptor = new ElGamalEncryptor(curve, encoder);

            var keys = encryptor.GenerateKeyPair();

            var plaintext = new Plaintext(str);

            var ciphertext = encryptor.Encrypt(keys.PublicKey, plaintext);

            Console.WriteLine("Encrypted as " + ciphertext);
            Console.ReadKey();

            var plaintext2 = encryptor.Decrypt(keys.PrivateKey, ciphertext);

            Console.WriteLine("Decrypted as " + plaintext2);
            Console.ReadKey();
        }
    }
}
