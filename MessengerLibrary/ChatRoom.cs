using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerLibrary
{
    public class ChatRoom // description of the data for each room, 1 to 1 is also room
    {
        public ChatRoom() { }
        public long id;
        public IEnumerable<ShortUserData> members;
    }
}
