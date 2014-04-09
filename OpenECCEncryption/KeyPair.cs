using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenECC.Encryption
{
    public class KeyPair
    {
        private readonly PublicKey _pub;
        private readonly PrivateKey _priv;

        public KeyPair(PublicKey pub, PrivateKey priv)
        {
            _pub = pub;
            _priv = priv;
        }

        public PublicKey PublicKey {
            get {
                return _pub;
            }
        }
        public PrivateKey PrivateKey {
            get
            {
                return _priv;
            }
        }
    }
}
