﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenECC.SymmetricEncryptionWrapper;
using OpenECC.Encryption.Core;

namespace OpenECC.Encryption
{
    public class EciesCiphertext : ICiphertext
    {
        public EciesCiphertext(Point r, ICiphertext c, IMac mac)
        {
            throw new NotImplementedException();
        }
    }
}
