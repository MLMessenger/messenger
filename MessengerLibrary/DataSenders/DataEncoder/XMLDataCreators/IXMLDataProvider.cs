using MessengerLibrary.ConnectionDirector;
using MessengerLibrary.DataSenders.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerLibrary.DataEncoder.XMLDataCreators
{
    public interface IXMLDataProvider
    {
        string CreateXML(RequestType requestType, User user);
        string CreateXML(RequestType requestType, Message user);
        string CreateXML(RequestType requestType, ChatRoom user);
        string CreateXML(RequestType requestType, ShortUserData user);
        string CreateXML(RequestType requestType); // do not use this method

        string CreateXML(EventType requestType, User user);
        string CreateXML(EventType requestType, Message user);
        string CreateXML(EventType requestType, ChatRoom user);
        string CreateXML(EventType requestType, ShortUserData user);
        string CreateXML(EventType requestType); // do not use this method
    }
}
