using MessengerLibrary.DataEncoder.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerLibrary.DataEncoder
{
    public class DataEncoder // this class encode object to string and string to bytes 
    {
        private readonly IEncryptable encryptor;
        public DataEncoder(IEncryptable encryptor)
        {
            this.encryptor = encryptor;
        }
        public byte[] GetBytes(string XML)
        {
            return encryptor.Encrypt(XML);
        }

    }
}
