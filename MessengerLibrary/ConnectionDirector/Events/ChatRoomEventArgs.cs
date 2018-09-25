using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerLibrary.ConnectionDirector.Events
{
    public class ChatRoomEventArgs : EventArgs
    {
        public ChatRoomEventArgs(ChatRoom chatRoom)
        {
            this.chatRoom = chatRoom;
        }
        public ChatRoom chatRoom;
    }
}
