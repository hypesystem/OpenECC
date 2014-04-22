using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenECC.Encryption.SymmetricWrappers
{
    public interface IKey
    {
        byte[] ToByteArray();
    }
}
