using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerLibrary.ConnectionDirector.Parsers
{
    public interface IXMLParser
    {
        EventType GetEventType(string str);

        Message GetMessage(string str);

        User GetUser(string str);

        ShortUserData GetShortUserData(string str);

        ChatRoom GetChatRoom(string str);
    }
}
