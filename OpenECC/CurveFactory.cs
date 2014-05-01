using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace OpenECC
{
    public class CurveFactory
    {

        /// <summary>
        /// y^2 = x^3+0x+7 over Fp where p = 2^256 - 2^32 - 977
        /// (Weierstrass curve with a = 0, b = 7)
        /// This curve is used in the Bitcoin implementation.
        /// </summary>
        [Obsolete("This curve is not safe - see http://safecurves.cr.yp.to")]
        public static WeierstrassCurve secp256k1
        {
            get
            {
                var p = BigInteger.Parse("115792089237316195423570985008687907853269984665640564039457584007908834671663");
                var g_x = BigInteger.Parse("55066263022277343669578718895168534326250603453777594175500187360389116729240");
                var g_y = BigInteger.Parse("32670510020758816978083085130507043184471273380659243275938904335757337482424");
                var g_order = BigInteger.Parse("115792089237316195423570985008687907852837564279074904382605163141518161494337");

                return new WeierstrassCurve(
                    a: new BigInteger(0), 
                    b: new BigInteger(7), 
                    prime: p, 
                    generator_x: g_x,
                    generator_y: g_y,
                    order_of_generator: g_order
                );
            }
        }

        public static WeierstrassCurve nistp384
        {
            get
            {
                var prime = BigInteger.Parse("39402006196394479212279040100143613805079739270465446667948293404245721771496870329047266088258938001861606973112319");
                var a = new BigInteger(-3);
                var b = BigInteger.Parse("27580193559959705877849011840389048093056905856361568521428707301988689241309860865136260764883745107765439761230575");
                var g_x = BigInteger.Parse("26247035095799689268623156744566981891852923491109213387815615900925518854738050089022388053975719786650872476732087");
                var g_y = BigInteger.Parse("8325710961489029985546751289520108179287853048861315594709205902480503199884419224438643760392947333078086511627871");
                var g_order = BigInteger.Parse("39402006196394479212279040100143613805079739270465446667946905279627659399113263569398956308152294913554433653942643");
                return new WeierstrassCurve(a, b, prime, g_x, g_y, g_order);
            }
        }
    }
}
