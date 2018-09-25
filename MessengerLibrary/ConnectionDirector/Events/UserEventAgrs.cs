using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerLibrary.ConnectionDirector.Events
{
    public class UserEventAgrs : EventArgs
    {
        public UserEventAgrs(User user)
        {
            this.user = user;
        }
        public User user { get; set; }
    }
}
