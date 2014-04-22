using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using OpenECC.Encryption.SymmetricWrappers;
using OpenECC.Encryption.Core;

namespace OpenECC.Encryption
{
    public class EciesEncryptor : IEncryptor
    {
        private DomainParameters _parameters;

        public EciesEncryptor(DomainParameters parameters)
        {
            _parameters = parameters;
        }

        public Ciphertext Encrypt(PublicKey pub, Plaintext m)
        {
            var public_key = pub.Point;

            var k = SelectK(_parameters.N);

            var R = _parameters.P * k;
            var Z = public_key * k * _parameters.Cofactor;

            while (Z == _parameters.Curve.Infinity)
            {
                k = SelectK(_parameters.N, R);

                R = _parameters.P * k;
                Z = public_key * k * _parameters.Cofactor;
            }

            Key k1;
            HmacKey k2;
            DeriveKeys(Z.X, R, out k1, out k2);

            var ciphertext = SymmetricEncrypt(k1, m);
            var mac = GenerateMac(k2, ciphertext);

            return new EciesCiphertext(R, ciphertext, mac);
        }

        private Ciphertext SymmetricEncrypt(Key k, Plaintext m)
        {
            var iv = new IV(new BigInteger(0));
            var aes = new RijndaelSymmetricEncryptor(k, iv); //TODO: IV!
            throw new NotImplementedException();
            return aes.Encrypt(m);
        }

        private Mac GenerateMac(HmacKey k, ConvertableByteArray data)
        {
            var hmac = new HmacGenerator(k);
            return hmac.Mac(data.ToString());
        }

        private BigInteger SelectK(BigInteger n)
        {
            //Select k from R[1,n-1]
            throw new NotImplementedException();
        }

        private BigInteger SelectK(BigInteger n, Point p)
        {
            //Select k from R[1,n-1]
            throw new NotImplementedException();
        }

        private void DeriveKeys(FiniteFieldElement z_x, Point R, out Key k1, out HmacKey k2)
        {
            var keybytes = GenerateKeyBytes(z_x, R).ToArray();
            throw new NotImplementedException();
        }

        private IEnumerable<byte> GenerateKeyBytes(FiniteFieldElement z_x, Point R)
        {
            int i = 0;
            //How many key bytes?
            //while limit not reached,
            //    next_hash = hash(z_x,R,i++);
            //    foreach(var byt in next_hash) yield byt;
            throw new NotImplementedException();
        }

        public Plaintext Decrypt(PrivateKey d, Ciphertext c)
        {
            throw new NotImplementedException();
        }
    }
}
