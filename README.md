# SFNetSharp
SFNetSharp (Simple Fast Networking C#) A simple Java networking library for TCP (no UDP yet) server-client connections.

# SFNet

SFNet (Simple Fast Networking)

A simple Java networking library for TCP (no UDP yet) server-client connections.

Currently supports:
- server-client connections
- easy-to-use packet container
- sending / receiving packets


Example:
    Main

```C#
        static void Main(string[] args)
        {
            Server.Server.Listen(1337);

            Client.Client.Connect("127.0.0.1", 1337);
            SocketListenerManager.AddListener(new LoginListener());

            string user = "Test";
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

```


    
```C#
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

```
