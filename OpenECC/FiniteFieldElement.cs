﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Math.EC;
using System.Numerics;

namespace OpenECC
{
    /// <summary>
    /// Wrapper around BouncyCastle's FpFieldElement.
    /// </summary>
    public class FiniteFieldElement
    {
        private FpFieldElement _field;

        public FiniteFieldElement(BigInteger x, BigInteger q)
        {
            Org.BouncyCastle.Math.BigInteger bouncy_q = ConvertCSharpToBouncyCastleBigInteger(q);
            Org.BouncyCastle.Math.BigInteger bouncy_x = ConvertCSharpToBouncyCastleBigInteger(x);
            _field = new FpFieldElement(bouncy_q, bouncy_x);
        }

        FiniteFieldElement(FpFieldElement innerField) {
            _field = innerField;
        }

        public BigInteger Q
        {
            get
            {
                return ConvertBouncyCastleToCSharpBigInteger(_field.Q);
            }
        }

        public BigInteger X
        {
            get
            {
                return ConvertBouncyCastleToCSharpBigInteger(_field.ToBigInteger());
            }
        }

        #region BigIntegerConversion
        private BigInteger ConvertBouncyCastleToCSharpBigInteger(Org.BouncyCastle.Math.BigInteger i)
        {
            throw new NotImplementedException();
        }

        private Org.BouncyCastle.Math.BigInteger ConvertCSharpToBouncyCastleBigInteger(BigInteger i)
        {
            throw new NotImplementedException();
        }
        #endregion

        public FiniteFieldElement Negate()
        {
            return new FiniteFieldElement(_field.Negate() as FpFieldElement);
        }

        #region operators

        public static FiniteFieldElement operator -(FiniteFieldElement f)
        {
            return f.Negate();
        }

        #endregion
    }
}
