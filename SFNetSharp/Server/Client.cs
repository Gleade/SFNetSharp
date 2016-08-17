using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace SFNetSharp.Server
{
    class Client
    {
        TcpClient mClient;
        NetworkStream Stream;
        public int ID { get; set; }

        /// <summary>
        /// Create a new client.
        /// </summary>
        /// <param name="client"></param>
        public Client(TcpClient client)
        {
            // Get our client by reference
            mClient = client;

            // Get the stream for reading and writing
            Stream = mClient.GetStream();
        }

        /// <summary>
        /// Check if the client is connected to the server.
        /// </summary>
        /// <returns></returns>
        public bool IsConnected()
        {
            return mClient.Connected;
        }

        /// <summary>
        /// Send a packet to the client.
        /// </summary>
        /// <param name="packet"></param>
        public void Send(Packet packet)
        {
            Stream.Write(packet.GetBytes(), 0, packet.GetSize());
            Stream.Flush();
        }

        public void Receive(Packet packet)
        {
            byte[] bytes = new byte[packet.MaxBufferSize];

            int receivedBytesSize = 0;

            while((receivedBytesSize = Stream.Read(bytes, 0, bytes.Length)) != 0)
            {

            }
        }

        /// <summary>
        /// Disconnect the client from the server.
        /// </summary>
        public void Disconnect()
        {
            mClient.Close();
        }


        public void Update()
        {
       
        }
    }
}
