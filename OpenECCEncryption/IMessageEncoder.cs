using System;
using OpenECC;
using OpenECC.Encryption.Core;
using System.Numerics;

namespace OpenECC.Encryption
{
    public interface IMessageEncoder
    {
        Point EncodeMessage(Plaintext messageText, out BigInteger k);
        Plaintext DecodeMessage(Point messagePoint, BigInteger k);
    }
}
