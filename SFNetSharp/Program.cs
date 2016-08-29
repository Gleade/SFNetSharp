using SFNetSharp.Test;
using System;
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

            string user = "Joel";
            string pass = "Test";
            Packet testPacket = new Packet();
            testPacket.WriteByte(0);
            testPacket.WriteString(user);
            testPacket.WriteString(pass.GetHashCode().ToString());

            System.Threading.Thread.Sleep(1000);
            Server.Server.SendGlobal(testPacket);

            Database.DatabaseManager.Connect("localhost", "jinx-studio", "root", "password");
            Database.Table table = Database.DatabaseManager.RunQuery("SELECT * FROM website_account WHERE website_username = 'dev'");
            string password = table.GetData<string>("website_password");
            Console.WriteLine("Password: " + password);

            Console.Read();
            
        }
    }
}
