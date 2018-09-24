using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerLibrary
{
    public class Message// description of the data for message in room 
    {
        public Message() { }
        public ShortUserData Sender;
        public long ChatRoomId;
        public string MessageBody;
    }
}
