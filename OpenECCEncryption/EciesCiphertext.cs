using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenECC.Encryption.SymmetricWrappers;
using OpenECC.Encryption.Core;

namespace OpenECC.Encryption
{
    public class EciesCiphertext : Ciphertext
    {
        private Point _r;
        private Ciphertext _c;
        private Mac _mac;

        public EciesCiphertext(byte[] bytes) : base(bytes)
        {
            //Should parse bytes
            throw new NotImplementedException();
        }

        public EciesCiphertext(Point r, Ciphertext c, Mac mac) : base(c.ToByteArray())
        {
            _r = r;
            _c = c;
            _mac = mac;

            //Should include all info in byte array
            throw new NotImplementedException();
        }

        public Point R
        {
            get
            {
                return _r;
            }
        }

        public Ciphertext Ciphertext
        {
            get
            {
                return _c;
            }
        }

        public Mac Mac
        {
            get
            {
                return _mac;
            }
        }
    }
}
