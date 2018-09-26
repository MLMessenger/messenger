using MessengerLibrary.DataDecoder.DataDecoderProviders;
using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessengerLibrary.DataReceivers.DataDecoder;
using MessengerLibrary.DataDecoder;

namespace MessengerLibrary.DataReceivers.DataDecoder
{
    public class DataDecoder 
        : IDataDecoder// this class encode object to string and string to bytes 
    {
        private readonly IDecoderProvider _provider;
        public DataDecoder()
        {
        }
        public DataDecoder(IDecoderProvider provider)
        {
            _provider = provider;
        }
        public string Decode(byte[] symbol)
        {
            return _provider.Decode(symbol);
        }

        ///////////////////////////////////////////////////////
        ///                                                 ///
        ///  should the methods accept 2 input parameters?  ///
        ///                                                 ///
        ///////////////////////////////////////////////////////

        public static string Decode(User usr, byte[] symbol) { return new UserDataDecoder(usr).Decode(symbol); } 
        public static string Decode(ShortUserData shortInfo, byte[] symbol) { return new ShortUserDataDecoder(shortInfo).Decode(symbol); }
        public static string Decode(ChatRoom chat, byte[] symbol) { return new ChatRoomDecoder(chat).Decode(symbol); }
    }
}
