using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerLibrary.DataSenders
{
    public interface IRequestDispatcher
    {
        void InviteUserToChat(ShortUserData newUser, ChatRoom chatRoom);
        void InviteUserToChat(User newUser, ChatRoom chatRoom);

        void CreateNewChat(User currentUser, IEnumerable<ShortUserData> members, string ChatName);
        void CreateNewChat(User currentUser, ShortUserData friend, string ChatName);

        void SendMessage(Message newMessage);

        void RegisterNewUser(User newUser);
        void Connect(User user);
    }
}
