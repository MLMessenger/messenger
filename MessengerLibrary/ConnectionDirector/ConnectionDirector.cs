using MessengerLibrary.ConnectionDirector.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerLibrary.ConnectionDirector
{
    public class ClientConnectionDirector
        : IClientConnectionDirector
    {
        //eventHandlers
        public event EventHandler<MessageEventArgs> NewMessageAdded;
        public event EventHandler<ChatRoomEventArgs> NewChatRoomAdded;
        public event EventHandler<ShortUserDataEventArgs> ShortUserInfoUpdated;

        public event EventHandler<UserEventAgrs> CurrentUserUpdated;
        public event EventHandler<UserEventAgrs> FullUserInfoReceived;

        public void Direct(string XML) // this method trigger events
        {
            throw new NotImplementedException();
            // parse XML and trigger events
        }

        public void OnNewMessageAdded(Message message)
        {
            NewMessageAdded(this, new MessageEventArgs(message));
        }
        public void OnNewChatRoomAdded(ChatRoom chatRoom)
        {
            NewChatRoomAdded(this, new ChatRoomEventArgs(chatRoom));
        }
        public void OnShortUserInfoUpdated(ShortUserData shortUserData)
        {
            ShortUserInfoUpdated(this, new ShortUserDataEventArgs(shortUserData));
        }
        public void OnCurrentUserUpdated(User currentUser)
        {
            CurrentUserUpdated(this, new UserEventAgrs(currentUser));
        }
        public void OnFullUserInfoReceived(User user)
        {
            FullUserInfoReceived(this, new UserEventAgrs(user));
        }


    }
}
