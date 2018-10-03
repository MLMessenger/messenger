using MessengerLibrary;
using MessengerLibrary.ConnectionDirector;
using MessengerLibrary.ConnectionDirector.Events;
using MessengerLibrary.ConnectionDirector.Parsers;
using MessengerLibrary.DataEncoder;
using MessengerLibrary.DataEncoder.Encryption;
using MessengerLibrary.DataEncoder.XMLDataCreators;
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
            serverEventHandler.ChatRoomUpdated += onChatRoomUpdated;
            serverEventHandler.NewChatRoomAdded += onNewChatRoomAdded;
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
                    serverEventHandler.NewChatCreated(parser.GetChatRoom(xml));
                    break;

                case MessengerLibrary.DataSenders.Data.RequestType.InviteUserToChat:
                    serverEventHandler.NewUserToChatInvited(parser.GetChatRoom(xml));
                    break;

                case MessengerLibrary.DataSenders.Data.RequestType.RegisterNewUser:
                    serverEventHandler.registerNewUser(parser.GetUser(xml));
                    break;

                case MessengerLibrary.DataSenders.Data.RequestType.SendMessage:
                    serverEventHandler.newMessageSent(parser.GetMessage(xml));
                    break;

                case MessengerLibrary.DataSenders.Data.RequestType.Disconnect:
                    serverEventHandler.userDisconnected(parser.GetUser(xml));
                    break;

                case MessengerLibrary.DataSenders.Data.RequestType.FindUser:
                    throw new NotImplementedException();
                    break;

                case MessengerLibrary.DataSenders.Data.RequestType.AddFriend:
                    throw new NotImplementedException();
                    break;

                default:
                    throw new NotImplementedException();
                    break;
            }
        }


        //////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////// EVENT HANDLERS FOR "ServerEventHandler"
        //////////////////////////////////////////////////////////
        protected void onNewMessageAdded(object sender, ExtendedMessageEventArgs e)
        {
            IEncryptable encryptable;
            IXMLDataProvider XMLDataProvider;
            //byte[] mockBuffer = new DataEncoder(encryptable).GetBytes(XMLDataProvider.CreateXML(EventType.NewMessageAdded, e.message));
            //onlineUsersSocketDictionary[e.user.UserId].Send(mockBuffer);
        }

        protected void onNewUserConnected(object sender, UserEventAgrs e)
        {
            IEncryptable encryptable;
            IXMLDataProvider XMLDataProvider;
            //byte[] mockBuffer = new DataEncoder(encryptable).GetBytes(XMLDataProvider.CreateXML(EventType.NewMessageAdded, e.message));
            //onlineUsersSocketDictionary[e.user.UserId].Send(mockBuffer);
        }

        protected void onNewUserDisconnected(object sender, UserEventAgrs e)
        {
            IEncryptable encryptable;
            IXMLDataProvider XMLDataProvider;
            //byte[] mockBuffer = new DataEncoder(encryptable).GetBytes(XMLDataProvider.CreateXML(EventType.NewMessageAdded, e.message));
            //onlineUsersSocketDictionary[e.user.UserId].Send(mockBuffer);
        }

        protected void onChatRoomUpdated(object sender, ChatRoomEventArgs e)
        {

            IEncryptable encryptable;
            IXMLDataProvider XMLDataProvider;
            //byte[] mockBuffer = new DataEncoder(encryptable).GetBytes(XMLDataProvider.CreateXML(EventType.NewMessageAdded, e.message));
            //onlineUsersSocketDictionary[e.user.UserId].Send(mockBuffer);
        }

        protected void onNewChatRoomAdded(object sender, ChatRoomEventArgs e)
        {

            IEncryptable encryptable;
            IXMLDataProvider XMLDataProvider;
            foreach (var item in e.chatRoom.members)
            {
                //byte[] mockBuffer = new DataEncoder(encryptable).GetBytes(XMLDataProvider.CreateXML(EventType.NewMessageAdded, e.message));
                //onlineUsersSocketDictionary[e.user.UserId].Send(mockBuffer);
            }
        }
    }
}
