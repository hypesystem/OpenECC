﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenECC.Encryption.Core;

namespace OpenECC.Encryption.SymmetricWrappers
{
    public interface IMacGenerator
    {
        IMac Mac(IKey k, ICiphertext c);
    }
}