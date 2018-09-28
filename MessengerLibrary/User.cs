using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerLibrary
{
    public class User // full user description
    {
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            // TODO: write your implementation of Equals() here

            return ((User)obj).UserId == UserId;
        }
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
        public ShortUserData ToShortUserData()
        {
            ShortUserData shortUserData = new ShortUserData();
            shortUserData.UserId = UserId;
            shortUserData.NickName = NickName;
            shortUserData.isOnline = IsOnline;
            return shortUserData;
        }
    }
}
