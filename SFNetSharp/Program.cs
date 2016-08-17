using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFNetSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Server.Server.Listen(1337);

            Client.Client.Connect("127.0.0.1", 1337);

         

            Console.Read();
            
        }
    }
}
