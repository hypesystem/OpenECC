using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using OpenECC.Encryption.Core;

namespace OpenECC.Encryption.SymmetricWrappers
{
    public class HmacGenerator
    {
        HMAC algorithm;
        System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();

        public HmacGenerator(Key k)
        {
            algorithm = new HMACSHA1(k.ToByteArray());
        }

        public Mac Mac(string m)
        {
            var bytes = algorithm.ComputeHash(encoding.GetBytes(m));
            return new Mac(bytes);
        }
    }
}
