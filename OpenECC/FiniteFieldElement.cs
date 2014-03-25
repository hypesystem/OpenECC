using System;
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

        private FiniteFieldElement(FpFieldElement innerField) {
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
            return BigInteger.Parse(i.ToString());
        }

        private Org.BouncyCastle.Math.BigInteger ConvertCSharpToBouncyCastleBigInteger(BigInteger i)
        {
            return new Org.BouncyCastle.Math.BigInteger(i.ToString());
        }
        #endregion

        #region Arithmetic Wrapping

        public FiniteFieldElement Negate()
        {
            return new FiniteFieldElement(_field.Negate() as FpFieldElement);
        }

        public FiniteFieldElement Subtract(FiniteFieldElement f2)
        {
            var resultingElement = _field.Subtract(f2._field) as FpFieldElement;
            return new FiniteFieldElement(resultingElement);
        }

        public FiniteFieldElement Add(FiniteFieldElement f2)
        {
            var resultingElement = _field.Add(f2._field) as FpFieldElement;
            return new FiniteFieldElement(resultingElement);
        }

        public FiniteFieldElement DivideBy(FiniteFieldElement f2)
        {
            var resultingElement = _field.Divide(f2._field) as FpFieldElement;
            return new FiniteFieldElement(resultingElement);
        }

        public FiniteFieldElement Multiply(int x)
        {
            var xAsFiniteFieldElement = new FiniteFieldElement(new BigInteger(x), Q);
            return Multiply(xAsFiniteFieldElement);
        }

        public FiniteFieldElement Multiply(FiniteFieldElement f2)
        {
            var resultingElement = _field.Multiply(f2._field) as FpFieldElement;
            return new FiniteFieldElement(resultingElement);
        }

        public FiniteFieldElement Exponentiate(int n)
        {
            ECFieldElement result = _field;
            for (int i = 1; i < n; i++)
            {
                result = result.Multiply(_field);
            }
            return new FiniteFieldElement(result as FpFieldElement);
        }

        #endregion

        #region operators

        public static FiniteFieldElement operator -(FiniteFieldElement f)
        {
            return f.Negate();
        }

        public static FiniteFieldElement operator -(FiniteFieldElement f1, FiniteFieldElement f2)
        {
            return f1.Subtract(f2);
        }

        public static FiniteFieldElement operator +(FiniteFieldElement f1, FiniteFieldElement f2)
        {
            return f1.Add(f2);
        }

        public static FiniteFieldElement operator /(FiniteFieldElement f1, FiniteFieldElement f2)
        {
            return f1.DivideBy(f2);
        }

        public static FiniteFieldElement operator *(int x, FiniteFieldElement f)
        {
            return f.Multiply(x);
        }

        public static FiniteFieldElement operator *(FiniteFieldElement f1, FiniteFieldElement f2)
        {
            return f1.Multiply(f2);
        }

        public static FiniteFieldElement operator ^(FiniteFieldElement f, int n)
        {
            return f.Exponentiate(n);
        }

        #endregion
    }
}
