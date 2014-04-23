using System;
using OpenECC;
using System.Numerics;

namespace OpenECCTest
{
    /// <summary>
    /// Provides small and simple curves to test on.
    /// </summary>
    class TestCurveFactory
    {
        public static WeierstrassCurve SimpleCurve1
        {
            get
            {
                return new WeierstrassCurve(
                    new BigInteger(4),
                    new BigInteger(20),
                    new BigInteger(29)
                );
            }
        }
    }
}
