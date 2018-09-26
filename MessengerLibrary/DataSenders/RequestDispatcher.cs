using MessengerLibrary.DataEncoder.Encryption;
using MessengerLibrary.DataEncoder.XMLDataCreators;
using MessengerLibrary.DataSenders.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerLibrary.DataSenders
{
    public class RequestDispatcher
        : IRequestDispatcher
    {
        private readonly IXMLDataProvider xmlDataProvider;
        private readonly IEncryptable encryptable;
        private readonly ISenderable sender;
        public void Connect(User user)
        {
            Provide(xmlDataProvider.CreateXML(RequestType.Connect, user));
        }

        public void CreateNewChat(User currentUser, IEnumerable<ShortUserData> members, string ChatName)
        {
            throw new NotImplementedException();
        }

        public void CreateNewChat(User currentUser, ShortUserData friend, string ChatName)
        {
            throw new NotImplementedException();
        }

        public void InviteUserToChat(ShortUserData newUser, ChatRoom chatRoom)
        {
            var newList = chatRoom.members.ToList();
            newList.Add(newUser);
            chatRoom.members = newList;
            Provide(xmlDataProvider.CreateXML(RequestType.InviteUserToChat, chatRoom));
        }

        public void InviteUserToChat(User newUser, ChatRoom chatRoom)
        {
            // add newUser to members in chat room
            var newList = chatRoom.members.ToList();
            //newList.Add(newUser); should convert to ShortUserData
            chatRoom.members = newList;
            Provide(xmlDataProvider.CreateXML(RequestType.InviteUserToChat, chatRoom));
        }

        public void RegisterNewUser(User newUser)
        {
            Provide(xmlDataProvider.CreateXML(RequestType.RegisterNewUser, newUser));
        }

        public void SendMessage(Message newMessage)
        {
            Provide(xmlDataProvider.CreateXML(RequestType.SendMessage, newMessage));
        }
        private void Provide(string xml)
        {
            sender.Send(encryptable.Encrypt(xml));
        }
    }
}
