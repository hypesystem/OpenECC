using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenECC.Encryption.Core
{
    public class Plaintext
    {
        private string _content;
        private static System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();

        /// <summary>
        /// Convertable between string and byte array. Primary form is string.
        /// </summary>
        /// <param name="content"></param>
        public Plaintext(string content)
        {
            _content = content;
        }

        public override string ToString()
        {
            return _content;
        }

        public byte[] ToByteArray()
        {
            return encoding.GetBytes(_content);
        }
    }
}
