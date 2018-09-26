using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerLibrary.DataDecoder.DataDecoderProviders
{
    class UserDataDecoder
    : IDecoderProvider
    {
        private readonly User _user;
        public UserDataDecoder(User user)
        {
            _user = user;
        }
        public string Decode(byte[] symbol)
        {
            throw new NotImplementedException();
        }
    }
}
