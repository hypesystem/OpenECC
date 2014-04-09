using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace OpenECC.Encryption
{
    public class PrivateKey
    {
        private readonly BigInteger _number;

        public PrivateKey(BigInteger number)
        {
            _number = number;
        }

        public BigInteger Value
        {
            get
            {
                return _number;
            }
        }
    }
}
