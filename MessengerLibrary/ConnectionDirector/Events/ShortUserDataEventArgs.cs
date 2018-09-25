using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerLibrary.ConnectionDirector.Events
{
    public class ShortUserDataEventArgs : EventArgs
    {
        public ShortUserDataEventArgs(ShortUserData shortUserData)
        {
            this.shortUserData = shortUserData;
        }
        public ShortUserData shortUserData { get; set; }
    }
}
