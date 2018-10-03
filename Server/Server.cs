using MessengerLibrary;
using MessengerLibrary.ConnectionDirector.Events;
using MessengerLibrary.ConnectionDirector.Parsers;
using MessengerLibrary.DataReceivers.DataDecoder;
using Server.DataStorage;
using Server.DataStorage.Notifications;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Server
    {
        private Dictionary<long, Socket> onlineUsersSocketDictionary = new Dictionary<long, Socket>();
        private string myHost = System.Net.Dns.GetHostName();
        private IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6767);
        private readonly IXMLParser parser;
        private Socket serverSocket;
        private ServerEventHandler serverEventHandler;
        public Server()
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            serverSocket.Bind(endPoint);
            serverSocket.Listen(1000);

            serverEventHandler.NewMessageAdded += onNewMessageAdded;
            serverEventHandler.NewUserConnected += onNewUserConnected;
            serverEventHandler.UserDisconnected += onNewUserDisconnected;
        }


        public void Run()
        {
            Console.WriteLine("Server started");
            while (true)
            {
                SocketAsyncEventArgs e = new SocketAsyncEventArgs();
                e.Completed += onSocketAccepted;
                if (!serverSocket.AcceptAsync(e))
                {
                    onSocketAccepted(serverSocket, e);
                }
            }
        }
        protected void onSocketAccepted(object sender, SocketAsyncEventArgs e)
        {
            while (true)
            {
                Socket clientSocket = e.AcceptSocket;
                SocketAsyncEventArgs eventRecieve = new SocketAsyncEventArgs();
                eventRecieve.Completed += onSocketAccepted;
                if (!serverSocket.ReceiveAsync(eventRecieve))
                {
                    onSocketDataRecieve(serverSocket, eventRecieve);
                }
                Console.WriteLine("Received data from client");
            }
        }
        protected void onSocketDataRecieve(object sender, SocketAsyncEventArgs e)
        {
            var requestBytes = new byte[4096];
            string requestString = Encoding.Unicode.GetString(e.Buffer, 0, e.Buffer.Length);
            HandleEvent(requestString, (Socket)sender);
        }
        private void HandleEvent(string xml, Socket socket)
        {
            switch (parser.GetRequestType(xml))
            {
                case MessengerLibrary.DataSenders.Data.RequestType.Connect:
                    User usr = parser.GetUser(xml);
                    onlineUsersSocketDictionary.Add(usr.UserId, socket);
                    serverEventHandler.userConnected(usr);
                    break;

                case MessengerLibrary.DataSenders.Data.RequestType.CreateNewChat:
                    break;

                case MessengerLibrary.DataSenders.Data.RequestType.InviteUserToChat:
                    break;

                case MessengerLibrary.DataSenders.Data.RequestType.RegisterNewUser:
                    break;

                case MessengerLibrary.DataSenders.Data.RequestType.SendMessage:
                    serverEventHandler.newMessageSent(parser.GetMessage(xml));
                    break;
                default:
                    break;
            }
        }


        //////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////// EVENT HANDLERS FOR "ServerEventHandler"
        //////////////////////////////////////////////////////////
        protected void onNewMessageAdded(object sender, ExtendedMessageEventArgs e)
        {
            
        }

        protected void onNewUserConnected(object sender, UserEventAgrs e)
        {
            throw new NotImplementedException();
        }

        protected void onNewUserDisconnected(object sender, UserEventAgrs e)
        {
            throw new NotImplementedException();
        }
    }
}
