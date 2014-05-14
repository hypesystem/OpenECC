using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenECCTest
{
    public class RuntimeAssert
    {
        public static void LessThan(TimeSpan expected, TimeSpan actual)
        {
            if (actual >= expected)
            {
                throw new AssertFailedException("Actual timespan was greater than or equal to expected. Actual <" + actual + ">, Expected <" + expected + ">");
            }
        }
    }
}
