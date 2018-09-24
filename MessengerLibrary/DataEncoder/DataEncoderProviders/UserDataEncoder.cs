using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerLibrary.DataEncoder.DataEncoderProviders
{
    public class UserDataEncoder
        : IEncoderProvider
    {
        private readonly User _user;
        public UserDataEncoder(User user)
        {
            _user = user;
        }
        public byte[] Encode()
        {
            throw new NotImplementedException();
        }
    }
}
