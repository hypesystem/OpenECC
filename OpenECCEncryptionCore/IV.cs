using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace OpenECC.Encryption.Core
{
    public class IV : ConvertableByteArray
    {
        public IV(BigInteger i) : base(i.ToByteArray()) { }

        public BigInteger ToBigInteger()
        {
            return new BigInteger(ToByteArray());
        }
    }
}
