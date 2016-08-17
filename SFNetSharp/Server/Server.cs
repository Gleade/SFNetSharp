using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utils;

namespace SFNetSharp.Server
{
    class Server
    {
        private static TcpListener Listener {get;set;}
        private static TcpClient mClient;
        private static Thread mThread;
        private static bool Running = false;
        private static List<Client> mClients;
        private static List<int> AvailbleClientIDs { get; set; }
        private static List<int> UsedClientIDs { get; set; }
        public static int MaxClients { get; set; } = 50;

        public static void Listen(int port)
        {
            mClients = new List<Client>(); // Create our list of clients
            AvailbleClientIDs = new List<int>(); // Create our List of ID's
            UsedClientIDs = new List<int>();
            GenerateUniqueIDList(); // Generate our ID's
            
            Listener = new TcpListener(port);

            // Listen on the port
            try
            {
                Listener.Start();
                Listener.Server.Blocking = false;
                Running = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to listen on port: " + port);
                Console.WriteLine(ex.StackTrace);
            }

            mThread = new Thread(new ThreadStart(Update));
            mThread.Start();
            Console.WriteLine("Server thread started.");
        }

        public static void Send(Packet packet)
        {

        }

        public static void Update()
        {

            while (Running)
            {
                CheckNewConnections();
                CheckDisconnections();
              
            }

        }

        /// <summary>
        /// Check for any new connections and attempt to authenticate.
        /// </summary>
        public static void CheckNewConnections()
        {
            try
            {
                mClient = Listener.AcceptTcpClient();

                Client newClient = new Client(mClient);
                // Only add a new connected client if we have room on the server
                if (mClients.Count < MaxClients)
                {
                    AssignClientID(newClient);
                    mClients.Add(newClient);
                }
                else
                {
                    newClient = null;
                }

                /*
                 * Add
                 * 
                 * Eventually send some sort of message to the client that the server is full.
                 * 
                 * 
                 */

                // Check if we got a new connection
                Console.WriteLine("New client connected with ID: " + newClient.ID);
            }
            catch (Exception ex)
            {

            }
        }

        public static void CheckDisconnections()
        {
            foreach(Client client in mClients)
            {
                if(client.IsConnected() == false)
                {
                    // Unassign the client ID and remove it from our client list
                    UnassignClientID(client);
                    mClients.Remove(client);
                }
            }
        }

        public static void ShutDown()
        {
            Running = false;
            mThread.Abort();
          
            // Pause the main thread untill the update thread is completely terminated.
            while(mThread.ThreadState == ThreadState.Running)
            {
                
            }

            Console.WriteLine("Server thread shutdown complete.");
        }

        /// <summary>
        /// Unassign a client ID from our UsedClientID's list.
        /// </summary>
        /// <param name="client"></param>
        public static void UnassignClientID(Client client)
        {
            try
            {
                UsedClientIDs.Remove(client.ID);
            }
            catch(Exception ex)
            {

            }
        }

        /// <summary>
        /// Assign a client with an ID from our AvailableClientID's list.
        /// </summary>
        /// <param name="client"></param>
        public static void AssignClientID(Client client)
        {
            int ID = 0;
            bool unique;

            // Loop through available ID's till we find one not taken
            foreach(int AvailableID in AvailbleClientIDs)
            {
                ID = AvailableID;
                unique = true;

                foreach(int UsedID in UsedClientIDs)
                {
                    // If the current ID is in use, break from this loop.
                    // This will then continue to check our available ID's
                    if(ID == UsedID)
                    {
                        unique = false;
                        break;
                    }
                }

                if(unique)
                {
                    client.ID = ID;
                    break;
                }
            }
        }

        public static void GenerateUniqueIDList()
        {
            // Initalize our RNG
            int min = 0;
            int max = 10;
            int increments = max;
            Random rnd = new Random();

            // Generate random ID's that our clients can be assigned
            for (int i = 0; i < MaxClients; i++)
            {
                int rndNumb = rnd.Next(min, max);
                AvailbleClientIDs.Add(rndNumb);
                min += increments;
                max += increments;
            }
        }


    }
}
