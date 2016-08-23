using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    class SocketListenerManager
    {
        static List<SocketListener> SocketListeners = new List<SocketListener>();


        /// <summary>
        /// Add a listener to the list of socket listeners.
        /// </summary>
        /// <param name="listener"></param>
        public static void AddListener(SocketListener listener)
        {
            SocketListeners.Add(listener);

        }

        /// <summary>
        /// Send a packet to all of the listeners.
        /// Listeners looking for the specific packet ID's will/can respond.
        /// </summary>
        /// <param name="packet"></param>
        public static void Post(Packet packet)
        {
            foreach(SocketListener listener in SocketListeners)
            {
                listener.Received(packet);
            }
        }
    }
}
