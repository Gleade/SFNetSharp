using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace SFNetSharp.Test
{
    class LoginListener : SocketListener
    {
        public void Received(Packet packet)
        {
            byte packetID = packet.ReadByte();
  

            switch(packetID)
            {
                case PacketID.CLIENT_LOGIN: // Login attempt, authenticate
                    string user = packet.ReadString();
                    string pass = packet.ReadString();
                    Console.WriteLine("Login attempt received user: " + user + " " + pass);
                    break;

                default: // Unknown packet ID
                    break;
            }
        }
    }
}
