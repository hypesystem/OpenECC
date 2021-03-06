﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenECC;

namespace OpenECC.Encryption
{
    public class PublicKey
    {
        private readonly Point _inner_point;

        public PublicKey(Point p)
        {
            _inner_point = p;
        }

        internal Point Point
        {
            get
            {
                return _inner_point;
            }
        }
    }
}
