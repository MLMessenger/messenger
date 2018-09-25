using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerLibrary.ConnectionDirector.Events
{
    public class MessageEventArgs : EventArgs
    {
        public MessageEventArgs(Message message)
        {
            this.message = message;
        }
        public Message message { get; set; }
    }
}
