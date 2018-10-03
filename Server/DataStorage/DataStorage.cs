using MessengerLibrary;
using MessengerLibrary.ConnectionDirector.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.DataStorage
{
    public class DataStorage // must be singleton
    {
        public static List<User> onlineUsers = new List<User>();

    }
}
