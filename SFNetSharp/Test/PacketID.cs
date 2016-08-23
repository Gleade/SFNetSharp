using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFNetSharp.Test
{
    class PacketID
    {
       
            public const byte 
            CLIENT_LOGIN = 0,
            CLIENT_REGISTER = 1,
            SERVER_DENY_LOGIN = 2,
            SERVER_DENY_REGISTER = 3,
            SERVER_DENY_BAN = 4;
     
    }
}
