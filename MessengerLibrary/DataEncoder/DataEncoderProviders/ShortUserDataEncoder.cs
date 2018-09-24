using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerLibrary.DataEncoder.DataEncoderProviders
{
    public class ShortUserDataEncoder
        : IEncoderProvider
    {
        private readonly ShortUserData _shortUserData;
        public ShortUserDataEncoder(ShortUserData shortUserData)
        {
            _shortUserData = shortUserData;
        }
        public byte[] Encode()
        {
            throw new NotImplementedException();
        }
    }
}
