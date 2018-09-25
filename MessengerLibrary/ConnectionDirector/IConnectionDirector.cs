using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerLibrary.ConnectionDirector
{
    public interface IClientConnectionDirector
    {
        void Direct(string XML);

        void OnNewMessageAdded(Message message);
        void OnFullUserInfoReceived(User user);
        void OnCurrentUserUpdated(User currentUser);
        void OnShortUserInfoUpdated(ShortUserData shortUserData);
        void OnNewChatRoomAdded(ChatRoom chatRoom);

    }
}
