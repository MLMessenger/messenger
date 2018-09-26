using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;

namespace MessengerLibrary.DataDecoder
{
    public interface IDecoderProvider
    {
        string Decode(byte[] symbol);

        ///////////////////////////////////////////////////////
        ///                                                 ///
        ///  which return type?                             ///
        ///                                                 ///
        ///////////////////////////////////////////////////////

        //XmlDocument Decode(string str); 

    }
}
