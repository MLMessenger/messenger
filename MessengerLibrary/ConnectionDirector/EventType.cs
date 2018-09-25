using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerLibrary.ConnectionDirector
{
    public enum EventType
    {
        NewMessageAdded,

        FullUserInfoReceived,
        CurrentUserUpdated,
        UserConnected,

        ShortUserInfoUpdated,

        NewChatRoomAdded,
        NewUserInChatEntered
    }
}
