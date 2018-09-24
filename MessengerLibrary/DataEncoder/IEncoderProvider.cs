using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerLibrary.DataEncoder
{
    public interface IEncoderProvider
    {
        byte[] Encode();
    }
}
