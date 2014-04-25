using System;
using OpenECC;
using OpenECC.Encryption.Core;

namespace OpenECC.Encryption
{
    public interface IMessageEncoder
    {
        Point EncodeMessage(Plaintext messageText);
        Plaintext DecodeMessage(Point messagePoint);
    }
}
