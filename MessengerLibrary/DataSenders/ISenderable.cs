using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerLibrary.DataSenders
{
    public interface ISendable
    {
        void Send(byte[] bytes);
    }
}
