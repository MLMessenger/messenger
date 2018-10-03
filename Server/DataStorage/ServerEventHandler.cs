using MessengerLibrary;
using MessengerLibrary.ConnectionDirector.Events;
using Server.DataStorage.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DataStorage
{
    public class ServerEventHandler
    {
        public event EventHandler<UserEventAgrs>                  NewUserConnected;
        public event EventHandler<UserEventAgrs>                  UserDisconnected;
        public event EventHandler<UserEventAgrs>                  NewUserRegistered;
        public event EventHandler<ExtendedMessageEventArgs>       NewMessageAdded;



        public void registerNewUser(User user)
        {
            if (!DataStorage.onlineUsers.Contains(user))
            {
                DataStorage.onlineUsers.Add(user);
                // remoteDataStorage.Add(user); adding user to DB
            }
        }
        public void newMessageSent(Message message)
        {
            foreach (var item in DataStorage.onlineUsers)
            {
                if(item.Rooms.Select(i => i.id).Contains(message.ChatRoomId))
                {
                    NewMessageAdded(this, new ExtendedMessageEventArgs(message, item));
                }
            }

        }
        public void userConnected(User user)
        {
            if (!DataStorage.onlineUsers.Contains(user))
            {
                DataStorage.onlineUsers.Add(user);
                NewConnectionNotification(user);
                // remoteDataStorage.LoadData(user); better async
            }
        }
        public void userDisconnected(User user)
        {
            if (DataStorage.onlineUsers.Contains(user))
            {
                if (DataStorage.onlineUsers.Remove(user))
                    UserDisconnectedNotification(user);
            }

        }

        private void UserDisconnectedNotification(User user)
        {
            foreach (var item in DataStorage.onlineUsers)
            {
                if (item.Friends.Contains(user.ToShortUserData()))
                {
                    UserDisconnected(this, new UserEventAgrs(user));
                }
            }
        }

        private void NewConnectionNotification(User user)
        {
            foreach (var item in DataStorage.onlineUsers)
            {
                if (item.Friends.Contains(user.ToShortUserData()))
                {
                    NewUserConnected(this, new UserEventAgrs(user));
                }
            }
        }
    }
}
