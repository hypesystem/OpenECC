using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenECC.Point;

namespace OpenECC.Encryption
{
    public class PublicKey : Point
    {
        private Point _inner_point;

        public PublicKey(Point p)
        {
            _inner_point = p;
        }
    }
}
