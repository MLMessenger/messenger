using MessengerLibrary;
using MessengerLibrary.ConnectionDirector.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DataStorage.Notifications
{
    public class ExtendedMessageEventArgs
        : MessageEventArgs
    {
        public ExtendedMessageEventArgs(Message message) : base(message)
        {
        }
        public ExtendedMessageEventArgs(Message message, User user) : base(message)
        {
            this.user = user;
        }
        public User user;

    }
}
