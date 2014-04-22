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
            var q = pub.Point;

            var k = SelectK(_parameters.N);

            var R = _parameters.P * k;
            var Z = q * k * _parameters.Cofactor;

            while (Z == _parameters.Curve.Infinity)
            {
                k = SelectK(_parameters.N, R);

                R = _parameters.P * k;
                Z = q * k * _parameters.Cofactor;
            }

            Key k1;
            HmacKey k2;
            DeriveKeys(Z.X.Value, R, out k1, out k2);

            var iv = new IV(new BigInteger(0));

            var aes = new RijndaelSymmetricEncryptor(k1, iv); //TODO: IV!
            throw new NotImplementedException();
            var c = aes.Encrypt(m);

            var hmac = new HmacGenerator(k2);
            var t = hmac.Mac(c.ToString());
            return new EciesCiphertext(R, c, t);
        }

        private BigInteger SelectK(BigInteger n)
        {
            throw new NotImplementedException();
        }

        private BigInteger SelectK(BigInteger n, Point p)
        {
            throw new NotImplementedException();
        }

        private void DeriveKeys(BigInteger z_x, Point r, out Key k1, out HmacKey k2)
        {
            throw new NotImplementedException();
        }

        public Plaintext Decrypt(PrivateKey d, Ciphertext c)
        {
            throw new NotImplementedException();
        }
    }
}
