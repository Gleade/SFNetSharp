using SFNetSharp.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace SFNetSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Server.Server.Listen(1337);

            Client.Client.Connect("127.0.0.1", 1337);
            SocketListenerManager.AddListener(new LoginListener());

            Packet testPacket = new Packet();
            testPacket.WriteByte(0);
            testPacket.WriteShort(1);

            System.Threading.Thread.Sleep(1000);
            Server.Server.SendGlobal(testPacket);
       



            Console.Read();
            
        }
    }
}
