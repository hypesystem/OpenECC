﻿using System;
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
        private ISymmetricEncryptor _enc;
        private IMacGenerator _mac;

        public EciesEncryptor(DomainParameters parameters, ISymmetricEncryptor enc, IMacGenerator mac)
        {
            _parameters = parameters;
            _enc = enc;
            _mac = mac;
        }

        public ICiphertext Encrypt(PublicKey pub, IPlaintext plain)
        {
            var m = plain;

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

            IKey k1, k2;
            DeriveKeys(Z.X.Value, R, out k1, out k2);

            var C = _enc.Encrypt(k1, m);
            var t = _mac.Mac(k2, C);
            return new EciesCiphertext(R, C, t);
        }

        private BigInteger SelectK(BigInteger n)
        {
            throw new NotImplementedException();
        }

        private BigInteger SelectK(BigInteger n, Point p)
        {
            throw new NotImplementedException();
        }

        private void DeriveKeys(BigInteger z_x, Point r, out IKey k1, out IKey k2)
        {
            throw new NotImplementedException();
        }

        public IPlaintext Decrypt(PrivateKey d, ICiphertext c)
        {
            throw new NotImplementedException();
        }
    }
}
