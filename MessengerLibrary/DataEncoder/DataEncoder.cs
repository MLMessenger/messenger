using MessengerLibrary.DataEncoder.DataEncoderProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerLibrary.DataEncoder
{
    class DataEncoder
    {
        private readonly IEncoderProvider _provider;
        public DataEncoder(IEncoderProvider provider) => _provider = provider;
        public byte[] GetBytes()
        {
            return _provider.Encode();
        }
        public static byte[] Encode(User usr) { return new UserDataEncoder(usr).Encode(); }
        public static byte[] Encode(ShortUserData shortInfo) { return new ShortUserDataEncoder(shortInfo).Encode(); }
        public static byte[] Encode(ChatRoom chat) { return new ChatRoomEncoder(chat).Encode(); }
    }
}
