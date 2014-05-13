using System;
using OpenECC;
using OpenECC.Encryption.Core;
using System.Numerics;

namespace OpenECC.Encryption
{
    public interface IMessageEncoder
    {
        Point EncodeMessage(Plaintext messageText);
        Plaintext DecodeMessage(Point messagePoint);
    }
}
