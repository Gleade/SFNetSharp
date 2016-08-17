using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SFNetSharp.Client
{
    class Client
    {
        private static TcpClient mClient;

        public static bool Connect(string ipAddress, int port)
        {
            // Attempt to connect to the server.
            mClient = new TcpClient();
            mClient.Connect(ipAddress, port);

            if(mClient.Connected)
            {
                Console.WriteLine("Connected to server.");

                return true;
            }
            else
            {
                Console.WriteLine("Failed to connect to server: " + ipAddress + ":" + port.ToString());
                return false;
            }
        }
    }
}
