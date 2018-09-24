using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerLibrary
{
    public class ChatRoom
    {
        public ChatRoom() { }
        public long id;
        public IEnumerable<ShortUserData> members;
    }
}
