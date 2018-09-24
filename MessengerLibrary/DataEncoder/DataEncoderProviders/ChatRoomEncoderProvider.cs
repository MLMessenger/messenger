using System;

namespace MessengerLibrary.DataEncoder.DataEncoderProviders
{
    public class ChatRoomEncoder
        : IEncoderProvider
    {
        private readonly ChatRoom _chatRoom;
        public ChatRoomEncoder(ChatRoom chatRoom)
        {
            _chatRoom = chatRoom;
        }
        public byte[] Encode()
        {
            throw new NotImplementedException();
        }
    }
}
