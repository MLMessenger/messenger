using MessengerLibrary.ConnectionDirector.Events;
using MessengerLibrary.ConnectionDirector.Parsers;
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
        IXMLParser iXMLParser;
        //eventHandlers
        public event EventHandler<MessageEventArgs> NewMessageAdded;

        public event EventHandler<ChatRoomEventArgs> NewChatRoomAdded;
        public event EventHandler<ChatRoomEventArgs> NewUserInChatEntered;

        public event EventHandler<ShortUserDataEventArgs> ShortUserInfoUpdated;

        public event EventHandler<UserEventAgrs> CurrentUserUpdated;
        public event EventHandler<UserEventAgrs> FullUserInfoReceived;
        public event EventHandler<UserEventAgrs> UserConnected;
        
        public void Direct(string XML)  // this method trigger events
        {
            switch (iXMLParser.GetEventType(XML))
            {
                case EventType.NewMessageAdded:
                    OnNewMessageAdded(iXMLParser.GetMessage(XML));
                    break;

                case EventType.FullUserInfoReceived:
                    OnFullUserInfoReceived(iXMLParser.GetUser(XML));
                    break;

                case EventType.CurrentUserUpdated:
                    OnCurrentUserUpdated(iXMLParser.GetUser(XML));
                    break;

                case EventType.UserConnected:
                    OnUserConnected(iXMLParser.GetUser(XML));
                    break;
                case EventType.ShortUserInfoUpdated:
                    OnShortUserInfoUpdated(iXMLParser.GetShortUserData(XML));
                    break;

                case EventType.NewChatRoomAdded:
                    OnNewChatRoomAdded(iXMLParser.GetChatRoom(XML));
                    break;

                case EventType.NewUserInChatEntered:
                    OnNewUserInChatEntered(iXMLParser.GetChatRoom(XML));
                    break;

                case EventType.AlreadyExistUserExceptionDetected:
                    throw new Exception("User already exist");
                    break;
                default:
                    throw new Exception("OTHER CASE");
                    break;
            }
        }

        protected virtual void OnNewMessageAdded            (Message message)
        {
            NewMessageAdded(this, new MessageEventArgs(message));
        }
        protected virtual void OnNewChatRoomAdded           (ChatRoom chatRoom)
        {
            NewChatRoomAdded(this, new ChatRoomEventArgs(chatRoom));
        }
        protected virtual void OnShortUserInfoUpdated       (ShortUserData shortUserData)
        {
            ShortUserInfoUpdated(this, new ShortUserDataEventArgs(shortUserData));
        }
        protected virtual void OnCurrentUserUpdated         (User currentUser)
        {
            CurrentUserUpdated(this, new UserEventAgrs(currentUser));
        }
        protected virtual void OnFullUserInfoReceived       (User user)
        {
            FullUserInfoReceived(this, new UserEventAgrs(user));
        }
        protected virtual void OnUserConnected              (User currentUser)
        {
            UserConnected(this, new UserEventAgrs(currentUser));
        }
        protected virtual void OnNewUserInChatEntered       (ChatRoom chatRoom)
        {
            NewUserInChatEntered(this,new ChatRoomEventArgs(chatRoom));
        }

    }
}
