﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenECC.Encryption.Core;

namespace OpenECC.Encryption.SymmetricWrappers
{
    public interface ISymmetricEncryptor
    {
        ICiphertext Encrypt(IKey k, IPlaintext m);
        IPlaintext Decrypt(IKey k, ICiphertext c);
    }
}