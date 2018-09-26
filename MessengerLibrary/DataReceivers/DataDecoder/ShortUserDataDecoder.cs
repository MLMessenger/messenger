using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerLibrary.DataDecoder.DataDecoderProviders
{
    class ShortUserDataDecoder
    : IDecoderProvider
    {
        private readonly ShortUserData _shortUserData;
        public ShortUserDataDecoder(ShortUserData shortUserData)
        {
            _shortUserData = shortUserData;
        }
        public string Decode(byte[] symbol)
        {
            throw new NotImplementedException();
        }
    }
}
