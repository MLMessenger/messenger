using MessengerLibrary;
using MessengerLibrary.ConnectionDirector.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DataStorage
{
    public class ServerEventHandler
    {
        public event EventHandler<UserEventAgrs> NewUserConnected;
        public event EventHandler<UserEventAgrs> UserDisconnected;
        public event EventHandler<UserEventAgrs> NewUserRegistered;

        public void registerNewUser(User user)
        {

        }
        public void userConnected(User user)
        {
            if (!DataStorage.onlineUsers.Contains(user))
            {
                DataStorage.onlineUsers.Add(user);
                NewConnectionNotification(user);
            }
        }
        public void userDisconnected(User user)
        {
            if (DataStorage.onlineUsers.Contains(user))
            {
                if (DataStorage.onlineUsers.Remove(user) &&
                    DataStorage.onlineUsersSocketDictionary.Remove(user))
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
