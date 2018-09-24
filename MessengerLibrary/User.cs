using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerLibrary
{
    public class User // full user description
    {
        public User() { }
        public long UserId;
        public string UserName;
        public string UserPassword;

        public string NickName;
        public string Status;

        public DateTime LastOnline;
        public bool IsOnline;
        public IEnumerable<ShortUserData> Friends;
        public IEnumerable<ChatRoom> Rooms;
    }
}
