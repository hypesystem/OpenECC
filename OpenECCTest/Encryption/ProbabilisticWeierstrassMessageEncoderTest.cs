using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenECC.Encryption.Core;
using System.Numerics;
using OpenECC;
using OpenECC.Encryption;

namespace OpenECCTest.Encryption
{
    [TestClass]
    public class ProbabilisticWeierstrassMessageEncoderTest
    {
        [TestMethod]
        public void TestEncoderCyclic()
        {
            //Curve: NIST P-384
            var prime = BigInteger.Parse("39402006196394479212279040100143613805079739270465446667948293404245721771496870329047266088258938001861606973112319");
            var a = new BigInteger(-3);
            var b = BigInteger.Parse("27580193559959705877849011840389048093056905856361568521428707301988689241309860865136260764883745107765439761230575");
            var g_x = BigInteger.Parse("26247035095799689268623156744566981891852923491109213387815615900925518854738050089022388053975719786650872476732087");
            var g_y = BigInteger.Parse("8325710961489029985546751289520108179287853048861315594709205902480503199884419224438643760392947333078086511627871");
            var g_order = BigInteger.Parse("39402006196394479212279040100143613805079739270465446667946905279627659399113263569398956308152294913554433653942643");
            var curve = new WeierstrassCurve(a, b, prime, g_x, g_y, g_order);

            var encoder = new ProbabilisticWeierstrassMessageEncoder(curve);

            //Encode
            var m = new Plaintext("A");
            BigInteger encoding_key;
            var M = encoder.EncodeMessage(m, out encoding_key);

            //Decode
            var m2 = encoder.DecodeMessage(M, encoding_key);

            Assert.AreEqual(m, m2);
        }
    }
}
