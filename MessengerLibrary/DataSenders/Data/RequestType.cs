using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerLibrary.DataSenders.Data
{
    public enum RequestType
    {
        InviteUserToChat,
        CreateNewChat,
        SendMessage,
        RegisterNewUser,
        Connect,
        Disconnect,
        AddFriend,
        FindUser
    }
}
