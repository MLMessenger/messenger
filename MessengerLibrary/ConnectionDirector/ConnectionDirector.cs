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

                default:
                    throw new Exception("OTHER CASE");
                    break;
            }
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
        public void OnUserConnected(User currentUser)
        {
            UserConnected(this, new UserEventAgrs(currentUser));
        }
        public void OnNewUserInChatEntered(ChatRoom chatRoom)
        {
            NewUserInChatEntered(this,new ChatRoomEventArgs(chatRoom));
        }

    }
}
