using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utils;

namespace SFNetSharp.Client
{
    class Client
    {
        private static TcpClient mClient;
        private static NetworkStream Stream;
        private static Thread mThread;

        public static bool Connect(string ipAddress, int port)
        {
            // Attempt to connect to the server.
            mClient = new TcpClient();
            mClient.Connect(ipAddress, port);

            if(mClient.Connected)
            {
                Console.WriteLine("Connected to server.");
                Stream = mClient.GetStream();
                mClient.NoDelay = true;
                mClient.Client.Blocking = false;
                mThread = new Thread(new ThreadStart(Update));
                mThread.Start();

                return true;
            }
            else
            {
                Console.WriteLine("Failed to connect to server: " + ipAddress + ":" + port.ToString());
                return false;
            }
        }

        public static void Update()
        {
            while (true)
            {
                if (mClient.Connected)
                {
                    Receive();
                }
                else
                {
                    Console.WriteLine("Dsconnected from server.");
                }
            }
        }

        /// <summary>
        /// Send a packet to the server.
        /// </summary>
        /// <param name="packet"></param>
        public static void Send(Packet packet)
        {
            Stream.Write(packet.GetBytes(), 0, packet.GetSize());
            //Stream.Flush();
        }

        /// <summary>
        /// Receive a new packet from the client.
        /// Posts all packets to the SocketListenerManager.
        /// </summary>
        /// <param name="packet"></param>
        public static void Receive()
        {
            byte[] bytes = new byte[Packet.MaxBufferSize];

            int receivedBytesSize = 0;

            try
            {
       
                // Read all bytes in the stream
                while ((receivedBytesSize += Stream.Read(bytes, 0, bytes.Length)) != 0)
                {
              
                }

            }
            catch(Exception ex)
            {
                // There was no data to be read.
            }
            finally
            {
                // Check if we've received any bytes from the server.
                if (receivedBytesSize > 0)
                {
                    Packet newPacket = new Packet(bytes);
                    SocketListenerManager.Post(newPacket);
                    Console.WriteLine("Received bytes: " + receivedBytesSize + " from server.");
                }
            }



        }
    }
}
