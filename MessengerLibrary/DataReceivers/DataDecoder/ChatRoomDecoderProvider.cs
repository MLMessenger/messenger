using System;

namespace MessengerLibrary.DataDecoder.DataDecoderProviders
{
    public class ChatRoomDecoder
        : IDecoderProvider
    {
        private readonly ChatRoom _chatRoom;
        public ChatRoomDecoder(ChatRoom chatRoom)
        {
            _chatRoom = chatRoom;
        }
        public string Decode(byte[] symbol)
        {
            throw new NotImplementedException();
        }
    }
}

